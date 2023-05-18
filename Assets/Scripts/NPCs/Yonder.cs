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
        }
    }
}
