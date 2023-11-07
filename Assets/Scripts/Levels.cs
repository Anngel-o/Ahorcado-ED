using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Levels : MonoBehaviour
{
   public void changeLevel(string name) {
        SceneManager.LoadScene(name);
   }
}
