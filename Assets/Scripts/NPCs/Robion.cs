using System;
using System.Collections;
using UnityEngine;

public class Robion : MonoBehaviour
{

    public void Interact()
    {
        if (QuestManager.Instance.mainQuestPhase == 15)
        {
            gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);

            StartCoroutine(FunctionsAfterDialogue());
        }
        
    }

    IEnumerator FunctionsAfterDialogue()
    {
        while (DialogueManager.Instance.inDialogue)
        {
            yield return null;
        }

        if (QuestManager.Instance.mainQuestPhase == 15)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
            StartCoroutine(FunctionsAfterDialogue());
        }
        else if (QuestManager.Instance.mainQuestPhase == 16)
        {
            Application.Quit();
        }

    }
}
