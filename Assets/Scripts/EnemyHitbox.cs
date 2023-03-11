using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitbox : MonoBehaviour
{

    public Enemy enemy;

    public void TakeDamage(float amount)
    {
        enemy.TakeDamage(amount);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
