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
    [TextArea(3, 10)] 
    public string[] dialogue4;
    [TextArea(3, 10)] 
    public string[] dialogue5;
    [TextArea(3, 10)] 
    public string[] dialogue6;
    [TextArea(3, 10)] 
    public string[] dialogue7;
    [TextArea(3, 10)] 
    public string[] dialogue8;
    [TextArea(3, 10)] 
    public string[] dialogue9;
    [TextArea(3, 10)] 
    public string[] dialogue10;
    

    private List<string[]> dialogues;

    private void Awake()
    {
        dialogues = new List<string[]>();
        dialogues.Add(dialogue0);
        dialogues.Add(dialogue1);
        dialogues.Add(dialogue2);
        dialogues.Add(dialogue3);
        dialogues.Add(dialogue4);
        dialogues.Add(dialogue5);
        dialogues.Add(dialogue6);
        dialogues.Add(dialogue7);
        dialogues.Add(dialogue8);
        dialogues.Add(dialogue9);
        dialogues.Add(dialogue10);

        
    }


    public void TriggerDialogue(int phase)
    {
        DialogueManager.Instance.StartDialogue(dialogues[phase]);
    }
}
