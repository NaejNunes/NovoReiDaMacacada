using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownDeBananaTutorial2: MonoBehaviour
{
    public static float posicaoX, posicaoY, posicaoZ;
    public GameObject BananaTutorial, bananaInfinita;
    public Player2Tutorial player2;
    // Start is called before the first frame update
    void Start()
    {
        if (player2.tutorial3 == true)
        {
            Instantiate(this.BananaTutorial, new Vector3(SpownDeBananaTutorial2.posicaoX + 33f, SpownDeBananaTutorial2.posicaoY + 0.5f, SpownDeBananaTutorial2.posicaoZ + 10f), Quaternion.identity);
        }

        if (player2.tutorial5 == true)
        {
            Instantiate(this.BananaTutorial, new Vector3(SpownDeBananaTutorial2.posicaoX + 23f, SpownDeBananaTutorial2.posicaoY - 1.5f, SpownDeBananaTutorial2.posicaoZ + 10f), Quaternion.identity);
            bananaInfinita.SetActive(true);
            Instantiate(this.BananaTutorial, new Vector3(SpownDeBananaTutorial2.posicaoX +33f, SpownDeBananaTutorial2.posicaoY - 1.5f, SpownDeBananaTutorial2.posicaoZ + 10f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
              
    } 
}
