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
    private int num;
    [SerializeField] private TextAsset _InkJsonFile;
    private Story _StoryScript;
    private Image imageButton;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;
    [SerializeField] private float typingSpeed = 0.04f;

    [SerializeField] private GameObject continueIcon;

    public Image characterIcon;
    public Image Icon;
    [SerializeField] private GridLayoutGroup choiceHolder;
    [SerializeField] private Button choiceButtonPrefab;

    public Image backgroundIcon;
    public GameObject button2;
    public Image Evi;
    public GameObject fmod;

    public Animator anim;
    public Animator anim2;
    public GameObject choiceHold;


    public List<Button> choiceButtons = new List<Button>();
    private Coroutine displayLineCoroutine;

    private bool isAddingRichTextTags = false;

    private bool canContinueToNextLine = false;

    void Start()
    {
       // CreateButtons();
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
        _StoryScript.BindExternalFunction("Sound", (string soundName) => FModShenanigans(soundName));
        _StoryScript.BindExternalFunction("PlayAnimation", (string playAnimation) => {anim.Play(playAnimation);});     
        _StoryScript.BindExternalFunction("PlayAnimation2", (string playAnimation2) => {anim2.Play(playAnimation2);});
     
        
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
        
        //make this redundant and have it all manual instead
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
       // if (choiceHolder != null)
        //{
        //    foreach (var button in choiceHolder.GetComponentsInChildren<Button>())
         //   {
         //       Destroy(button.gameObject);
        //    }
       // }
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


    public void FModShenanigans(string name)
    {
        fmod.SetActive(true);
    }

    
}