using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TMP_Text palabra;
    public GameObject btnPlay;
    char[] palabrasAdivinadas;
    int intentos = 0;
    //char[] palabraSeleccionada;
    char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    string[] palabras = {"araña", "telaraña", "insecto", "mary", "may", "ben", "peter", "parker", "electro", "buitre"};

    public GameObject buttonPrefab; // El botón prefabricado que servirá como plantilla.
    public Transform buttonParent; // El objeto que contendrá los botones.

    void Start()
    {
        
    }

    public void iniciar() {
        // Obtén una palabra aleatoria
        string palabraSeleccionada = ObtenerPalabraAleatoria();

        Debug.Log("Palabra seleccionada: " + palabraSeleccionada);
        palabra.text = palabraSeleccionada;
        btnPlay.SetActive(false);

        for (int i = 0; i < palabraSeleccionada.Length; i++)
        {
            char letraEnPosicion = palabraSeleccionada[i];
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<TMP_Text>().text = letraEnPosicion.ToString();
            //palabraSeleccionada
            button.name = "Button_" + letraEnPosicion;
        }
    }

    void Compare(){
        for (int i = 0; i < palabrasAdivinadas.Length; i++)
        {
            // if (palabrasAdivinadas[i] == Char.Parse())
            // {
                
            // }
        }
    }

    string ObtenerPalabraAleatoria()
    {
        // Genera un índice aleatorio dentro del rango del arreglo
        int indiceAleatorio = UnityEngine.Random.Range(0, palabras.Length);

        // Retorna la palabra en el índice aleatorio
        return palabras[indiceAleatorio];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}