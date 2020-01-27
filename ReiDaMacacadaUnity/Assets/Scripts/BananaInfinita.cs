using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaInfinita : MonoBehaviour
{
    public static float posicaoX, posicaoY, posicaoZ;
    public GameObject bananaInfinita;
    public Player2Tutorial player2;
    public Player1Tutorial player1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posicaoX = transform.position.x;
        posicaoY = transform.position.y;
        posicaoZ = transform.position.z;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player1Tutorial")))
        {
            player2.bananas++;
            gameObject.SetActive(false);
        }

        if ((collision.gameObject.CompareTag("Player2Tutorial")))
        {
            player2.bananas++;
            gameObject.SetActive(false);
        }
    }    
}
