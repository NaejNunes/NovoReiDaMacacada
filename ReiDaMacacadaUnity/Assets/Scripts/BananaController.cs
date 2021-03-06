﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    public SpownDeBanana spownBanana;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1Batalha"))
        {          
            spownBanana.SpownBanana();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player2Batalha"))
        {
            spownBanana.SpownBanana();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player1Tutorial"))
        {            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player2Tutorial"))
        {
            Destroy(gameObject);
        }
       
    }
}
