using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject robion;
    public GameObject clarie;


    private void Start()
    {
        robion.SetActive(false);
        clarie.SetActive(false);
    }

    private void OnDestroy()
    {
        if (QuestManager.Instance._currentQuestName == "mission4eclipse")
        {
            robion.SetActive(true);
        }
        else if (QuestManager.Instance._currentQuestName == "mission4regen")
        {
            robion.SetActive(true);
            clarie.SetActive(true);
        }
    }
}
