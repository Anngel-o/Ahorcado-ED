using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Spider : MonoBehaviour
{
    int piezasVisibles = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Marcar cada pieza de spiderman invisible
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void piezaVisible() {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(true);
                break;
            }
        }
        transform.gameObject.SetActive(true);
        comprobarFinal();
    }

    void comprobarFinal() {
        piezasVisibles++;
        if (piezasVisibles == transform.childCount)
        {
            SceneManager.LoadScene("GameOver");        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
