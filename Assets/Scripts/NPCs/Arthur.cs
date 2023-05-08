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
            else if (QuestManager.Instance.mainQuestPhase == 5)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(2);
                StartCoroutine(FunctionsAfterDialogue());
            }
            else if (QuestManager.Instance.mainQuestPhase == 7)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(3);
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
                //Arthur needs to go to entrance of the evil cyborg area.
            }
            else if (QuestManager.Instance.mainQuestPhase == 5)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                QuestManager.Instance.StartQuest("Destroy the blue cyborg!","mission1regen");
                QuestManager.Instance.mainQuestPhase++;
            }
            else if (QuestManager.Instance.mainQuestPhase == 7)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }

                QuestManager.Instance.mainQuestPhase++;
                //Arthur leaves the area
            }
        }
    }
}
