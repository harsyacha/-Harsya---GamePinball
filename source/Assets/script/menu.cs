using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button play;
    public Button exit;

    private void Start()
    {
        play.onClick.AddListener(PlayGame);
        exit.onClick.AddListener(Exit);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("playing");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
