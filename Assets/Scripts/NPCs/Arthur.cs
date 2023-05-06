using System.Collections;
using UnityEngine;

namespace NPCs
{
    public class Arthur : MonoBehaviour
    {
        public void Interact()
        {
            if (QuestManager.Instance.mainQuestPhase == 4)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                StartCoroutine(FunctionsAfterDialogue());
            }
        }

        IEnumerator FunctionsAfterDialogue()
        {
            if (QuestManager.Instance.mainQuestPhase == 4)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                QuestManager.Instance.mainQuestPhase++;
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
                gameObject.SetActive(false);
            }
        }
    }
}
