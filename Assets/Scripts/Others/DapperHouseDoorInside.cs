using UnityEngine;

public class DapperHouseDoorInside : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position =
                GameObject.FindWithTag("DapperHouseExitPoint").gameObject.transform.position;
        }
    }
}
