using UnityEngine;

public class Interactable : MonoBehaviour
{
   public InteractionType interactionType;
   private int _phase;
   [Header("If Quest Dialogue Npc")] 
   public string questNameForNpc;
   public string questDescription;
   [HideInInspector] public bool questConditionMet;
   [Header("If Quest Item")] 
   public string questNameForItem;
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
      }
      else if (interactionType == InteractionType.QuestDialogueNpc)
      {
         GetComponent<DialogueStarter>().TriggerDialogue(_phase);
         if (questConditionMet)
         {
            QuestManager.Instance.FinishQuest(questNameForNpc);
         }
         else
         {
            QuestManager.Instance.StartQuest(questDescription,questNameForNpc);
         }
      }
      else if (interactionType == InteractionType.QuestItem)
      {
         if (questNameForItem == QuestManager.Instance.GetCurrentQuestName())
         {
            GetComponent<DialogueStarter>().TriggerDialogue(_phase);
            GameObject.FindWithTag(questItemOf).GetComponent<Interactable>().NextPhase();
            GameObject.FindWithTag(questItemOf).GetComponent<Interactable>().questConditionMet = true;
            Destroy(this.gameObject);
         }
      }
   }

   public void NextPhase()
   {
      _phase++;
   }

}
