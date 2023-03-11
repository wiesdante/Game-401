using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    [TextArea(3, 10)] 
    public string[] dialogue0;
    [TextArea(3, 10)] 
    public string[] dialogue1;
    [TextArea(3, 10)] 
    public string[] dialogue2;
    [TextArea(3, 10)] 
    public string[] dialogue3;

    private List<string[]> dialogues;

    private void Awake()
    {
        dialogues = new List<string[]>();
        dialogues.Add(dialogue0);
        dialogues.Add(dialogue1);
        dialogues.Add(dialogue2);
        dialogues.Add(dialogue3);
    }


    public void TriggerDialogue(int phase)
    {
        DialogueManager.Instance.StartDialogue(dialogues[phase]);
    }
}
