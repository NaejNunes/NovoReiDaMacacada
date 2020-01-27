using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcaBanana3 : MonoBehaviour
{
    public float forcaTiroAuxiliar;
    public GameObject SliderBanana2;

    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
       
        if (forcaTiroAuxiliar > 0 && forcaTiroAuxiliar <= 400)
        {
            SliderBanana2.GetComponent<Image>().color = Color.green;
        }

        else if (forcaTiroAuxiliar > 400 && forcaTiroAuxiliar <= 700)
        {
            SliderBanana2.GetComponent<Image>().color = Color.yellow;
        }

        else if(forcaTiroAuxiliar > 700 && forcaTiroAuxiliar <= 1000)
        {
            SliderBanana2.GetComponent<Image>().color = Color.red;
        }

        if (forcaTiroAuxiliar >= 1000)
        {
            forcaTiroAuxiliar = 1000;
        }

        var sliderTempo2 = transform.GetChild(1).GetComponentInChildren<Slider>();
           sliderTempo2.value = forcaTiroAuxiliar;
       
    }       
}
