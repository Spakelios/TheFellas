using System;
       using System.Collections;
       using System.Collections.Generic;
       using UnityEngine;
       using UnityEngine.UI;
       using Ink.Runtime;
       using TMPro;
using Unity.VisualScripting;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class DialogueTrigger1 : MonoBehaviour
{
    private int num;
    [SerializeField] private TextAsset _InkJsonFile;
    private Story _StoryScript;
    public TMP_Text nameTag;
    public TMP_Text dialogueBox;
    [SerializeField] private float typingSpeed = 0.04f;
    public string NextScene;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private GridLayoutGroup choiceHolder;
    [SerializeField] private Button choiceButtonPrefab;


    public GameObject choiceHold;


    private Coroutine displayLineCoroutine;

    private bool isAddingRichTextTags = false;

    private bool canContinueToNextLine = false;

    void Start()
    {
        LoadStory();
        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            DisplayNextLine();
        }
    }

    void LoadStory()
    {
        _StoryScript = new Story(_InkJsonFile.text);

    }

    public void DisplayNextLine()
    {

        if (_StoryScript.canContinue) // Checking if there is content to go through
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);

            }

            // string text = dialogueBox.text;
            displayLineCoroutine = StartCoroutine(DisplayLine(_StoryScript.Continue()));
            
            string text = dialogueBox.text;
            text = text?.Trim(); //Removes White space from the text
            dialogueBox.text = text; //Displays new text

        }
        else if (_StoryScript.currentChoices.Count > 0)
        {
            choiceHold.SetActive(true);
            DisplayChoices();
        }
        else
        {
            SceneManager.LoadScene(NextScene);
        }
    }


    public void DisplayChoices()
    {
        if (choiceHolder.GetComponentsInChildren<Button>().Length > 0)
        {
            return;
        }

        for (int i = 0; i < _StoryScript.currentChoices.Count; i++)
        {
            var choice = _StoryScript.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => onClickChoiceButton(choice));
        }
        
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueBox.text = "";
        continueIcon.SetActive(false);
        canContinueToNextLine = false;

        foreach (char letter in line.ToCharArray())
        {
            // if (canContinueToNextLine && Input.GetMouseButtonDown(0))
            // {
            //     dialogueBox.text = line;
            //     break;
            //
            // }

            if (letter == '<' || isAddingRichTextTags)
            {
                isAddingRichTextTags = true;
                dialogueBox.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTags = false;
                }
            }
            else
            {
                dialogueBox.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        // canContinueToNextLine = true;
        continueIcon.SetActive(true);
    }
    


    Button CreateChoiceButton(string text)
    {
        //instantiate button
        var choiceButton = Instantiate(choiceButtonPrefab);
        choiceButton.transform.SetParent(choiceHolder.transform, false);
        var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text;
        choiceButton.name = "woah" + num++;
        return choiceButton;
    }

    void onClickChoiceButton(Choice choice)
    {
        
        _StoryScript.ChooseChoiceIndex(choice.index);
            RefreshChoiceView();
            DisplayNextLine();
        
    }

    void RefreshChoiceView()
    {
        if (choiceHolder != null)
        {
            foreach (var button in choiceHolder.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
    
    public void ChangeName(string name)
    {
        string SpeakerName = name;

        nameTag.text = SpeakerName;
    }
    
}