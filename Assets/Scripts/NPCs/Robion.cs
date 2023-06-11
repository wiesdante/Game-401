using System;
using System.Collections;
using UnityEngine;

public class Robion : MonoBehaviour
{

    public void Interact()
    {
        if (QuestManager.Instance.mainQuestPhase == 15)
        {
            if (QuestManager.Instance._currentQuestName == "mission4eclipse")
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
            }
            else if (QuestManager.Instance._currentQuestName == "mission4regen")
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(2);
            }


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
            if (QuestManager.Instance._currentQuestName == "mission4regen")
            {
                GameObject.FindWithTag("Clarie").SetActive(false);
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(3);
                QuestManager.Instance.mainQuestPhase++;
                StartCoroutine(FunctionsAfterDialogue());
            }
            else if (QuestManager.Instance._currentQuestName == "mission4eclipse")
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
                QuestManager.Instance.mainQuestPhase++;
                StartCoroutine(FunctionsAfterDialogue());
            }
            
        }
        else if (QuestManager.Instance.mainQuestPhase == 16)
        {
            Application.Quit();
        }

    }
}
