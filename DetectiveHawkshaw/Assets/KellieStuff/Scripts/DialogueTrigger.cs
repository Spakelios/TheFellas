using System;
       using System.Collections;
       using System.Collections.Generic;
       using UnityEngine;
       using UnityEngine.UI;
       using Ink.Runtime;
       using TMPro;
       using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    private int num;
    [SerializeField] private TextAsset _InkJsonFile;
    private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;


    public Image characterIcon;
    public Image Icon;
    [SerializeField] private GridLayoutGroup choiceHolder;
    [SerializeField] private Button choiceButtonPrefab;
    public GameObject butt;
    public Image backgroundIcon;


    void Start()
    {
        LoadStory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        DisplayNextLine();

    }

    public void DisplayNextLine()
    {
        if (_StoryScript.canContinue) // Checking if there is content to go through
        {
            string text = _StoryScript.Continue(); //Gets Next Line
            text = text?.Trim(); //Removes White space from the text
            dialogueBox.text = text; //Displays new text
        }
        else if (_StoryScript.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else
        {
            // dialogueBox.text = ".....";
            // SceneManager.LoadScene("UI BONUS ROUND");
            butt.SetActive(true);
        }
    }

    public void DisplayChoices()
    {
        if (choiceHolder.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _StoryScript.currentChoices.Count; i++)
        {
            var choice = _StoryScript.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => onClickChoiceButton(choice));
        }


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
}