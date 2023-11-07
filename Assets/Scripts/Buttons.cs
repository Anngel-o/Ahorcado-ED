using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject buttonPrefab; // El botón prefabricado que servirá como plantilla.
    public Transform buttonParent; // El objeto que contendrá los botones.
    private char letter;
    public Spider spider;

    void Start()
    {
        for(char letter = 'A'; letter <= 'Z'; letter++){
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<TMP_Text>().text = letter.ToString();
            button.name = "Button_" + letter;
        }
    }

    public void OnButtonClick()
    {
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();
        GameObject buttonPress = clickedButton.gameObject;

        if (buttonText != null)
        {
            Debug.Log("Botón " + buttonText.text + " fue presionado.");
            spider.piezaVisible();
            buttonPress.SetActive(false);
        }
    }

    public void OnButtonClickLetter()
    {
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();

        if (buttonText != null)
        {
            Debug.Log("Botón " + buttonText.text + " fue presionado.");
        }
    }
}
