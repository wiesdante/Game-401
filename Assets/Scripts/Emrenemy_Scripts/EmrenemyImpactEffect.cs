using System.Collections;
using UnityEngine;

namespace Emrenemy_Scripts
{
    public class EmrenemyImpactEffect : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(SelfDestroy(0.3f));
        }

        IEnumerator SelfDestroy(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            Destroy(this.gameObject);
        }
    }
}
