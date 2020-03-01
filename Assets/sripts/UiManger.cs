using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManger : MonoBehaviour
{
   

public Image playerLIves;

  public Sprite [] getLivesImage;

 public Text scoreText;

  static public int score2;
     public int score;


   void Start(){
     Debug.Log("tranfar scroe;"+score);
       scoreText.text = "Score:"+score2;
       
   }

   public void UpdateLives(int currentLives){
       playerLIves.sprite = getLivesImage[currentLives];
   }

   public void UpdateScore(){
            score = score +10;
             scoreText.text = "Score:"+score;
             score2 = score;
      
   }
}
