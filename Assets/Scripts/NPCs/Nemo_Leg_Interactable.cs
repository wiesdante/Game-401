using System.Collections;
using UnityEngine;

namespace NPCs
{
    public class Nemo_Leg_Interactable : MonoBehaviour
    {
        public void Interact()
        {
            GameObject nemo = GameObject.FindWithTag("Nemo");
            if (QuestManager.Instance.mainQuestPhase == 1)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                StartCoroutine(FunctionsAfterDialogue());
            }
        }

        IEnumerator FunctionsAfterDialogue()
        {
            if (QuestManager.Instance.mainQuestPhase == 1)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                QuestManager.Instance.mainQuestPhase++;
                Destroy(this.gameObject);
            }
        }
    }
}
