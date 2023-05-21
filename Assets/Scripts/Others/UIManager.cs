using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI pressEToInteractText;

    private void Start()
    {
        pressEToInteractText.enabled = false;
    }

    public void ShowInteractionText(bool show)
    {
        pressEToInteractText.enabled = show;
    }
}
