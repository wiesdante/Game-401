using UnityEngine;

public class RegenEntrance : MonoBehaviour
{
    public Transform regenSpawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (QuestManager.Instance.mainQuestPhase == 15 && other.CompareTag("Player"))
        {
            other.transform.position = regenSpawnPoint.transform.position;
        }
    }
}
