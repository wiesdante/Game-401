using Emrenemy_Scripts;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{

    public Enemy enemy;
    public Emrenemy emrenemy;

    public void TakeDamage(float amount)
    {
        enemy.TakeDamage(amount);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDamage(emrenemy.bulletDamage*2);
        }
    }
}
