using UnityEngine;

namespace NPCs
{
    public class Nemo : MonoBehaviour
    {
        public void Interact()
        {
            switch (QuestManager.Instance.mainQuestPhase)
            {
                case 0:
                    gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                    QuestManager.Instance.StartQuest("Find a leg for nemo and get back to him!", "NemosLeg");
                    QuestManager.Instance.mainQuestPhase++;
                    break;
                case 1:
                    break;
                case 2:
                    gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
                    QuestManager.Instance.FinishQuest("NemosLeg");
                    QuestManager.Instance.mainQuestPhase++;
                    break;
                default:
                    break;
            }
        }
    }
}
