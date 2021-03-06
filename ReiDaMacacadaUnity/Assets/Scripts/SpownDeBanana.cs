﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownDeBanana : MonoBehaviour
{
    public int numeroRandonBanana;
    public static float posicaoX, posicaoY, posicaoZ;
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
        posicaoZ = transform.position.z;         
    }

    public void SpownBanana()
    {
        numeroRandonBanana = Random.Range(0, 5);

        switch (numeroRandonBanana)
        {
            case 0:
                Instantiate(this.objetoBanana, new Vector3(SpownDeBanana.posicaoX - 2.75f, SpownDeBanana.posicaoY + 2.3f, SpownDeBanana.posicaoZ + 10f), Quaternion.identity);
                break;

            case 1:
                Instantiate(this.objetoBanana, new Vector3(SpownDeBanana.posicaoX + 2.75f, SpownDeBanana.posicaoY + 2.3f, SpownDeBanana.posicaoZ + 10f), Quaternion.identity);
                break;

            case 2:
                Instantiate(this.objetoBanana, new Vector3(SpownDeBanana.posicaoX - 2.75f, SpownDeBanana.posicaoY - 0.3f, SpownDeBanana.posicaoZ + 10f), Quaternion.identity);
                break;

            case 3:
                Instantiate(this.objetoBanana, new Vector3(SpownDeBanana.posicaoX + 2.75f,SpownDeBanana.posicaoY - 0.3f, SpownDeBanana.posicaoZ + 10f), Quaternion.identity);
                break;

            case 4:
                Instantiate(this.objetoBanana, new Vector3(SpownDeBanana.posicaoX , SpownDeBanana.posicaoY + 1f, SpownDeBanana.posicaoZ + 10f), Quaternion.identity);
                break;
        }

    }
}
