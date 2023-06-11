using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void PlayButtonFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        BGMManager.Instance.ChangeMusic();
    }

    public void QuitButtonFunction()
    {
        Application.Quit();
    }
}
