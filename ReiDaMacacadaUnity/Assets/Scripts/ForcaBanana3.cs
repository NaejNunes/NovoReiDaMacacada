using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcaBanana3 : MonoBehaviour
{
    public float forcaTiroAuxiliar;
    public GameObject SliderBanana2;
    public BananaTiro3 bananaTiro3;
    public PlayerBatalha playerBatalha;
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        forcaTiroAuxiliar = bananaTiro3.forcaDistancia2;

        if (forcaTiroAuxiliar > 0 && forcaTiroAuxiliar <= 400)
        {
            SliderBanana2.GetComponent<Image>().color = Color.green;
            playerBatalha.forcaDano = 100;
        }

        else if (forcaTiroAuxiliar > 400 && forcaTiroAuxiliar <= 700)
        {
            SliderBanana2.GetComponent<Image>().color = Color.yellow;
            playerBatalha.forcaDano = 250;
        }

        else if(forcaTiroAuxiliar > 700 && forcaTiroAuxiliar <= 1000)
        {
            SliderBanana2.GetComponent<Image>().color = Color.red;
            playerBatalha.forcaDano = 400;
        }

        if (forcaTiroAuxiliar >= 1000)
        {
            forcaTiroAuxiliar = 1000;
        }

        var sliderTempo2 = transform.GetChild(1).GetComponentInChildren<Slider>();
           sliderTempo2.value = forcaTiroAuxiliar;
       
    }       
}
