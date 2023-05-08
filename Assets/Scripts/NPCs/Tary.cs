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
            else if (QuestManager.Instance.mainQuestPhase == 5)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
                StartCoroutine(FunctionsAfterDialogue());
            }
            else if (QuestManager.Instance.mainQuestPhase == 7)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(2);
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
                //Tary needs to go to exit of the evil cyborg area.
            }
            else if (QuestManager.Instance.mainQuestPhase == 5)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                QuestManager.Instance.StartQuest("Kill the evil cyborgs and save the man!","mission1eclipse");
                QuestManager.Instance.mainQuestPhase++;
            }
            else if (QuestManager.Instance.mainQuestPhase == 7)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                QuestManager.Instance.mainQuestPhase++;
            }
        }
    }
}
