using UnityEngine;

namespace NPCs
{
    public class Mission1Regen_BlueCyborg : MonoBehaviour
    {
        private void OnDestroy()
        {
            if (QuestManager.Instance._currentQuestName == "mission1regen")
            {
                QuestManager.Instance.FinishQuest("mission1regen");
                QuestManager.Instance.mainQuestPhase++;
            }
        }
    }
}
