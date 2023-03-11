using UnityEngine;

public class Interactable : MonoBehaviour
{
   public InteractionType interactionType;
   private int _phase;
   public string questItemOf;


   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         UIManager.Instance.ShowInteractionText(true);
         other.GetComponent<Player>().SetCurrentInteractableGameObject(this.gameObject);
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         UIManager.Instance.ShowInteractionText(false);
         other.GetComponent<Player>().SetCurrentInteractableGameObject(null);
      }
   }

   public void Interact()
   {
      UIManager.Instance.ShowInteractionText(false);
      if (interactionType == InteractionType.DialogueNpc)
      {
         GetComponent<DialogueStarter>().TriggerDialogue(_phase);
         //return;
      }
      else if (interactionType == InteractionType.QuestItem)
      {
         GetComponent<DialogueStarter>().TriggerDialogue(_phase);
         GameObject.FindWithTag("Nemo").GetComponent<Interactable>().NextPhase();
         Destroy(this.gameObject);
      }
   }

   public void NextPhase()
   {
      _phase++;
   }

}
