using UnityEngine;

namespace NPCs
{
    public class Mission1Eclipse_Enemy : MonoBehaviour
    {
        private void OnDestroy()
        {
            if (QuestManager.Instance._currentQuestName == "mission1eclipse")
            {
                QuestManager.Instance.FinishQuest("mission1eclipse");
                QuestManager.Instance.mainQuestPhase++;
            }
        }
    }
}
