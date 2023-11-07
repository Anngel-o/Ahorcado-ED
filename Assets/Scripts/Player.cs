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
    string palabraGuardada;
    char[] palabrasAdivinadas;
    char[] letrasUsadas;
    int intentos = 0;
    char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    string[] palabras = {"araña", 
                         "telaraña",
                         "insecto", 
                         "mary", 
                         "may", 
                         "ben", 
                         "peter", 
                         "parker",
                         "electro", 
                         "buitre"};
    public GameObject buttonPrefab; // El botón prefabricado que servirá como plantilla.
    public Transform buttonParent; // El objeto que contendrá los botones.
    
    string ObtenerPalabraAleatoria()
    {
        // Genera un índice aleatorio dentro del rango del arreglo
        int indiceAleatorio = UnityEngine.Random.Range(0, palabras.Length);
        // Retorna la palabra en el índice aleatorio
        return palabras[indiceAleatorio];
    }
    static void ImprimirCasillas(string palabraSeleccionada, char letra, ref string palabraGuardada){
        GameObject button;
        for (int i = 0; i < palabraSeleccionada.Length; ++i){
            if (palabraSeleccionada[i] == letra){
                palabraGuardada = palabraGuardada.Remove(i, 1).Insert(i, letra.ToString());
                button = Instantiate(buttonPrefab, buttonParent);
                button.name = "Button_" + letraEnPosicion;
            }
            button.GetComponentInChildren<TMP_Text>().text = palabraGuardada[i].ToString();
        }
    }
    static void IniPalGuard(ref string palabraGuardada, string palabraSeleccionada){
        for (int i = 0; i < palabraSeleccionada.Length; ++i){
            palabraGuardada = palabraGuardada.Remove(i, 1).Insert(i, "-");
        }
    }

    static int VerificarLetra(string palabraSeleccionada, char letra, string letrasIntentadas){
        if (letrasIntentadas.Contains(letra)){
            //Console.WriteLine("\n<<<< Ya no se puede usar esa letra >>>>\n");
            return -2; // la letra ya se usó
        }
        if (palabra.Contains(letra)){
            return palabra.IndexOf(letra); // la palabra sí tiene esa letra
        }
        return -1; // la palabra no tiene esa letra
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void iniciar() {
        // Obtén una palabra aleatoria
       
       
       
    
        /*puntaje = 0.0;
        int numPantalla = 0;
        int existe = 1;
        string palabra, palabraGuardada, letrasIntentadas;
        palabra = "";
        string tablero = "QWERTYUIOPASDFGHJKLZXCVBNM";
        char letra;*/

        string palabraSeleccionada = ObtenerPalabraAleatoria();
        Debug.Log("Palabra seleccionada: " + palabraSeleccionada);
        btnPlay.SetActive(false);
        palabraGuardada = new string('-', palabraSeleccionada.Length);
        letrasIntentadas;
        //ImprimirPuntuacion();
        ImprimirCasillas(palabra, ' ', ref palabraGuardada);
        do
        {
            //To do: obtener letra del boton seleccionado
            ActualizarTablero(letra, ref tablero);
            existe = VerificarLetra(palabra, letra, letrasIntentadas.ToCharArray());
            letrasIntentadas = letrasIntentadas.Remove(letra - 'a', 1).Insert(letra - 'a', letra.ToString());
            ActualizarPuntaje(palabra, letra, existe);

            if (existe == -1)
            {
                numPantalla++;
            }

            if (existe == -2)
            {
                ImprimirPuntuacion();
                continue;
            }

            Console.Clear();
            ImprimirPantalla(numPantalla);
            ImprimirTablero(tablero);
            ImprimirPuntuacion();
            ImprimirCasillas(palabra, letra, ref palabraGuardada);
        } while (JuegoTerminado(numPantalla, palabra, palabraGuardada) != 1);

        for (int i = 0; i < palabraSeleccionada.Length; i++)
        {
            char letraEnPosicion = palabraSeleccionada[i];
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<TMP_Text>().text = letraEnPosicion.ToString();
            //palabraSeleccionada
            button.name = "Button_" + letraEnPosicion;
        }
    }

    static void Main()
    {
        char jugar;
        //ConsoleKeyInfo jugar;
        Console.WriteLine("=========================================");
        Console.WriteLine("    Bienvenido al Juego del Condenado    ");
        Console.WriteLine("=========================================");
        Console.WriteLine("\n>>>> Presione Enter para comenzar <<<<");
        //Console.ReadLine();
        do
        {
            //Console.Clear();
            MotorJuego();
            Console.WriteLine("\n>>> Desea continuar jugando? [Enter] <<<<");
            jugar = Console.ReadKey().KeyChar;
        } while (jugar == 's');//jugar.Key == ConsoleKey.Enter);

        //Console.WriteLine($"La palabra mejor adivinada fue:\n  {raiz.palabra} con {raiz.llave} puntos");
        Console.ReadKey();
    }
}


}
