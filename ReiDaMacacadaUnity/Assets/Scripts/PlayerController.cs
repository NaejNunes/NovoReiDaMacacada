using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove, SpeedWalk, forceJump;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int pontos;
    private bool noChao;
    private Animator anim;
    public TempoIniciar tempoIniciar;
    // Start is called before the first frame update
    void Start()
    {
        noChao = true;
        corpoMacaco = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoIniciar.comecarJogo == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            anim = GetComponent<Animator>();

            Movimentacao(horizontalMove);

            txtPontos.text = "" + pontos;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TagBanana"))
        {
            pontos = pontos + 1;
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
