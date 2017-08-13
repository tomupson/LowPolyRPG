using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Queue<string> sentences;
    [HideInInspector] public bool isInConversation;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Text dialogueNameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button nextSentenceButton;

    public Animator animator;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else Debug.LogWarning("More than one DialogueManager in the scene!");
    }

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (isInConversation)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
            if (sentences.Count == 0)
            {
                nextSentenceButton.GetComponentInChildren<Text>().text = "Finish";
            } else
            {
                nextSentenceButton.GetComponentInChildren<Text>().text = "Continue >>";
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        isInConversation = true;

        animator.SetBool("isOpen", true);
        
        Debug.Log("Starting dialogue with " + dialogue.name);

        dialogueNameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentSentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of dialogue");
        animator.SetBool("isOpen", false);
        isInConversation = false;
    }

    public void HideDialogueBox()
    {
        dialogueBox.SetActive(false);
    }
}