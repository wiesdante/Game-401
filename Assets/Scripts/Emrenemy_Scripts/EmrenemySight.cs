using UnityEngine;

namespace Emrenemy_Scripts
{
    public class EmrenemySight : MonoBehaviour
    {
        public Emrenemy emrenemy;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                emrenemy.SetTarget(other.transform);
                emrenemy.IncreaseChaseMeter(1);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                emrenemy.IncreaseChaseMeter(-1);
            }
        }
    }
}
