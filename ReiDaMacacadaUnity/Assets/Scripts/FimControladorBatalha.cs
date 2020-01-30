using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FimControladorBatalha : MonoBehaviour
{
    public KeyCode botaoA;
    public Text  txtDescricao;
    public GameObject hudP1, hudP2;
    public int vidaP1, vidaP2;

    // Start is called before the first frame update
    void Start()
    {
        vidaP1 = PlayerPrefs.GetInt("VidaP1");
        vidaP2 = PlayerPrefs.GetInt("VidaP2");

        hudP1.SetActive(false);
        hudP2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (vidaP1  > vidaP2)
        {
            txtDescricao.text = "Vencedor";
            hudP1.SetActive(true);
        }
        else if (vidaP1 < vidaP2)
        {
            txtDescricao.text = "Vencedor";
            hudP2.SetActive(true);
        }
        else if (vidaP1 == vidaP2)
        {
            txtDescricao.text = "Empate";
        }

        if (Input.GetKey(botaoA))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
