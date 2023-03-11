using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    
    private float _bulletDamage;
    
    void Update()
    {
        var transform1 = transform;
        transform1.position += transform1.right * (bulletSpeed * Time.deltaTime);
    }

    public void SetBulletDamage(float damage)
    {
        _bulletDamage = damage;
    }

    private void OnEnable()
    {
        StartCoroutine(SelfDestroy(2f));
    }

    IEnumerator SelfDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHitbox>().TakeDamage(_bulletDamage);
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
}
