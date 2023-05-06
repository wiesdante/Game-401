using UnityEngine;

namespace NPCs
{
    public class Nemo : MonoBehaviour
    {
        public int dialoguePhase = 0;
        public void Interact()
        {
            switch (dialoguePhase)
            {
                case 0:
                    gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                    QuestManager.Instance.StartQuest("Find a leg for nemo and get back to him!", "NemosLeg");
                    dialoguePhase++;
                    break;
                case 1:
                    gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                    break;
                case 2:
                    gameObject.GetComponent<DialogueStarter>().TriggerDialogue(1);
                    QuestManager.Instance.FinishQuest("NemosLeg");
                    dialoguePhase++;
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
