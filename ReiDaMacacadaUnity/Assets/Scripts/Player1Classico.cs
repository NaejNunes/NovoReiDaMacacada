using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Classico : MonoBehaviour
{
    public KeyCode BotaoA;
    public float horizontalMove, SpeedWalk, forceJump, tempoPegarBanana;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int bananas;
    public bool noChao, puloCheck, checkPegarBanana;
    private Animator anim;
    public GameObject mp3Pulo, mp3PegarBanana;
    public TempoIniciar tempoIniciar;
    public TempoControlador tempoControlador;

    // Start is called before the first frame update
    void Start()
    {
        bananas = 0;
        corpoMacaco = gameObject.GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("PontosP1", bananas);
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoIniciar.comecarJogo == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            anim = GetComponent<Animator>();

            Movimentacao(horizontalMove);

            txtPontos.text = "" + bananas;

            //TEMPO PARA SOM DE PEGAR A BANANA ACABAR
            if (checkPegarBanana == true)
            {
                tempoPegarBanana -= Time.deltaTime;

                if (tempoPegarBanana <= 0)
                {
                    mp3PegarBanana.SetActive(false);
                    checkPegarBanana = false;
                }
            } 
            

        }
    }
     
    public void Movimentacao(float h)
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetFloat("posX", Mathf.Abs(horizontalMove));
            anim.SetBool("Parado", false);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetFloat("posX", Mathf.Abs(horizontalMove));
            anim.SetBool("Parado", false);
        }
        else
        {
            anim.SetBool("Parado", true);
        }

        if (Input.GetKeyDown(BotaoA) && noChao == true)
        {
            mp3Pulo.SetActive(true);
            corpoMacaco.AddForce(new Vector2(0, forceJump));
        }
    }

    public void SalvarBananas()
    {
        PlayerPrefs.SetInt("PontosP1", bananas);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TagBanana"))
        {
            mp3PegarBanana.SetActive(true);
            bananas++;
            checkPegarBanana = true;
            tempoPegarBanana = 0.5f;
            SalvarBananas();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TagChao") || collision.gameObject.CompareTag("TagPlataforma"))
        {
            mp3Pulo.SetActive(false);
            noChao = true;
        }       
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TagChao") || collision.gameObject.CompareTag("TagPlataforma"))
        {
            noChao = false;
            puloCheck = true;
        }
    }
}
