using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reaunudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPause.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reaunudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPause.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
}
