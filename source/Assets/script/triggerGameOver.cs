using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerGameOver : MonoBehaviour
{
    public Collider bola;
    public GameObject game;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            game.SetActive(true);
        }
    }
}
