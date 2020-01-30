using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    public KeyCode btnA;
    int contador;
    public Button btnJogar, btnCreditos;
    public AudioClip btnEfeito, trasBtn;
    public bool OkJogar, OkCreditos, selecao, precionado;
    float tempo = 1;
    public Color  corSelecionar, corApertar, corBase;
    public GameObject maoJogar, maoCreditos;

    // Start is called before the first frame update
    void Start()
    {
        contador = 1;
        OkJogar = false;
        OkCreditos = false;
        selecao = true;
        precionado = false;

        maoJogar.SetActive(false);
        maoCreditos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OkJogar == true)
        {
            tempo -= Time.deltaTime;

            if (tempo <= 0)
            {
                SceneManager.LoadScene("Escolha");
            }
        }

        if (OkCreditos == true)
        {
            tempo -= Time.deltaTime;

            if (tempo <= 0)
            {
                SceneManager.LoadScene("Creditos");
            }
        }

        if (contador == 1)
        {
            maoJogar.SetActive(true);
            maoCreditos.SetActive(false);

            if (selecao == true)
            {                      
                btnJogar.GetComponent<Image>().color = corSelecionar;
                btnCreditos.GetComponent<Image>().color = corBase;               
            }
            
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(btnA))
            {
                selecao = false;
                precionado = true;

                if (precionado == true)
                {
                    btnJogar.GetComponent<Image>().color = corApertar;
                    AudioSource.PlayClipAtPoint(btnEfeito, Camera.main.transform.position * Time.deltaTime);
                    OkJogar = true;
                }               
            }
         
        }

        else if (contador == 2)
        {
            maoJogar.SetActive(false);
            maoCreditos.SetActive(true);

            if (selecao == true)
            {
                 btnJogar.GetComponent<Image>().color = corBase;
                 btnCreditos.GetComponent<Image>().color = corSelecionar;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                selecao = false;
                precionado = true;

                if (precionado == true)
                {
                     btnCreditos.GetComponent<Image>().color = corApertar;
                     AudioSource.PlayClipAtPoint(btnEfeito, Camera.main.transform.position * Time.deltaTime);
                     OkCreditos = true;
                }
            }
        }

        if (Input.GetAxis("Vertical") > 0 )
        {
            contador--;
            AudioSource.PlayClipAtPoint(trasBtn, Camera.main.transform.position * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            contador++;
            AudioSource.PlayClipAtPoint(trasBtn, Camera.main.transform.position * Time.deltaTime);
        }

        if (contador < 1)
        {
            contador = 1;
        }
        else if (contador > 2)
        {
            contador = 2;
        }

    }

    public void Jogar()
    {
        SceneManager.LoadScene("ModoEscolha");
    }
}
