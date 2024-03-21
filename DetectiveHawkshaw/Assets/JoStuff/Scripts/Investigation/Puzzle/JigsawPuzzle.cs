using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawPuzzle : MonoBehaviour
{
    public Texture2D picture;
    private List<Transform> pieces;
    private Vector2Int dimensions;
    public int numberOfPieces;
    private float width;
    private float height;

    public Transform gameHolder;
    public Transform piecePrefab;

    public Transform draggingPiece = null;
    private Vector3 offset;
    private int piecesCorrect;
    public GameObject explanation;

    public void Start()
    {
        pieces = new List<Transform>();
        dimensions = GetDimensions(picture, numberOfPieces);
        piecesCorrect = 0;
        CreatePieces(picture);
        Scatter();
        UpdateBorder();

    }

    private Vector2Int GetDimensions(Texture picture, int numberOfPieces)
    {
        if (picture.width < picture.height) //e.g. if height is double the width, you'd get twice as many pieces
        {
            dimensions.x = numberOfPieces;
            dimensions.y = (numberOfPieces * picture.height) / picture.width;
        }

        else
        {
            dimensions.y = numberOfPieces;
            dimensions.x = (numberOfPieces * picture.width) / picture.height;
        }
        return dimensions;
    }

    private void CreatePieces(Texture picture)
    {
        height = 1f / dimensions.y;
        var aspect = (float) picture.width / picture.height;
        width = aspect / dimensions.x;

        for (var row = 0; row < dimensions.y; row++)
        {
            for (var col = 0; col < dimensions.x; col++)
            {
                var piece = Instantiate(piecePrefab, gameHolder);
                piece.localPosition = new Vector3(
                (-width * dimensions.x / 2) + (width * col) + (width / 2),
                (-height * dimensions.y / 2) + (height * row) + (height / 2),
                -1
                    );
                piece.localScale = new Vector3(width, height, 1f);
                piece.name = $"Piece {(row * dimensions.x) + col}";
                pieces.Add(piece);

                var width1 = 1f / dimensions.x;
                var height1 = 1f / dimensions.y;

                var uv = new Vector2[4];
                uv[0] = new Vector2(width1 * col, height1 * row);
                uv[1] =  new Vector2(width1 * (col + 1), height1 * row);
                uv[2] =  new Vector2(width1 * col, height1 * (row + 1));
                uv[3] =  new Vector2(width1 * (col + 1), height1 * (row + 1));

                var mesh = piece.GetComponent<MeshFilter>().mesh;
                mesh.uv = uv;
                piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", picture);
            }
        }
    }

    private void Scatter()
    {
        var orthoHeight = Camera.main.orthographicSize;
        var screenAspect = (float) Screen.width / Screen.height;
        var orthoWidth = (screenAspect * orthoHeight);

        var pieceWidth = width * gameHolder.localScale.x;
        var pieceHeight = height * gameHolder.localScale.y;

        orthoHeight -= pieceHeight;
        orthoWidth -= pieceWidth;
        
        foreach (var piece in pieces)
        {
            var x = Random.Range(-orthoWidth, orthoWidth);
            var y = Random.Range(-orthoHeight, orthoHeight);
            piece.position = new Vector3(x, y, -1f);
        }
    }

    private void UpdateBorder()
    {
        var lineRenderer = gameHolder.GetComponent<LineRenderer>();
        var halfWidth = (width * dimensions.x) / 2f;
        var halfHeight = (height * dimensions.y) / 2f;

        const float borderZ = 0f;
        lineRenderer.SetPosition(0, new Vector3(-halfWidth, halfHeight, borderZ));
        lineRenderer.SetPosition(1, new Vector3(halfWidth, halfHeight, borderZ));
        lineRenderer.SetPosition(2, new Vector3(halfWidth, -halfHeight, borderZ));
        lineRenderer.SetPosition(3, new Vector3(-halfWidth, -halfHeight, borderZ));

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.enabled = true;
    }

    private void Update()
    {
        if (PauseGame.isPaused) return;
        if (explanation.activeInHierarchy) return;
        
        if (Input.GetMouseButtonDown(0))
        {

            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.transform.CompareTag("JigsawPiece"))
            {
                FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.journalFlick, transform.position);
                draggingPiece = hit.transform;
                offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset += Vector3.back;
            }
        }

        if (draggingPiece && Input.GetMouseButtonUp(0))
        {
            SnapAndDisableIfCorrect();
            draggingPiece.position += Vector3.forward;
            draggingPiece = null;
        }

        if (draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition += offset;
            draggingPiece.position = newPosition;
        }
    }

    private void SnapAndDisableIfCorrect()
    {
        int pieceIndex = pieces.IndexOf(draggingPiece);

        int col = pieceIndex % dimensions.x;
        int row = pieceIndex / dimensions.x;

        Vector2 targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2),
            (-height * dimensions.y / 2) + (height * row) + (height / 2));
        
        //checks if we're in the correct location within a certain threshold; make number bigger for harder puzzle
        if (Vector2.Distance(draggingPiece.localPosition, targetPosition) < width / 2)
        {
            draggingPiece.localPosition = targetPosition;
            draggingPiece.GetComponent<BoxCollider2D>().enabled = false;
            piecesCorrect++;

            if (piecesCorrect == pieces.Count)
            {
                JigsawSolvedCheck.jigsawDone = true;
            }
        }
    }
}
