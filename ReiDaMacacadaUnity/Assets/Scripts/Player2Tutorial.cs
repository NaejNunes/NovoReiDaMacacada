using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Tutorial : MonoBehaviour
{
    public static float posX, posY, posZ;
    public float horizontalMove, SpeedWalk, forceJump, tempoForca, forca, tempo;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int bananas, vida;
    public bool noChao, atirarAtivo, direcaoR, tutorial1, tutorial2, tutorial3, tutorial4, tutorial5, fimTutorial, tuto1Ativado, tuto1Ativado2, puloCheck, bananaTutoCheck, tiroCheck, curaVidaCheck, player1Pronto, player2Pronto;
    private Animator anim;
    public GameObject[] vidas, tutoriais;
    public GameObject bananaObj, bananaObj2, forcaSlider, forcaSlider2, painelPronto, fimTuto, bananaInfinita;
    public AudioClip error;
    public BananaTiro1 bananaTiro1;
    public BananaTiro3 bananaTiro3;
    public ForcaBanana1 forcaBanana1;
    public ForcaBanana3 forcaBanana3;

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
        Debug.Log(bananaTiro1.forcaDistancia);
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


        if (bananaTiro1.forcaDistancia >= 1000)
        {
            bananaTiro1.forcaDistancia = 1000;
        }
        if (bananaTiro3.forcaDistancia2 <= -1000)
        {
            bananaTiro3.forcaDistancia2 = -1000;
        }

        //Controle dos Tutoriais

        //TUTO1 mover
        if (tutorial1 == true)
        {
            tutoriais[0].SetActive(true);

            if (tuto1Ativado == true && tuto1Ativado2 == true)
            {
                tutoriais[0].SetActive(false);
                tutorial1 = false;
                tutorial2 = true;
            }
        }

        //TUTO2 pular
        if (tutorial2 == true)
        {
            tutoriais[1].SetActive(true);

            if (puloCheck == true)
            {
                tutoriais[1].SetActive(false);
                tutorial2 = false;
                tutorial3 = true;
            }
        }

        //TUTO3 pegar banana
        if (tutorial3 == true)
        {
            tutoriais[2].SetActive(true);

            if (bananaTutoCheck == true)
            {
                tutoriais[2].SetActive(false);
                tutorial3 = false;
                tutorial4 = true;
            }
        }

        //TUTO4 atirar direita
        if (tutorial4 == true)
        {
            tutoriais[3].SetActive(true);

            if (tiroCheck == true)
            {
                tutoriais[3].SetActive(false);
                tutorial4 = false;
                tutorial5 = true;
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
                tutorial5 = false;
                tutoriais[4].SetActive(false);
                fimTutorial = true;
            }
        }
        if (fimTutorial == true)
        {
            fimTuto.SetActive(true);

            if (Input.GetKeyDown(KeyCode.V) && Input.GetKeyDown(KeyCode.B))
            {
                painelPronto.SetActive(true);
                fimTuto.SetActive(false);
                player1Pronto = true;
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
            tuto1Ativado = true;
        }

        else if (Input.GetAxisRaw("Horizontal2") < 0)
        {
            transform.Translate(Vector2.left * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetFloat("posX", Mathf.Abs(horizontalMove));
            anim.SetBool("Parado", false);
            tuto1Ativado2 = true;
        }
        else
        {
            anim.SetBool("Parado", true);
        }

        if (Input.GetButtonDown("Jump2") && noChao == true)
        {
            corpoMacaco.AddForce(new Vector2(0, forceJump));
        }
    }

    public void Acoes()
    {
        //RECUPERAR VIDA
        if (Input.GetKeyDown(KeyCode.M) && bananas >= 3)
        {
            vida += 1;
            bananas -= 3;
            curaVidaCheck = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && bananas < 3)
        {
            AudioSource.PlayClipAtPoint(error, Camera.main.transform.position * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.P) && bananas > 0 && direcaoR == false)
        {
            bananaTiro1.forcaDistancia += 10;
            bananaTiro3.forcaDistancia2 = 0;
            forcaBanana3.forcaTiroAuxiliar = 0;
            forcaSlider.SetActive(true);
            forcaSlider2.SetActive(false);
        }

        else if (Input.GetKey(KeyCode.P) && bananas > 0 && direcaoR == true)
        {
            bananaTiro3.forcaDistancia2 -= 10;
            bananaTiro1.forcaDistancia = 0;
            forcaBanana3.forcaTiroAuxiliar += 10;
            forcaSlider.SetActive(false);
            forcaSlider2.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.P) && bananas > 0 && direcaoR == true)
        {
            Instantiate(this.bananaObj2, new Vector3(Player2Tutorial.posX - 1, Player2Tutorial.posY + 1, Player2Tutorial.posZ + 10f), Quaternion.identity);
            bananaTiro1.forcaDistancia = 0;
            forcaBanana1.forcaTiroBanana = 0;
            bananaTiro3.forcaDistancia2 = 0;
            forcaBanana3.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider.SetActive(false);
            forcaSlider2.SetActive(false);
            tiroCheck = true;
        }
        else if (Input.GetKeyUp(KeyCode.P) && bananas > 0 && direcaoR == false)
        {
            Instantiate(this.bananaObj, new Vector3(Player2Tutorial.posX + 1, Player2Tutorial.posY + 1, Player2Tutorial.posZ + 10f), Quaternion.identity);
            bananaTiro1.forcaDistancia = 0;
            forcaBanana1.forcaTiroBanana = 0;
            bananaTiro3.forcaDistancia2 = 0;
            forcaBanana3.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider.SetActive(false);
            forcaSlider2.SetActive(false);
            tiroCheck = true;

        }

        else if (Input.GetKey(KeyCode.P) && bananas == 0)
        {
            AudioSource.PlayClipAtPoint(error, Camera.main.transform.position * Time.deltaTime);
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
            bananas++;
        }

        if (collision.gameObject.CompareTag("TagBananaTuto"))
        {
            bananas++;
            bananaTutoCheck = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TagChao") || collision.gameObject.CompareTag("TagPlataforma"))
        {
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
