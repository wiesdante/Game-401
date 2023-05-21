using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clarie : MonoBehaviour
{
    public void Interact()
    {
        if (QuestManager.Instance.mainQuestPhase == 16)
        {
            gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
        }
    }

    IEnumerator FunctionsAfterDialogue()
    {
        while (DialogueManager.Instance.inDialogue)
        {
            yield return null;
        }
        
        //
    }
}
