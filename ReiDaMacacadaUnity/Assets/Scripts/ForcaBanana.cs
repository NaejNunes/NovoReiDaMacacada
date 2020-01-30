using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcaBanana : MonoBehaviour
{
    public float forcaTiroBanana;
    public GameObject SliderBanana;
    public BananaTiro bananaTiro;
    public PlayerBatalha2 playerBatalha;

    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        forcaTiroBanana = bananaTiro.forcaDistancia;

        if (forcaTiroBanana > 0 && forcaTiroBanana <= 400)
        {
            SliderBanana.GetComponent<Image>().color = Color.green;
            playerBatalha.forcaDano = 100;
        }

        else if (forcaTiroBanana > 400 && forcaTiroBanana <= 700)
        {
            SliderBanana.GetComponent<Image>().color = Color.yellow;
            playerBatalha.forcaDano = 250;
        }

        else if(forcaTiroBanana > 700 && forcaTiroBanana <= 1000)
        {
            SliderBanana.GetComponent<Image>().color = Color.red;
            playerBatalha.forcaDano = 400;
        }

        if (forcaTiroBanana >= 1000)
        {
            forcaTiroBanana = 1000;
        }

        var sliderTempo = transform.GetChild(0).GetComponentInChildren<Slider>();
           sliderTempo.value = forcaTiroBanana;
       
    }       
}
