using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Collider bola;
    public Material materialMati;
    public Material materialNyala;

    private Renderer switchRenderer;
    public float score;
    public ScoreManager scoreManager;


    private void Start()
    {
        switchRenderer = GetComponent<Renderer>();

        if (switchRenderer != null)
        {
            switchRenderer.material = materialMati;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Debug.Log("Bola kena switch!");

            if (switchRenderer != null)
            {
                switchRenderer.material = materialNyala;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == bola)
        {
            Debug.Log("Bola keluar dari switch!");

            if (switchRenderer != null)
            {
                switchRenderer.material = materialMati;
            }
        }
        scoreManager.AddScore(score);

    }
}
