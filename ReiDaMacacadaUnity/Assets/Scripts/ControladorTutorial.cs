using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorTutorial : MonoBehaviour
{
    public bool checkP1, checkP2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkP1 == true && checkP2 == true)
        {
            SceneManager.LoadScene("ModoBatalha");
        }
    }
}
