using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FimControlador : MonoBehaviour
{
    public KeyCode botaoA;
    public int pontosP1, pontosP2;
    public Text txtPontosP1, txtPontosP2, txtDescricao;
    public GameObject hudP1, hudP2;

    // Start is called before the first frame update
    void Start()
    {
        pontosP1 = PlayerPrefs.GetInt("PontosP1");
        pontosP2 = PlayerPrefs.GetInt("PontosP2");

        hudP1.SetActive(false);
        hudP2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        txtPontosP1.text = "" + pontosP1;
        txtPontosP2.text = "" + pontosP2;

        if (pontosP1 > pontosP2)
        {
            txtDescricao.text = "Vencedor";
            hudP1.SetActive(true);
        }
        else if (pontosP1 < pontosP2)
        {
            txtDescricao.text = "Vencedor";
            hudP2.SetActive(true);
        }
        else if (pontosP1 == pontosP2)
        {
            txtDescricao.text = "Empate";
        }

        if (Input.GetKey(botaoA))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
