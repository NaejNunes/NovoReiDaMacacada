using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoIniciar : MonoBehaviour
{
    public float tempoInicio;
    public bool comecarJogo, somativado;
    public int tempoInteiro;
    public Text txtContagemRegre;
    public GameObject painelContagem, spowBanana;
    public AudioClip beep, sirene, temaJogo;

    // Start is called before the first frame update
    void Start()
    {
        comecarJogo = false;
        tempoInicio = 3.5f;
        painelContagem.SetActive(true);
        spowBanana.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempoInteiro = Convert.ToInt32(tempoInicio);

        txtContagemRegre.text = "" + Convert.ToInt32(tempoInicio);
        tempoInicio -= Time.deltaTime;

        if (tempoInicio > 3.1 && tempoInicio < 3.2) 
        {
            AudioSource.PlayClipAtPoint(beep, Camera.main.transform.position * Time.deltaTime);
        }

        else if (tempoInicio > 2.1 && tempoInicio < 2.2)
        {
            AudioSource.PlayClipAtPoint(beep, Camera.main.transform.position * Time.deltaTime);
        }

        else if (tempoInicio > 1.1 && tempoInicio < 1.2)
        {
            AudioSource.PlayClipAtPoint(beep, Camera.main.transform.position * Time.deltaTime);
        }

        else if (tempoInicio > 0.1 && tempoInicio < 0.2)
        {
            AudioSource.PlayClipAtPoint(sirene, Camera.main.transform.position * Time.deltaTime);
        }


        if (tempoInicio < 0)
        {
            comecarJogo = true;
            painelContagem.SetActive(false);
            spowBanana.SetActive(true);
            AudioSource.PlayClipAtPoint(temaJogo, Camera.main.transform.position * Time.deltaTime);
        }
    }
}
