using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission3Cargo : MonoBehaviour
{
    public void Interact()
    {
        if (QuestManager.Instance._currentQuestName == "mission3eclipse")
        {
            QuestManager.Instance.mainQuestPhase++;
            gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
            StartCoroutine(FunctionsAfterDialogue());
        }
        else if (QuestManager.Instance._currentQuestName == "mission3regen")
        {
            QuestManager.Instance.mainQuestPhase++;
            gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
            StartCoroutine(FunctionsAfterDialogue());
        }

        IEnumerator FunctionsAfterDialogue()
        {
            while (DialogueManager.Instance.inDialogue)
            {
                yield return null;
            }
            Destroy(this.gameObject);
        }
    }
}
