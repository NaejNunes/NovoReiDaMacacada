using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoControlador : MonoBehaviour
{
    public float tempoJogo;
    public GameObject tempo;
    public TempoIniciar tempoIniciar;

    // Start is called before the first frame update
    void Start()
    {
        tempoJogo = 120f;        
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (tempoIniciar.comecarJogo == true)
            {
                tempoJogo -= Time.deltaTime;

                if (tempoJogo <= 60f)
                {
                    tempo.GetComponent<Image>().color = Color.yellow;
                }

                if (tempoJogo <= 30f)
                {
                    tempo.GetComponent<Image>().color = Color.red;
                }
                if (tempoJogo <= 0)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
               
                var sliderTempo = transform.GetChild(0).GetComponentInChildren<Slider>();
                sliderTempo.value = tempoJogo;
            }          
        }       
    }
}
