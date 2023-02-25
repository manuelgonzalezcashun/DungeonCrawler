using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextAsset _InkJsonFile;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject GameplayUI;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueisPlaying;

    private static DialogueManager instance;
    public LevelCounter counter;

    /// Variable Obeservers
    private bool runAway;
    private int numOfEnemies = 3;

    public bool RunAway
    {
        get => runAway;
        private set
        {
            runAway = value;
        }
    }

    private void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Found more than one Dialogue Manager in the Scene");

        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
    private void InitializeVariables()
    {
        RunAway = (bool)currentStory.variablesState["RunAway"];
        currentStory.ObserveVariable("RunAway", (arg, value) =>
        {
            RunAway = (bool)value;
        });
    }

    void Start()
    {
        dialogueisPlaying = false;
        BeginStory();
        if (GameManagement.GetInstance().GetCurrentScene() == 1 )
        {
            InitializeVariables();
        }
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }
    void Update()
    {
        if (GameManagement.GetInstance().GetCurrentScene() == 1 
        && counter.enemiesKilled == numOfEnemies)
        {
            NPC.SetActive(true);
        }
        if (!dialogueisPlaying)
        {
            GameplayUI.SetActive(true);
            Time.timeScale = 1f;
            return;
        }
        if (dialogueisPlaying)
        {
            GameplayUI.SetActive(false);
            Time.timeScale = 0f;
        }
            

        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<SoundManager>().Play("Dialogue");
            ContinueStory();
        }
        RunAwayChoice();
    }
    public void BeginStory()
    {
        currentStory = new Story(_InkJsonFile.text);
        dialogueisPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueisPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }
    private void ExitDialogueMode()
    {
        dialogueisPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    private void RunAwayChoice()
    {
        if (RunAway)
        {
            GameManagement.GetInstance().QuitLevel();
        }
    }
}
