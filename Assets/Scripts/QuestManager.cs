using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public CanvasGroup questListBox;
    private bool _questListBoxIsVisible;

    public TextMeshProUGUI questDescriptionText;

    private string _currentQuestName;

    private void Start()
    {
        _currentQuestName = "none";
        QuestListBoxToggle(false);
    }

    public void QuestListBoxToggle(bool visibility)
    {
        if (visibility)
        {
            questListBox.alpha = 1;
            questListBox.blocksRaycasts = true;
        }
        else
        {
            questListBox.alpha = 0;
            questListBox.blocksRaycasts = false;
        }
    }

    public void StartQuest(string questDescription, string questName)
    {
        StopAllCoroutines();
        StartCoroutine(StartQuestIfPossible(questDescription, questName));
    }

    IEnumerator StartQuestIfPossible(string questDescription, string questName)
    {
        while (Math.Abs(Time.timeScale - 1) > 0.1f)
        {
            yield return new WaitForSecondsRealtime(1f);
        }
        questDescriptionText.text = questDescription;
        QuestListBoxToggle(true);
        _currentQuestName = questName;
    }

    public void FinishQuest(string questName)
    {
        if (questName != _currentQuestName) return;
        _currentQuestName = "none";
        QuestListBoxToggle(false);
    }

    public string GetCurrentQuestName()
    {
        return _currentQuestName;
    }
}
