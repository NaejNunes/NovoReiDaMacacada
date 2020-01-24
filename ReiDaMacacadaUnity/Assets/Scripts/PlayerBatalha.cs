using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBatalha : MonoBehaviour
{
    public static float posX, posY, posZ;
    public float horizontalMove, SpeedWalk, forceJump, tempoForca, forca;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int bananas, vida;
    private bool noChao, atirarAtivo;
    private Animator anim;
    public TempoIniciar tempoIniciar;
    public GameObject[] vidas;
    public GameObject painelVencedor, bananaObj, forcaSlider;
    public AudioClip error;
    public BananaTiro bananaTiro;
    public ForcaBanana forcaBanana;

    // Start is called before the first frame update
    void Start()
    {
        vida = 3;
        noChao = true;
        corpoMacaco = gameObject.GetComponent<Rigidbody2D>();

        forcaSlider.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        if (tempoIniciar.comecarJogo == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            anim = GetComponent<Animator>();

            Movimentacao(horizontalMove);

            Acoes();

            txtPontos.text = "" + bananas;       
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

        if (Input.GetButtonDown("Jump") && noChao == true)
        {
            corpoMacaco.AddForce(new Vector2(0, forceJump));
        }
    }

    public void Acoes()
    {
        //RECUPERAR VIDA
        if (Input.GetKeyDown(KeyCode.I) && bananas >= 5)
        {
            vida += 1;
        }
        else if (Input.GetKeyDown(KeyCode.I) && bananas < 3)
        {
            AudioSource.PlayClipAtPoint(error, Camera.main.transform.position * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.O) && bananas > 0)
        {
            bananaTiro.forcaDistancia += 10;
            forcaSlider.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.O) && bananas > 0)
        {
            Instantiate(this.bananaObj, new Vector3(PlayerBatalha.posX, PlayerBatalha.posY, PlayerBatalha.posZ + 10f), Quaternion.identity);
            bananaTiro.forcaDistancia = 0;
            forcaBanana.forcaTiroBanana = 0;
            bananas--;
            forcaSlider.SetActive(false);
            Debug.Log(bananaTiro.forcaDistancia);

        }

        else if (Input.GetKey(KeyCode.O) && bananas == 0)
        {
            AudioSource.PlayClipAtPoint(error, Camera.main.transform.position * Time.deltaTime);
        }
        //JOGAR BANANA
        /*
        if (Input.GetKeyDown(KeyCode.O) && bananas >= 1)
        {
            Debug.Log(tempoForca);
            tempoForca = 0;
            atirarAtivo = true;

            if (tempoForca >= 0 && tempoForca <= 5)
            {
                bananaTiro.forcaDistancia = 50;

                if (Input.GetKeyUp(KeyCode.O))
                {
                    bananas--;
                    Instantiate(this.bananaObj, new Vector3(PlayerBatalha.posX, PlayerBatalha.posY, PlayerBatalha.posZ + 10f), Quaternion.identity);
                    atirarAtivo = false;

                }
            }

            if (tempoForca >5 && tempoForca <=10)
            {
                bananaTiro.forcaDistancia = 200;

                if (Input.GetKeyUp(KeyCode.O))
                {
                    bananas--;
                    Instantiate(this.bananaObj, new Vector3(PlayerBatalha.posX, PlayerBatalha.posY, PlayerBatalha.posZ + 10f), Quaternion.identity);
                    atirarAtivo = false;

                }
            }

            if (tempoForca >10 && tempoForca <= 15)
            {
                bananaTiro.forcaDistancia = 400;

                if (Input.GetKeyUp(KeyCode.O))
                {
                    bananas--;
                    Instantiate(this.bananaObj, new Vector3(PlayerBatalha.posX, PlayerBatalha.posY, PlayerBatalha.posZ + 10f), Quaternion.identity);
                    atirarAtivo = false;

                }
            }         
        }
        */

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

            painelVencedor.SetActive(true);
        }


    } 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TagBanana"))
        {
            bananas++;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TagChao"))
        {
            noChao = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        noChao = false;
    }
}
