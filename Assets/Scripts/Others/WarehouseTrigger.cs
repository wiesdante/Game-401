using System;
using UnityEngine;

namespace Others
{
    public class WarehouseTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && QuestManager.Instance.mainQuestPhase == 11)
            {
                QuestManager.Instance.FinishQuest("mission2eclipse");
                QuestManager.Instance.FinishQuest("mission2regen");
                QuestManager.Instance.mainQuestPhase++;
                QuestManager.Instance.StartQuest("You got the package, now go back!","mission2part2");
            }
        }
    }
}
