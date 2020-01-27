using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Tutorial : MonoBehaviour
{
    public static float posX, posY, posZ;
    public float horizontalMove, SpeedWalk, forceJump, tempoForca, forca, tempo;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int bananas, vida;
    public bool noChao, atirarAtivo, direcaoR, tutorial1, tutorial2, tutorial3, tutorial4, tutorial5, fimTutorial, tuto1Ativado, tuto1Ativado2, puloCheck, bananaTutoCheck, tiroCheck, curaVidaCheck, player1Pronto;
    private Animator anim;
    public GameObject[] vidas, tutoriais;
    public GameObject  bananaObj, bananaObj2, forcaSlider, forcaSlider2, painelPronto, fimTuto, bananaInfinita;
    public AudioClip error;
    public BananaTiro bananaTiro;
    public BananaTiro2 bananaTiro2;
    public ForcaBanana forcaBanana;
    public ForcaBanana2 forcaBanana2;

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
                tutoriais[4].SetActive(false);
                tutorial5 = false;
                fimTutorial = true;
            }
        }
        if (fimTutorial == true)
        {
            fimTuto.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.X))
            {
                painelPronto.SetActive(true);
                fimTuto.SetActive(false);
                fimTutorial = false;
                player1Pronto = true;
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

        if (Input.GetButtonDown("Jump") && noChao == true)
        {
            corpoMacaco.AddForce(new Vector2(0, forceJump));
        }      
    }

    public void Acoes()
    {
        //RECUPERAR VIDA
        if (Input.GetKeyDown(KeyCode.I) && bananas >= 3)
        {
            vida += 1;
            bananas -= 3;
            curaVidaCheck = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && bananas < 3)
        {
            AudioSource.PlayClipAtPoint(error, Camera.main.transform.position * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.O) && bananas > 0 && direcaoR == true)
        {
            bananaTiro.forcaDistancia += 10;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            forcaSlider.SetActive(true);
            forcaSlider2.SetActive(false);
        }

        else if (Input.GetKey(KeyCode.O) && bananas > 0 && direcaoR == false)
        {
            bananaTiro2.forcaDistancia2 -= 10;
            bananaTiro.forcaDistancia = 0;
            forcaBanana2.forcaTiroAuxiliar += 10;
            forcaSlider.SetActive(false);
            forcaSlider2.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.O) && bananas > 0 && direcaoR == true)
        {
            Instantiate(this.bananaObj, new Vector3(Player1Tutorial.posX + 1, Player1Tutorial.posY +1, Player1Tutorial.posZ + 10f), Quaternion.identity);
            bananaTiro.forcaDistancia = 0;
            forcaBanana.forcaTiroBanana = 0;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider.SetActive(false);
            tiroCheck = true;
        }
        else if (Input.GetKeyUp(KeyCode.O) && bananas > 0 && direcaoR == false)
        {
            Instantiate(this.bananaObj2, new Vector3(Player1Tutorial.posX - 1, Player1Tutorial.posY + 1, Player1Tutorial.posZ + 10f), Quaternion.identity);
            bananaTiro.forcaDistancia = 0;
            forcaBanana.forcaTiroBanana = 0;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider2.SetActive(false);
            tiroCheck = true;

        }

        else if (Input.GetKey(KeyCode.O) && bananas == 0)
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
