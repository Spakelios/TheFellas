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

public class DialogueManagerA : MonoBehaviour
{
    private int num;
    [SerializeField] private TextAsset _InkJsonFile;
    private Story _StoryScript;
    private Image imageButton;
    public GameObject EviContainer;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;
    [SerializeField] private float typingSpeed = 0.04f;

    [SerializeField] private GameObject continueIcon;

    // private Text text;


    public Image characterIcon;
    public Image Icon;
    [SerializeField] private GridLayoutGroup choiceHolder;
    [SerializeField] private Button choiceButtonPrefab;
    public Image backgroundIcon;
    public GameObject button2;
    public Image Evi;
    public GameObject fmod;
    public Image ButtonImage;
    

    public GameObject choiceHold;


    public List<Button> choiceButtons = new List<Button>();
    private Coroutine displayLineCoroutine;

    private bool isAddingRichTextTags = false;

    private bool canContinueToNextLine = false;

    private const string EVIDENCE_TAG = "Evidence";

    [SerializeField] private List<Sprite> pictures = new List<Sprite>();

    public List<Button> evidenceButtons = new List<Button>();

    public List<Sprite> evidenceSprites = new List<Sprite>();
    void Start()
    {
       // CreateButtons();
        LoadStory();
        RemoveEvidence();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            
            if (_StoryScript.currentTags.Count > 0)
            {
                Debug.Log("able to reach");
                HandleTags(_StoryScript.currentTags);
            }

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
    
    void HandleTags(List<string> currentTags)
    {
        
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be properly parsed" + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case EVIDENCE_TAG:
                {
                    Debug.Log("Handled");
                    bool result = Int32.TryParse(tagValue, out int id);
                    if (result)
                    {
                        DisplayEvidence(id);
                    }

                    break;
                }
            }
        }
    }


    public void DisplayEvidence(int id)
    {
       
        Debug.Log("YEA");
        evidenceButtons[id].GetComponent<Image>().sprite = evidenceSprites[id];
        evidenceButtons[id].onClick.AddListener(() => ShowEvidence(id));
        evidenceButtons[id].gameObject.SetActive(true);
        EviContainer.SetActive(true);

    }

    public void RemoveEvidence()
    {
        foreach (var butt in evidenceButtons)
        {
            butt.gameObject.SetActive(false);
        }
    }
    public void DisplayChoices()
    {
        //if (choiceHolder.GetComponentsInChildren<Button>().Length > 0)
        //{
           // return;
        //}
        
        
       
        
        for (int i = 0; i < _StoryScript.currentChoices.Count; i++)
        {
            var button = choiceButtons[i];
            button.gameObject.SetActive(true);

            var choice = _StoryScript.currentChoices[i];

            TextMeshProUGUI choiceText = button.GetComponentInChildren<TextMeshProUGUI>();
            //var button = CreateChoiceButton(choice.text);
            var image = button.GetComponent<Image>();
            image.sprite = pictures[0];
            
            if (choice.text.Contains("Picture^:"))
            {
                choiceText.text = string.Empty;
                string text = choice.text;

                string result = text.Split("^:")[1];

                int value = Int32.Parse(result);

               

                image.sprite = pictures[value];
        


            }

            else
            {
                
                choiceText.text = choice.text;
               
            }
            
            
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
        ButtonImage = choiceButton.GetComponentInChildren<Image>();
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



    public void ShowEvidence(int id)
    {
        Debug.Log(id);
        _StoryScript.EvaluateFunction("showEvidence", id + 1);
        Debug.Log($"You used Evidence {id}");
        
        RemoveEvidence();
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
    
    [System.Serializable]
    public class PictureClass
    {
        public Sprite picture;
        public Vector2 dimensions;
    }
}