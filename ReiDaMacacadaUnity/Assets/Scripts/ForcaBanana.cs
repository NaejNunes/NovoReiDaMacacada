using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcaBanana : MonoBehaviour
{
    public float forcaTiroBanana;
    public GameObject SliderBanana;
    public BananaTiro bananaTiro;

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
        }

        else if (forcaTiroBanana > 400 && forcaTiroBanana <= 700)
        {
            SliderBanana.GetComponent<Image>().color = Color.yellow;
        }

        else if(forcaTiroBanana > 700 && forcaTiroBanana <= 1000)
        {
            SliderBanana.GetComponent<Image>().color = Color.red;
        }

        if (forcaTiroBanana >= 1000)
        {
            forcaTiroBanana = 1000;
        }       

        var sliderTempo = transform.GetChild(0).GetComponentInChildren<Slider>();
           sliderTempo.value = forcaTiroBanana;
       
    }       
}
