using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Emrenemy_Scripts
{
    public class EmrenemyBullet : MonoBehaviour
    {
        public float bulletSpeed;
        public float bulletDamage;
        
        public GameObject impactEffect;

        private void Start()
        {
            StartCoroutine(SelfDestroy(2f));
        }


        private void Update()
        {
            var transform1 = transform;
            transform1.position += transform1.right * (bulletSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Emrenemy") || other.CompareTag("EmrenemyHitbox")) return;
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().TakeDamage(bulletDamage);
                Destroy(this.gameObject);
            }
            else if (other.CompareTag("Obstacle") || other.CompareTag("MapBorder"))
            {
                Destroy(this.gameObject);
            }
        }

        public void SetupBullet(float speed, float damage, Transform target)
        {
            bulletSpeed = speed;
            bulletDamage = damage;
            var transform1 = transform;
            Vector2 direction = ((Vector2)target.transform.position - (Vector2)transform1.position).normalized;
            transform1.right = direction;
        }

        private void OnDestroy()
        {
            GameObject.Instantiate(impactEffect,transform.position,quaternion.identity);
        }

        IEnumerator SelfDestroy(float delay)
        {
            yield return new WaitForSecondsRealtime(2f);
            Destroy(this.gameObject);
        }
    }
}
