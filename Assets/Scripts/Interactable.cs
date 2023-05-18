using NPCs;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   private string _interactableName;

   private void Start()
   {
      _interactableName = gameObject.name;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         UIManager.Instance.ShowInteractionText(true);
         other.GetComponent<Player>().SetCurrentInteractableGameObject(this);
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
      switch (_interactableName)
      {
         case "Nemo":
            gameObject.GetComponent<Nemo>().Interact();
            UIManager.Instance.ShowInteractionText(false);
            break;
         case "Nemo_Leg_Interactable":
            gameObject.GetComponent<Nemo_Leg_Interactable>().Interact();
            UIManager.Instance.ShowInteractionText(false);
            break;
         case "Tary":
            gameObject.GetComponent<Tary>().Interact();
            UIManager.Instance.ShowInteractionText(false);
            break;
         case "Arthur":
            gameObject.GetComponent<Arthur>().Interact();
            UIManager.Instance.ShowInteractionText(false);
            break;
         case "Yonder":
            gameObject.GetComponent<Yonder>().Interact();
            UIManager.Instance.ShowInteractionText(false);
            break;
         default:
            break;
      }
   }
}
