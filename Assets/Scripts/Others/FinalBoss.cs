using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject robion;


    private void Start()
    {
        robion.SetActive(false);

    }

    private void OnDestroy()
    {
        robion.SetActive(true);

    }
}
