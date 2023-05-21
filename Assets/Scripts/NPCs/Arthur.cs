using System.Collections;
using UnityEngine;

namespace NPCs
{
    public class Arthur : MonoBehaviour
    {
        public Transform[] teleportPoints;
        
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
            else if (QuestManager.Instance.mainQuestPhase == 10)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(5);
                StartCoroutine(FunctionsAfterDialogue());
            }
            else if (QuestManager.Instance.mainQuestPhase == 12)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(6);
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
                transform.position = teleportPoints[0].transform.position;
            }
            else if (QuestManager.Instance.mainQuestPhase == 5)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }
                QuestManager.Instance.StartQuest("Kill the evil cyborgs in the area!","mission1regen");
                QuestManager.Instance.mainQuestPhase++;
                QuestManager.Instance.SetMobs(1);
            }
            else if (QuestManager.Instance.mainQuestPhase == 7)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }

                QuestManager.Instance.mainQuestPhase++;
                transform.position = teleportPoints[1].transform.position;
                var arthur = GameObject.FindWithTag("Tary");
                arthur.transform.position = arthur.GetComponent<Tary>().teleportPoints[1].transform.position;
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(4);
                QuestManager.Instance.StartQuest("Go back to your home.","sleepaftermission1");
            }
            else if (QuestManager.Instance.mainQuestPhase == 10)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }

                QuestManager.Instance.mainQuestPhase++;
                QuestManager.Instance.StartQuest("Take the package from the warehouse, and return it to Arthur!","mission2regen");

            }
            else if (QuestManager.Instance.mainQuestPhase == 12)
            {
                while (DialogueManager.Instance.inDialogue)
                {
                    yield return null;
                }

                QuestManager.Instance.mainQuestPhase++;
                QuestManager.Instance.FinishQuest("mission2part2");
                QuestManager.Instance.StartQuest("Go to the robot graveyard and bring back the ReGen cargo.","mission3regen");
                QuestManager.Instance.SetMobs(2);

            }
        }
    }
}
