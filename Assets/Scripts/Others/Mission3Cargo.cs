using System.Collections;
using System.Collections.Generic;
using NPCs;
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
            var arthur = GameObject.FindWithTag("Arthur");
            arthur.transform.position = arthur.GetComponent<Arthur>().teleportPoints[2].transform.position;
            var yonder = GameObject.FindWithTag("Yonder");
            yonder.transform.position = yonder.GetComponent<Yonder>().teleportPoints[2].transform.position;
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
