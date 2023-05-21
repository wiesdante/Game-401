using UnityEngine;

namespace Emrenemy_Scripts
{
    public class Mission1TargetEmrenemy : MonoBehaviour
    {
        private void OnDestroy()
        {
            QuestManager.Instance.FinishQuest("mission1regen");
            QuestManager.Instance.FinishQuest("mission1eclipse");
            QuestManager.Instance.mainQuestPhase++;
        }
    }
}
