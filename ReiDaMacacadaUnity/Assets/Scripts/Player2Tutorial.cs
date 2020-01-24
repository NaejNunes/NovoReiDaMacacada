using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Tutorial : MonoBehaviour
{
    public static float posX, posY, posZ;
    public float horizontalMove, SpeedWalk, forceJump, tempoForca, forca;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int bananas, vida;
    public bool noChao, atirarAtivo, direcaoR;
    private Animator anim;
    public GameObject[] vidas;
    public GameObject  bananaObj, bananaObj2, forcaSlider, forcaSlider2;
    public AudioClip error;
    public BananaTiro bananaTiro;
    public BananaTiro2 bananaTiro2;
    public ForcaBanana forcaBanana;
    public ForcaBanana2 forcaBanana2;

    // Start is called before the first frame update
    void Start()
    {
        vida = 3;
        corpoMacaco = gameObject.GetComponent<Rigidbody2D>();

        forcaSlider.SetActive(false);
        forcaSlider2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
       
            horizontalMove = Input.GetAxisRaw("Horizontal2");

            anim = GetComponent<Animator>();

            Movimentacao(horizontalMove);

            Acoes();

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

    }

    public void Movimentacao(float h)
    {
        if (Input.GetAxisRaw("Horizontal2") > 0)
        {
            
            transform.Translate(Vector2.right * SpeedWalk * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetFloat("posX", Mathf.Abs(horizontalMove));
            anim.SetBool("Parado", false);         
        }

        else if (Input.GetAxisRaw("Horizontal2") < 0)
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

        if (Input.GetKey(KeyCode.O) && bananas > 0 && direcaoR == true)
        {
            bananaTiro.forcaDistancia += 10;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            forcaSlider.SetActive(true);
            forcaSlider2.SetActive(false);
        }

        else if (Input.GetKey(KeyCode.H) && bananas > 0 && direcaoR == false)
        {
            bananaTiro2.forcaDistancia2 -= 10;
            bananaTiro.forcaDistancia = 0;
            forcaBanana2.forcaTiroAuxiliar += 10;
            forcaSlider.SetActive(false);
            forcaSlider2.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.H) && bananas > 0 && direcaoR == true)
        {
            Instantiate(this.bananaObj, new Vector3(PlayerBatalha.posX + 1, PlayerBatalha.posY +1, PlayerBatalha.posZ + 10f), Quaternion.identity);
            bananaTiro.forcaDistancia = 0;
            forcaBanana.forcaTiroBanana = 0;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.O) && bananas > 0 && direcaoR == false)
        {
            Instantiate(this.bananaObj2, new Vector3(PlayerBatalha.posX - 1, PlayerBatalha.posY + 1, PlayerBatalha.posZ + 10f), Quaternion.identity);
            bananaTiro.forcaDistancia = 0;
            forcaBanana.forcaTiroBanana = 0;
            bananaTiro2.forcaDistancia2 = 0;
            forcaBanana2.forcaTiroAuxiliar = 0;
            bananas--;
            forcaSlider2.SetActive(false);
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
        }
    }
}
