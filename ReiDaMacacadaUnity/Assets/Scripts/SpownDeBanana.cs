﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownDeBanana : MonoBehaviour
{
    public int numeroRandonBanana;
    public static float posicaoX, posicaoY;
    public GameObject objetoBanana;

    // Start is called before the first frame update
    void Start()
    {
        SpownBanana();
    }

    // Update is called once per frame
    void Update()
    {
        posicaoX = transform.position.x;
        posicaoY = transform.position.y;

       
    }

    public void SpownBanana()
    {
        numeroRandonBanana = Random.Range(0, 5);

        switch (numeroRandonBanana)
        {
            case 0:
                Instantiate(this.objetoBanana, new Vector2(SpownDeBanana.posicaoX - 5.5f, SpownDeBanana.posicaoY + 3.2f), Quaternion.identity);
                break;

            case 1:
                Instantiate(this.objetoBanana, new Vector2(SpownDeBanana.posicaoX + 5.5f, SpownDeBanana.posicaoY + 3.2f), Quaternion.identity);
                break;

            case 2:
                Instantiate(this.objetoBanana, new Vector2(SpownDeBanana.posicaoX - 5.5f, SpownDeBanana.posicaoY - 1f), Quaternion.identity);
                break;

            case 3:
                Instantiate(this.objetoBanana, new Vector2(SpownDeBanana.posicaoX + 5.5f, SpownDeBanana.posicaoY - 1f), Quaternion.identity);
                break;

            case 4:
                Instantiate(this.objetoBanana, new Vector2(SpownDeBanana.posicaoX , SpownDeBanana.posicaoY + 0.9f), Quaternion.identity);
                break;
        }

    }
}
