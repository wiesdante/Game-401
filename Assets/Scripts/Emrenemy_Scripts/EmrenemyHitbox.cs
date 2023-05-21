using System;
using UnityEngine;

namespace Emrenemy_Scripts
{
    public class EmrenemyHitbox : MonoBehaviour
    {
        public Emrenemy emrenemy;
    
        public void TakeDamage(float amount)
        {
            emrenemy.TakeDamage(amount);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().TakeDamage(emrenemy.bulletDamage*2);
            }
        }
    }
}
