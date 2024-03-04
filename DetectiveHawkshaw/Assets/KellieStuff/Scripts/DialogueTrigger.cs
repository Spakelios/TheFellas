using System;
       using System.Collections;
       using System.Collections.Generic;
using System.Linq;
using UnityEngine;
       using UnityEngine.UI;
       using Ink.Runtime;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink")]
    private int num;
    [SerializeField] private TextAsset _InkJsonFile;
    private Story _StoryScript;
    private Image imageButton;

    [Header("Dialogue")]
    public TMP_Text dialogueBox;
    public TMP_Text nameTag;
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private GameObject continueIcon;

    [Header("Icons")]
    public Image characterIcon;
    public Image Icon;
    [SerializeField] private GridLayoutGroup choiceHolder;
    public Image backgroundIcon;
    public GameObject button2;
    public Image Evi;
    public GameObject fmod;
    public Image Char2; 
    public Image cha3;

    
    [Header("Animators")]
    public Animator anim;
    public Animator anim2; 
    public Animator animChar3;
    public Animator animChar1;
    public Animator animChar2;
    public GameObject choiceHold;


    public List<Button> choiceButtons = new List<Button>();
    private Coroutine displayLineCoroutine;

    private bool isAddingRichTextTags = false;

    private bool canContinueToNextLine = false;

    void Start()
    {
        LoadStory();
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

        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
        _StoryScript.BindExternalFunction("Icon", (string charName) => CharacterIcon(charName));
        _StoryScript.BindExternalFunction("Back", (string charName) => BackIcon(charName));
        _StoryScript.BindExternalFunction("MC", (string charName) => charactersIcon(charName));
        _StoryScript.BindExternalFunction("Evi", (string charName) => EviIcon(charName));
        _StoryScript.BindExternalFunction("Char2", (string charName) => Char(charName)); 
        _StoryScript.BindExternalFunction("Char3", (string charName) => Char3(charName));
        
        _StoryScript.BindExternalFunction("Sound", (string soundName) => FModShenanigans(soundName));
        
        _StoryScript.BindExternalFunction("PlayAnimation", (string playAnimation) => {anim.Play(playAnimation);});     
        _StoryScript.BindExternalFunction("PlayAnimation2", (string playAnimation2) => {anim2.Play(playAnimation2);});
        _StoryScript.BindExternalFunction("PlayAnimation3", (string playAnimation3) => {animChar3.Play(playAnimation3);});
        _StoryScript.BindExternalFunction("PlayAnimation1", (string playAnimation1) => {animChar1.Play(playAnimation1);});
        _StoryScript.BindExternalFunction("PlayAnimation4", (string playAnimation4) => {animChar2.Play(playAnimation4);});
     
     
        
        DisplayNextLine();

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
            button2.SetActive(true);
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
            //var button = CreateChoiceButton(choice.text);
            var button = choiceButtons[i];
            button.gameObject.SetActive(true);
            button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
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
    
    void onClickChoiceButton(Choice choice)
    {
        if (_StoryScript.currentChoices.Count > 0)
        {
            _StoryScript.ChooseChoiceIndex(choice.index);
            RefreshChoiceView();
            DisplayNextLine();
        }

    }

    void RefreshChoiceView()
    {
        for (int i = 0; i < choiceButtons.Count; i++)
        {
            choiceButtons[i].gameObject.SetActive(false);
        }
    }

    public void ChangeName(string name)
    {
        string SpeakerName = name;

        nameTag.text = SpeakerName;
    }

    public void CharacterIcon(string name)
    {
        var charIcon = Resources.Load<Sprite>("characterIcons/" + name);
        characterIcon.sprite = charIcon;
    }
    public void BackIcon(string name)
    {
        var backIcon = Resources.Load<Sprite>("characterIcons/" + name);
        backgroundIcon.sprite = backIcon;
    }
    public void charactersIcon(string name)
    {
        var WaterIcon = Resources.Load<Sprite>("characterIcons/" + name);
        Icon.sprite = WaterIcon;
    }
    public void EviIcon(string name)
    {
        var EviIcon = Resources.Load<Sprite>("characterIcons/" + name);
        Evi.sprite = EviIcon;
    }
    public void Char(string name)
    {
        var char2 = Resources.Load<Sprite>("characterIcons/" + name);
        Char2.sprite = char2;
    }  
    public void Char3(string name)
    {
        var char3 = Resources.Load<Sprite>("characterIcons/" + name);
        cha3.sprite = char3;
    }


    public void FModShenanigans(string name)
    {
        fmod.SetActive(true);
    }

    
}