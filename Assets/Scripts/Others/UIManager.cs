using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI pressEToInteractText;

    public TextMeshProUGUI weaponText;
    public GameObject map;
    private bool _mapIsVisible;

    private void Start()
    {
        pressEToInteractText.enabled = false;
    }

    public void ShowInteractionText(bool show)
    {
        pressEToInteractText.enabled = show;
    }

    public void SetWeaponText(string text)
    {
        weaponText.text = text;
    }

    public void ToggleMap()
    {
        if (_mapIsVisible)
        {
            _mapIsVisible = false;
            map.SetActive(false);
        }
        else
        {
            _mapIsVisible = true;
            map.SetActive(true);
        }
    }
}
