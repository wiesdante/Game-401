using UnityEngine;

public class DapperHouseDoorOutside : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (QuestManager.Instance.mainQuestPhase == 8)
            {
                other.gameObject.transform.position =
                    GameObject.FindWithTag("DapperHouseSpawnPoint").gameObject.transform.position;
                QuestManager.Instance.FinishQuest("sleepaftermission1");
            }
            else
            {
                other.gameObject.transform.position =
                    GameObject.FindWithTag("DapperHouseEnterPoint").gameObject.transform.position;
            }
            
        }
    }
}
