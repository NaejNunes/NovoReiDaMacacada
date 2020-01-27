using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownDeBananaTutorial: MonoBehaviour
{
    public static float posicaoX, posicaoY, posicaoZ;
    public GameObject BananaTutorial, bananaInfinita;
    public Player1Tutorial player1;
    // Start is called before the first frame update
    void Start()
    {
        if (player1.tutorial3 == true)
        {
            Instantiate(this.BananaTutorial, new Vector3(SpownDeBananaTutorial.posicaoX - 4.8f, SpownDeBananaTutorial.posicaoY + 0.5f, SpownDeBananaTutorial.posicaoZ + 10f), Quaternion.identity);
        }     

        if (player1.tutorial5 == true)
        {
            Instantiate(this.BananaTutorial, new Vector3(SpownDeBananaTutorial.posicaoX - 4.8f, SpownDeBananaTutorial.posicaoY - 5f, SpownDeBananaTutorial.posicaoZ + 10f), Quaternion.identity);
            bananaInfinita.SetActive(true);
            Instantiate(this.BananaTutorial, new Vector3(SpownDeBananaTutorial.posicaoX + 5.2f, SpownDeBananaTutorial.posicaoY - 5f, SpownDeBananaTutorial.posicaoZ + 10f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {        
        posicaoX = transform.position.x;
        posicaoY = transform.position.y;
        posicaoZ = transform.position.z;         
    } 
}
