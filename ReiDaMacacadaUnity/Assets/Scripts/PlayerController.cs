using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocidade, forcaPulo;
    private SpriteRenderer spriteMacaco;
    public Rigidbody2D corpoMacaco;
    public Text txtPontos;
    public int pontos;
    private bool noChao;
   
    // Start is called before the first frame update
    void Start()
    {
        noChao = true;
        corpoMacaco = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();

        txtPontos.text = "" + pontos;
    }

    public void Movimentacao()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetButtonDown("Jump") && noChao == true)
        {
            corpoMacaco.AddForce(new Vector2(0, forcaPulo));
            noChao = false;
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
}
