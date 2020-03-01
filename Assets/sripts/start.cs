using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
     public string senceName;

   public void startMenu(string senceName){
        SceneManager.LoadScene(senceName);
    }
   
}
