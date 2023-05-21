using System.Collections;
using UnityEngine;

public class GameStartDialogueTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<DialogueStarter>().TriggerDialogue(0);
            StartCoroutine(FunctionsAfterDialogue());
        }
    }

    IEnumerator FunctionsAfterDialogue()
    {
        while (DialogueManager.Instance.inDialogue)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
