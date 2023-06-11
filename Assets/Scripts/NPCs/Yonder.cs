using System.Collections;
using UnityEngine;

namespace NPCs
{
    public class Yonder : MonoBehaviour
    {
        public Transform[] teleportPoints;
        
        public void Interact()
        {
            if (QuestManager.Instance.mainQuestPhase == 9)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                StartCoroutine(FunctionsAfterDialogue());
            }
            else if (QuestManager.Instance.mainQuestPhase == 14)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
                StartCoroutine(FunctionsAfterDialogue());
            }
        }

        public void Teleport(int teleportPoint)
        {
            gameObject.transform.position = teleportPoints[teleportPoint].transform.position;
        }

        IEnumerator FunctionsAfterDialogue()
        {
            if (QuestManager.Instance.mainQuestPhase == 9)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }

                QuestManager.Instance.mainQuestPhase++;
                Teleport(1);
            }
            else if (QuestManager.Instance.mainQuestPhase == 14)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }

                QuestManager.Instance.mainQuestPhase++;
                QuestManager.Instance.FinishQuest("mission3regen");
                QuestManager.Instance.StartQuest("Go inside the ReGen building to save your sister!","mission4regen");
            }
        }
    }
}
