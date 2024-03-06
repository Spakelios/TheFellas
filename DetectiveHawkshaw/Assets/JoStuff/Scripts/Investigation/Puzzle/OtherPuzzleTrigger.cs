using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//this script is for puzzles that don't lock an area behind it; aka most likely evidence puzzles
public class OtherPuzzleTrigger : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    
    public TextMeshProUGUI examineTagBox;
    public string examineTag;
    public string newExamineTag;
    
    private static int plus = 0;
    
    private Collider2D collider;
    private Camera camera;
    
    [SerializeField] private Vector3 textOffset;
    public Evidence evidenceStats;

    public GameObject puzzleScreen;
    private static bool puzzleSolved;

    public TextAsset unsolvedDialogueFile;
    public TextAsset solvedDialogueFile;
    private void Start()
    {
        camera = Camera.main;
        textOffset = new Vector3(0, 30, 0);
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";
        dialogueManager = FindObjectOfType<DialogueManager>();
        puzzleScreen.SetActive(false);
        examineTagBox.text = "";
    }
    
    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        examineTagBox.transform.position = Input.mousePosition + textOffset;

        if (eyeSpawned)
        {
            eye.transform.position = mousePos;
        }
    }

    public void OnMouseOver()
    {
        if (PauseGame.isPaused) return;
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
        if (puzzleScreen.activeInHierarchy) return;

        if (!eyeSpawned)
        {
            Cursor.visible = false;
            eye = Instantiate(eyePrefab);
            eyeSpawned = true;
        }

        if (InvestigationDialogueTrigger.isExamined.Contains(evidenceStats))
        {
            examineTag = newExamineTag;
        }

        examineTagBox.text = examineTag;
        examineTagBox.color = Color.black;

        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();
        

        if (!puzzleSolved)
        {
            var d = unsolvedDialogueFile.text.Split("\n");
            var di = d.ToList();
        
            dialogue.sentences = di;
            dialogueManager.otherPuzzleDialogue = true;
        }

        else
        {
            FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.evidence, transform.position);
            var d = solvedDialogueFile.text.Split("\n");
            var di = d.ToList();
        
            dialogue.sentences = di;
            dialogueManager.evidenceDialogue = true;
        }
        
        dialogueManager.evidenceStats = evidenceStats;
        dialogueManager.StartDialogue(dialogue);
        
    }
    
    private void OnMouseExit()
    {
        if (PauseGame.isPaused) return;
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        examineTagBox.text = "";
    }

    public void PuzzleSolved()
    {
        puzzleSolved = true;
        
        var d = solvedDialogueFile.text.Split("\n");
        var di = d.ToList();
        
        dialogue.sentences = di;
        
        plus++;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Intensity", plus);
        InvestigationDialogueTrigger.isExamined.Add(evidenceStats);
        
        dialogueManager.evidenceDialogue = true;
        dialogueManager.evidenceStats = evidenceStats;
        dialogueManager.StartDialogue(dialogue);
        
    }
}
