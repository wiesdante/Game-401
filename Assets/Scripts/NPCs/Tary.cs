using System.Collections;
using UnityEngine;

namespace NPCs
{
    public class Tary : MonoBehaviour
    {
        public void Interact()
        {
            if (QuestManager.Instance.mainQuestPhase == 3)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                StartCoroutine(FunctionsAfterDialogue());
            }
        }
        
        IEnumerator FunctionsAfterDialogue()
        {
            if (QuestManager.Instance.mainQuestPhase == 3)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                QuestManager.Instance.mainQuestPhase++;
                gameObject.SetActive(false);
            }
        }
    }
}
