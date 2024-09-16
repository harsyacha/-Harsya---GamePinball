using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIgameOver : MonoBehaviour
{
     public Button menu;

     private void Start()
    {
        menu.onClick.AddListener(Menu);
    }

     public void Menu()
    {
        SceneManager.LoadScene("menu");
    }


}
