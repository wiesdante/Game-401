using System.Collections;
using UnityEngine;

namespace NPCs
{
    public class Arthur : MonoBehaviour
    {
        public int dialoguePhase = 0;
        public void Interact()
        {
            if (QuestManager.Instance.mainQuestPhase == 2)
            {
                if (dialoguePhase == 0)
                {
                    gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                    StartCoroutine(FunctionsAfterDialogue());
                }
            }
        }

        IEnumerator FunctionsAfterDialogue()
        {
            if (dialoguePhase == 0)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                dialoguePhase++;
                QuestManager.Instance.mainQuestPhase++;
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
                gameObject.SetActive(false);
            }
        }
    }
}
