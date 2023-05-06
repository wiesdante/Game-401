using UnityEngine;

namespace NPCs
{
    public class Nemo_Leg_Interactable : MonoBehaviour
    {
        public void Interact()
        {
            GameObject nemo = GameObject.FindWithTag("Nemo");
            if (nemo.GetComponent<Nemo>().dialoguePhase == 1)
            {
                gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
                nemo.GetComponent<Nemo>().dialoguePhase++;
                Destroy(this.gameObject);
            }
        }
    }
}
