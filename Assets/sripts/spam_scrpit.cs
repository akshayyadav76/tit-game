using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spam_scrpit : MonoBehaviour
{

    [SerializeField]
    private GameObject [] enemySpam;
    [SerializeField]
    private GameObject[] powerUPs;

    void Start()
    {
        StartCoroutine(objetRoundom());
         StartCoroutine(powerUPss());
        
    }
        IEnumerator objetRoundom(){
            while(true){
              int value = Random.Range(0,2);
              //Debug.Log("emney index value "+value);
                Instantiate(enemySpam[value], new Vector3(Random.Range(-8.0f,8.8f),5.5f,0) ,Quaternion.identity);
              yield return new WaitForSeconds(3);
            }
            
        }
         IEnumerator powerUPss(){
            while(true){
                int value =Random.Range(0,3);
                Instantiate(powerUPs[value], new Vector3(Random.Range(-8.0f,8.8f),5.5f,0) ,Quaternion.identity);
              yield return new WaitForSeconds(5);
            }
            
        }
}
