using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Tutorial : MonoBehaviour
{
    public KeyCode BotaoX;
    public KeyCode BotaoY;
    public KeyCode BotaoA;
    public KeyCode BotaoB;
    public KeyCode BotaoR;
    public KeyCode BotaoL;

    public static float posX, posY, posZ;
    public float horizontalMove, SpeedWalk, forceJump, tempoForca, forca, tempo, tempoPegarBanana, tempoJogarBanana, tempoAcertarTuto, tempoErro;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int bananas, vida;
    public bool noChao, atirarAtivo, direcaoR, tutorial1, tutorial2, tutorial3, tutorial4, tutorial5, fimTutorial, tuto1Ativado, tuto1Ativado2, puloCheck, bananaTutoCheck, tiroCheck, curaVidaCheck, player1Pronto, checkPegarBanana, checkAudioJogarBanana, checkAudioAcerto, checkAudioErro;
    private Animator anim;
    public GameObject[] vidas, tutoriais;
    public GameObject  bananaObj, bananaObj2, forcaSlider, forcaSlider2, painelPronto, fimTuto, bananaInfinita, mp3Error, mp3Pulo, mp3TransicaoBtn, mp3AtivarBtn, mp3JogarBanan, mp3PegarBanana;
    public BananaTiro bananaTiro;
    public BananaTiro2 bananaTiro2;
    public ForcaBanana forcaBanana;
    public ForcaBanana2 forcaBanana2;
    public ControladorTutorial controlardorTuto;
    // Start is called before the first frame update
    void Start()
    {
        vida = 2;
        corpoMacaco = gameObject.GetComponent<Rigidbody2D>();

        forcaSlider.SetActive(false);
        forcaSlider2.SetActive(false);
        tutorial1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        horizontalMove = Input.GetAxisRaw("Horizontal");

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

        //Controle dos Tutoriais

        //TUTO1 mover
        if (tutorial1 == true)
        {
            tutoriais[0].SetActive(true);

            if (tuto1Ativado == true && tuto1Ativado2 == true)
            {
                mp3AtivarBtn.SetActive(true);
                tutoriais[0].SetActive(false);
                tutorial1 = false;
                tutorial2 = true;
                checkAudioAcerto = true;
                tempoAcertarTuto = 0.5f;
            }
        }

        //TUTO2 pular
        if (tutorial2 == true)
        {
            tutoriais[1].SetActive(true);

            if (puloCheck == true)
            {
                mp3AtivarBtn.SetActive(true);
                tutoriais[1].SetActive(false);
                tutorial2 = false;
                tutorial3 = true;
                checkAudioAcerto = true;
                tempoAcertarTuto = 0.5f;
            }
        }

        //TUTO3 pegar banana
        if (tutorial3 == true)
        {
            tutoriais[2].SetActive(true);

            if (bananaTutoCheck == true)
            {
                mp3AtivarBtn.SetActive(true);
                tutoriais[2].SetActive(false);
                tutorial3 = false;
                tutorial4 = true;
                checkAudioAcerto = true;
                tempoAcertarTuto = 0.5f;
            }
        }

        //TUTO4 atirar direita
        if (tutorial4 == true)
        {
            tutoriais[3].SetActive(true);

            if (tiroCheck == true)
            {
                mp3AtivarBtn.SetActive(true);
                tutoriais[3].SetActive(false);
                tutorial4 = false;
                tutorial5 = true;
                checkAudioAcerto = true;
                tempoAcertarTuto = 0.5f;
            }
        }

        //TUTO6 curar vida
        if (tutorial5 == true)
        {
            tutoriais[4].SetActive(true);

            if (bananas <= 2)
            {
                bananaInfinita.SetActive(true);
            }

            if (curaVidaCheck == true)
            {
                mp3AtivarBtn.SetActive(true);
                tutoriais[4].SetActive(false);
                tutorial5 = false;
                fimTutorial = true;
                checkAudioAcerto = true;
                tempoAcertarTuto = 0.5f;
            }
        }
        if (fimTutorial == true)
        {
            fimTuto.SetActive(true);

            if (Input.GetKeyDown(BotaoL) && Input.GetKeyDown(BotaoR))
            {
                mp3AtivarBtn.SetActive(true);
                painelPronto.SetActive(true);
                fimTuto.SetActive(false);
                fimTutorial = false;
                controlardorTuto.checkP1 = true;
                checkAudioAcerto = true;
                tempoAcertarTuto = 0.5f;
            }
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
    }
    public void Movimentacao(float h)
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {          
            transform.Translate(Vector2.right * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetFloat("posX", Mathf.Abs(horizontalMove));
            anim.SetBool("Parado", false);
            tuto1Ativado = true;
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetFloat("posX", Mathf.Abs(horizontalMove));
            anim.SetBool("Parado", false);
            tuto1Ativado2 = true;
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
        if (Input.GetKeyDown(BotaoY) && bananas >= 3)
        {
            vida += 1;
            bananas -= 3;
            curaVidaCheck = true;
        }
        else if (Input.GetKeyDown(BotaoY) && bananas < 3)
        {
            mp3Error.SetActive(true);
            checkAudioErro = true;
            tempoErro = 0.2f;
        }

        if (Input.GetKey(BotaoX) && bananas > 0 && direcaoR == true)
        {
            bananaTiro.forcaDistancia += 30;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            forcaSlider.SetActive(true);
            forcaSlider2.SetActive(false);
        }

        else if (Input.GetKey(BotaoX) && bananas > 0 && direcaoR == false)
        {
            bananaTiro2.forcaDistancia2 -= 30;
            bananaTiro.forcaDistancia = 0;
            forcaBanana2.forcaTiroAuxiliar += 30;
            forcaSlider.SetActive(false);
            forcaSlider2.SetActive(true);

        }
        else if (Input.GetKeyUp(BotaoX) && bananas > 0 && direcaoR == true)
        {
            mp3JogarBanan.SetActive(true);
            Instantiate(this.bananaObj, new Vector3(Player1Tutorial.posX + 1, Player1Tutorial.posY +1, Player1Tutorial.posZ + 10f), Quaternion.identity);
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
            Instantiate(this.bananaObj2, new Vector3(Player1Tutorial.posX - 1, Player1Tutorial.posY + 1, Player1Tutorial.posZ + 10f), Quaternion.identity);
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
        }

        if (vida == 2)
        {
            vidas[0].SetActive(false);
            vidas[1].SetActive(true);
            vidas[2].SetActive(true);
        }

        if (vida == 1)
        {
            vidas[0].SetActive(false);
            vidas[1].SetActive(false);
            vidas[2].SetActive(true);
        }

        if (vida == 0)
        {
            vidas[0].SetActive(false);
            vidas[1].SetActive(false);
            vidas[2].SetActive(false);

            Time.timeScale = 0;
        }
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

        if (collision.gameObject.CompareTag("TagBananaTuto"))
        {
            mp3PegarBanana.SetActive(true);
            bananas++;
            bananaTutoCheck = true;
            checkPegarBanana = true;
            tempoPegarBanana = 0.5f;
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
