using UnityEngine;

public class DapperHouseDoorOutside : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position =
                GameObject.FindWithTag("DapperHouseEnterPoint").gameObject.transform.position;
        }
    }
}
