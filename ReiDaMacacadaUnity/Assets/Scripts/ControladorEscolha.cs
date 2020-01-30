using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorEscolha : MonoBehaviour
{
    public KeyCode botaoA, botaoB;
    int contador, contador2;
    public Button btnBatalha, btnClassico, tutoSim, tutoNao;
    public GameObject painelTutorial, painelEscolha, btnA, btnB, mao1, mao2, maoSim, maoNao;
    public bool tutorialOk, escolhaOk, okBatalha, okClassico, okTutorial, selecao, precionado, precionadoSim, precionadoNao;
    public Color corSelecao, corPrecinar, corBase;
    float tempo = 1;
    public AudioClip btnEfeito, btnEscolhido, voltar;

    // Start is called before the first frame update
    void Start()
    {
    
        tutorialOk = false;
        escolhaOk = true;
        mao1.SetActive(false);
        mao2.SetActive(false);
        okBatalha = false;
        okTutorial = false;
        selecao = true;
        precionado = false;
        precionadoSim = false;
        maoSim.SetActive(false);
        maoNao.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (okBatalha == true)
        {
            tempo -= Time.deltaTime;

            if (tempo <= 0)
            {
                SceneManager.LoadScene("ModoBatalha");
            }
        }

        if (okTutorial == true)
        {
            tempo -= Time.deltaTime;

            if (tempo <= 0)
            {
                SceneManager.LoadScene("Tutorial");
            }
        }

        if (escolhaOk == true)
        {
            btnA.SetActive(true);
            btnB.SetActive(true);

            if (contador == 1)
            {
                mao1.SetActive(true);
                mao2.SetActive(false);

                if (selecao == true)
                {
                    btnBatalha.GetComponent<Image>().color = corSelecao;
                    btnClassico.GetComponent<Image>().color = corBase;
                }
                            
                if (Input.GetKeyDown(botaoA))
                {
                    AudioSource.PlayClipAtPoint(btnEscolhido, Camera.main.transform.position * Time.deltaTime);
                    painelTutorial.SetActive(true);
                    tutorialOk = true;
                    escolhaOk = false;
                    selecao = false;
                    precionado = true;

                    if (precionado == true)
                    {
                        btnBatalha.GetComponent<Image>().color = corPrecinar;
                    }

                }

            }
            else if (contador == 2)
            {
                mao1.SetActive(false);
                mao2.SetActive(true);
                btnBatalha.GetComponent<Image>().color = corBase;
                btnClassico.GetComponent<Image>().color = corSelecao;

                if (Input.GetKeyDown(botaoA))
                {
                    SceneManager.LoadScene("ModoClassico");
                }
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                AudioSource.PlayClipAtPoint(btnEfeito, Camera.main.transform.position * Time.deltaTime);
                contador++;
            }

            else if (Input.GetAxis("Horizontal") < 0)
            {
                AudioSource.PlayClipAtPoint(btnEfeito, Camera.main.transform.position * Time.deltaTime);
                contador--;
            }

            if (contador > 2)
            {
                contador = 2;
            }
            if (contador < 1)
            {
                contador = 1;
            }

            if (Input.GetKeyDown(botaoB))
            {
                AudioSource.PlayClipAtPoint(voltar, Camera.main.transform.position * Time.deltaTime);

                SceneManager.LoadScene("Menu");
            }
        }
       
        //PAINEL TUTORIAL
        if (tutorialOk == true)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                AudioSource.PlayClipAtPoint(btnEfeito, Camera.main.transform.position * Time.deltaTime);
                contador2--;
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                AudioSource.PlayClipAtPoint(btnEfeito, Camera.main.transform.position * Time.deltaTime);
                contador2++;
            }

            if (contador2 == 1)
            {
                maoSim.SetActive(true);
                maoNao.SetActive(false);

                if (precionadoSim == false)
                {
                    tutoSim.GetComponent<Image>().color = corSelecao;
                    tutoNao.GetComponent<Image>().color = corBase;
                }
               
                if (Input.GetKeyDown(botaoA))
                {
                    AudioSource.PlayClipAtPoint(btnEscolhido, Camera.main.transform.position * Time.deltaTime);
                    okTutorial = true;
                    precionadoSim = true;

                    if (precionadoSim == true)
                    {
                        tutoSim.GetComponent<Image>().color = corPrecinar;
                    }
                }                
            }
            else if (contador2 == 2)
            {
                maoSim.SetActive(false);
                maoNao.SetActive(true);

                if (precionadoNao == false)
                {
                    tutoSim.GetComponent<Image>().color = corBase;
                    tutoNao.GetComponent<Image>().color = corSelecao;
                }
               
                if (Input.GetKeyDown(botaoA))
                {
                    AudioSource.PlayClipAtPoint(btnEscolhido, Camera.main.transform.position * Time.deltaTime);
                    okBatalha = true;
                    precionadoNao = true;

                    if (precionadoNao == true)
                    {
                        tutoNao.GetComponent<Image>().color = corPrecinar;
                    }
                }
            }

            if (contador2 < 1)
            {
                contador2 = 1;
            }
            else if (contador2 > 2)
            {
                contador2 = 2;
            }       
        }

        if (Input.GetKeyDown(botaoB))
        {
            AudioSource.PlayClipAtPoint(voltar, Camera.main.transform.position * Time.deltaTime);

            escolhaOk = true;
            tutorialOk = false;
            painelTutorial.SetActive(false);
            contador2 = 0;
            maoSim.SetActive(false);
            maoNao.SetActive(true);
        }

    }        
}
