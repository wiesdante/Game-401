using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    private Queue<string> _sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private bool _typing;
    public bool inDialogue;
    private string[] _splitVersion;
    
    
    
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(string[] dialogue)
    {
        Time.timeScale = 0f;
        animator.SetBool(IsOpen,true);
        _sentences.Clear();
        inDialogue = true;

        foreach (string str in dialogue)
        {
            _sentences.Enqueue(str);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_typing)
        {
            StopAllCoroutines();
            _typing = false;
            dialogueText.text = _splitVersion[1];
            return;
        }
        
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        _splitVersion = sentence.Split("|");
        nameText.text = _splitVersion[0];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(_splitVersion[1]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        _typing = true;
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.025f);
        }

        _typing = false;
    }

    public void EndDialogue()
    {
        Time.timeScale = 1f;
        animator.SetBool(IsOpen,false);
        inDialogue = false;
    }
}
