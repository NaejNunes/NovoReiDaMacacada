using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBatalha2 : MonoBehaviour
{
    public KeyCode BotaoX;
    public KeyCode BotaoY;
    public KeyCode BotaoA;
    public KeyCode BotaoB;
    public KeyCode BotaoR;
    public KeyCode BotaoL;

    public static float posX, posY, posZ;
    public float horizontalMove, SpeedWalk, forceJump, tempoForca, forca, tempo, tempoPegarBanana, tempoJogarBanana, tempoAcertarTuto, tempoErro, tempoRecupVida, tempoAudioDano, forcaDano, tempoDano;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int bananas, vida;
    public bool noChao, atirarAtivo, direcaoR, puloCheck, tiroCheck, curaVidaCheck, checkPegarBanana, checkAudioJogarBanana, checkAudioAcerto, checkAudioErro, checkAudioRecupVida, checkAudioDano, checkDano;
    private Animator anim;
    public GameObject[] vidas;
    public GameObject bananaObj, bananaObj2, forcaSlider, forcaSlider2, mp3Error, mp3Pulo, mp3TransicaoBtn, mp3AtivarBtn, mp3JogarBanan, mp3PegarBanana, mp3RecupVida, mp3audioDano;
    public BananaTiro1 bananaTiro;
    public BananaTiro3 bananaTiro2;
    public ForcaBanana1 forcaBanana;
    public ForcaBanana3 forcaBanana2;
    public Color corDano;
    public TempoIniciar tempoIniciar;


    // Start is called before the first frame update
    void Start()
    {
        vida = 3;

        corpoMacaco = gameObject.GetComponent<Rigidbody2D>();

        AtualizarVida();

        forcaSlider.SetActive(false);
        forcaSlider2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoIniciar.comecarJogo == true)
        {
            posX = transform.position.x;
            posY = transform.position.y;
            posZ = transform.position.z;

            horizontalMove = Input.GetAxisRaw("Horizontal2");

            anim = GetComponent<Animator>();

            Movimentacao(horizontalMove);

            Acoes();
            ControladorVida();

            txtPontos.text = "" + bananas;

            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                direcaoR = false;
            }

            else if (GetComponent<SpriteRenderer>().flipX == false)
            {
                direcaoR = true;
            }

            if (bananaTiro.forcaDistancia >= 1000)
            {
                bananaTiro.forcaDistancia = 1000;
            }
            if (bananaTiro2.forcaDistancia2 <= -1000)
            {
                bananaTiro2.forcaDistancia2 = -1000;
            }

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

            //TEMPO PARA SOM DE JOGAR A BANANA ACABAR
            if (checkAudioJogarBanana == true)
            {
                tempoJogarBanana -= Time.deltaTime;

                if (tempoJogarBanana <= 0)
                {
                    mp3JogarBanan.SetActive(false);
                    checkAudioJogarBanana = false;
                }
            }

            //TEMPO PARA PARAR O SOM DO TUTORIAL CERTO
            if (checkAudioAcerto == true)
            {
                tempoAcertarTuto -= Time.deltaTime;

                if (tempoAcertarTuto <= 0)
                {
                    mp3AtivarBtn.SetActive(false);
                    checkAudioAcerto = false;
                }
            }

            //TEMPO PARA PARAR O SOM DO ERRO
            if (checkAudioErro == true)
            {
                tempoErro -= Time.deltaTime;

                if (tempoErro <= 0)
                {
                    mp3Error.SetActive(false);
                    checkAudioErro = false;
                }
            }

            //TEMPO PARA PARAR O SOM RECUPERAR VIDA
            if (checkAudioRecupVida == true)
            {
                tempoRecupVida -= Time.deltaTime;

                if (tempoRecupVida <= 0)
                {
                    mp3RecupVida.SetActive(false);
                    checkAudioRecupVida = false;
                }
            }

            //TEMPO PARA PARAR O SOM DE DANO
            if (checkAudioDano == true)
            {
                tempoAudioDano -= Time.deltaTime;

                if (tempoAudioDano <= 0)
                {
                    mp3audioDano.SetActive(false);
                    checkAudioDano = false;
                }
            }

            //TEMPO PARA PARAR DANO
            if (checkDano == true)
            {
                tempoDano -= Time.deltaTime;

                if (tempoDano <= 0)
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                    checkDano = false;
                }
            }

            //LIMITADOR DE VIDA
            if (vida > 3)
            {
                vida = 3;
            }
            if (vida < 0)
            {
                vida = 0;
            }

        }
    }
        
    public void Movimentacao(float h)
    {
        if (Input.GetAxisRaw("Horizontal2") > 0)
        {
            transform.Translate(Vector2.right * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetFloat("posX", Mathf.Abs(horizontalMove));
            anim.SetBool("Parado", false);
        }

        else if (Input.GetAxisRaw("Horizontal2") < 0)
        {
            transform.Translate(Vector2.left * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
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

    public void Acoes()
    {
        //RECUPERAR VIDA
        if (Input.GetKeyDown(BotaoY) && bananas >= 3 && vida < 3)
        {
            mp3RecupVida.SetActive(true);
            vida += 1;
            bananas -= 3;
            tempoRecupVida = 0.5f;
            curaVidaCheck = true;
            checkAudioRecupVida = true;
        }
        else if (Input.GetKeyDown(BotaoY) && bananas < 3)
        {
            mp3Error.SetActive(true);
            checkAudioErro = true;
            tempoErro = 0.2f;
        }

        if (Input.GetKey(BotaoX) && bananas > 0 && direcaoR == true)
        {
            bananaTiro.forcaDistancia -= 30;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana.forcaTiroBanana += 30;
            forcaSlider.SetActive(true);
            forcaSlider2.SetActive(false);
        }

        else if (Input.GetKey(BotaoX) && bananas > 0 && direcaoR == false)
        {
            bananaTiro2.forcaDistancia2 += 30;
            bananaTiro.forcaDistancia = 0;
            forcaSlider.SetActive(false);
            forcaSlider2.SetActive(true);

        }

        else if (Input.GetKeyUp(BotaoX) && bananas > 0 && direcaoR == true)
        {
            mp3JogarBanan.SetActive(true);
            Instantiate(this.bananaObj, new Vector3(PlayerBatalha2.posX - 0.8f, PlayerBatalha2.posY + 0.6f, PlayerBatalha2.posZ + 10f), Quaternion.identity);
            bananaTiro.forcaDistancia = 0;
            forcaBanana.forcaTiroBanana = 0;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider.SetActive(false);
            tiroCheck = true;
            checkAudioJogarBanana = true;
            tempoJogarBanana = 0.2f;
        }
        else if (Input.GetKeyUp(BotaoX) && bananas > 0 && direcaoR == false)
        {
            mp3JogarBanan.SetActive(true);
            Instantiate(this.bananaObj2, new Vector3(PlayerBatalha2.posX + 0.8f, PlayerBatalha2.posY + 0.6f, PlayerBatalha2.posZ + 10f), Quaternion.identity);
            bananaTiro.forcaDistancia = 0;
            forcaBanana.forcaTiroBanana = 0;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider2.SetActive(false);
            tiroCheck = true;
            checkAudioJogarBanana = true;
            tempoJogarBanana = 0.2f;
        }

        else if (Input.GetKeyUp(BotaoX) && bananas == 0)
        {
            mp3Error.SetActive(true);
            checkAudioErro = true;
            tempoErro = 0.2f;
        }
    }

    public void ControladorVida()
    {
        if (vida == 3)
        {
            vidas[0].SetActive(true);
            vidas[1].SetActive(true);
            vidas[2].SetActive(true);
            AtualizarVida();
        }

        if (vida == 2)
        {
            vidas[0].SetActive(false);
            vidas[1].SetActive(true);
            vidas[2].SetActive(true);
            AtualizarVida();
        }

        if (vida == 1)
        {
            vidas[0].SetActive(false);
            vidas[1].SetActive(false);
            vidas[2].SetActive(true);
            AtualizarVida();
        }

        if (vida == 0)
        {
            vidas[0].SetActive(false);
            vidas[1].SetActive(false);
            vidas[2].SetActive(false);

            AtualizarVida();
            SceneManager.LoadScene("FimBatalha");
         }
    }

    public void AtualizarVida()
    {
        PlayerPrefs.SetInt("VidaP2", vida);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TagBanana"))
        {
            mp3PegarBanana.SetActive(true);
            bananas++;
            checkPegarBanana = true;
            tempoPegarBanana = 0.5f;
        }

        if (collision.gameObject.CompareTag("TagBananaP1R"))
        {
            mp3audioDano.SetActive(true);
            GetComponent<SpriteRenderer>().color = corDano;
            corpoMacaco.AddForce(new Vector2(forcaDano, 0));                      
            vida--;
            tempoAudioDano = 0.2f;
            tempoDano = 0.5f;
            checkAudioDano = true;
            checkDano = true;
        }

        if (collision.gameObject.CompareTag("TagBananaP1L"))
        {
            mp3audioDano.SetActive(true);
            GetComponent<SpriteRenderer>().color = corDano;
            corpoMacaco.AddForce(new Vector2(forcaDano, 0));
            vida--;
            tempoAudioDano = 0.2f;
            tempoDano = 0.5f;
            checkAudioDano = true;
            checkDano = true;
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
