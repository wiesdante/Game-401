using System.Collections;
using NPCs;
using UnityEngine;

public class Mission1EndDialogueTrigger : MonoBehaviour
{
    public GameObject yonder;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (QuestManager.Instance.mainQuestPhase == 8)
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
        yonder.GetComponent<Yonder>().Teleport(0);
        QuestManager.Instance.mainQuestPhase++;
        Destroy(this.gameObject);
    }
}
