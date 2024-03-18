using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

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

    private Transform draggingPiece = null;
    private Vector3 offset;

    public void Start()
    {
        pieces = new List<Transform>();
        dimensions = GetDimensions(picture, numberOfPieces);
        CreatePieces(picture);
        Scatter();
        UpdateBorder();

    }

    private Vector2Int GetDimensions(Texture2D picture, int numberOfPieces)
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

    private void CreatePieces(Texture2D picture)
    {
        height = 1f / dimensions.y;
        var aspect = (float) picture.width / picture.height;
        width = aspect / dimensions.x;

        for (int row = 0; row < dimensions.y; row++)
        {
            for (int col = 0; col < dimensions.x; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameHolder);
                piece.localPosition = new Vector3(
                (-width * dimensions.x / 2) + (width * col) + (width / 2),
                (-height * dimensions.y / 2) + (height * row) + (height / 2),
                -1
                    );
                piece.localScale = new Vector3(width, height, 1f);
                piece.name = $"Piece {(row * dimensions.x) + col}";
                pieces.Add(piece);

                float width1 = 1f / dimensions.x;
                float height1 = 1f / dimensions.y;

                Vector2[] uv = new Vector2[4];
                uv[0] = new Vector2(width1 * col, height1 * row);
                uv[1] =  new Vector2(width1 * (col + 1), height1 * row);
                uv[2] =  new Vector2(width1 * col, height1 * (row + 1));
                uv[3] =  new Vector2(width1 * (col + 1), height1 * (row + 1));

                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                mesh.uv = uv;
                piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", picture);
            }
        }
    }

    private void Scatter()
    {
        float orthoHeight = Camera.main.orthographicSize;
        float screenAspect = (float) Screen.width / Screen.height;
        float orthoWidth = (screenAspect * orthoHeight);

        float pieceWidth = width * gameHolder.localScale.x;
        float pieceHeight = height * gameHolder.localScale.y;

        orthoHeight -= pieceHeight;
        orthoWidth -= pieceWidth;
        
        foreach (var piece in pieces)
        {
            float x = Random.Range(-orthoWidth, orthoWidth);
            float y = Random.Range(-orthoHeight, orthoHeight);
            piece.position = new Vector3(x, y, -1f);
        }
    }

    private void UpdateBorder()
    {
        LineRenderer lineRenderer = gameHolder.GetComponent<LineRenderer>();
        float halfWidth = (width * dimensions.x) / 2f;
        float halfHeight = (height * dimensions.y) / 2f;

        float borderZ = 0f;
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
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
        }
    }
}
