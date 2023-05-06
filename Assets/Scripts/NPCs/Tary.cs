using System.Collections;
using UnityEngine;

namespace NPCs
{
    public class Tary : MonoBehaviour
    {
        public int dialoguePhase = 0;
        public void Interact()
        {
            if (QuestManager.Instance.mainQuestPhase == 1)
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
                gameObject.SetActive(false);
            }
        }
    }
}
