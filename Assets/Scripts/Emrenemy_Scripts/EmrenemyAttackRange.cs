using UnityEngine;

namespace Emrenemy_Scripts
{
    public class EmrenemyAttackRange : MonoBehaviour
    {
        public Emrenemy emrenemy;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                emrenemy.SetSpeed(0.1f);
                emrenemy.playerIsInAttackRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                emrenemy.SetSpeed(emrenemy.moveSpeed);
                emrenemy.playerIsInAttackRange = false;
            }
        }
    }
}
