using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTiro : MonoBehaviour
{
    public float forceBanana, forcaDistancia;
    public Rigidbody2D  rbBanana;

    // Start is called before the first frame update
    void Start()
    {       
            rbBanana.AddForce(new Vector2(forcaDistancia, forceBanana));
    }

    // Update is called once per frame
    void Update()
    {
        if (forcaDistancia >= 1000)
        {
            forcaDistancia = 1000;
        }
        //INSTANCIA A BANANA E QUANDO MAIS SEGURAR MAIS AUMENTA A FORCA
    }
}
