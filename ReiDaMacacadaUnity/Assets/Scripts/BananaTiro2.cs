using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTiro2 : MonoBehaviour
{
    public float forceBanana, forcaDistancia2;
    public Rigidbody2D  rbBanana;
    public PlayerBatalha playerBatalha;

    // Start is called before the first frame update
    void Start()
    {
            rbBanana.AddForce(new Vector2(forcaDistancia2, forceBanana));
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TagLimite") || collision.gameObject.CompareTag("TagChao"))
        {
            Destroy(gameObject);
        }
    }
}
