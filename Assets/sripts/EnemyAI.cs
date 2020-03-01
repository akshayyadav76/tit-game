using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private GameObject _enmey; 
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private AudioClip _explodSound;
   
   public UiManger uiManger;

    void Start()
    {
        uiManger = GameObject.Find("Canvas").GetComponent<UiManger>();
       
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down *speed *Time.deltaTime);
        if(transform.position.y<-6.6f){
       float rundomX=Random.Range(-8.0f,8.0f);
        transform.position = new Vector3(rundomX,6.3f,0);
        }
        
    }
private void  OnTriggerEnter2D(Collider2D other){

    //Debug.Log(other.name);
  
     if(other.tag =="laser"){
         Destroy(other.gameObject);
         Instantiate(_enmey,transform.position,Quaternion.identity);
      AudioSource.PlayClipAtPoint(_explodSound,Camera.main.transform.position,1f);
       uiManger.UpdateScore();
         Destroy(this.gameObject);
      
         
     }
     if(other.tag == "Player"){
         Player obj = other.GetComponent<Player>();
         if(obj != null){
          obj.damageLives();
         }
         Instantiate(_enmey,transform.position,Quaternion.identity);
         AudioSource.PlayClipAtPoint(_explodSound,Camera.main.transform.position,1f);
         Destroy(this.gameObject);
         
         
     }
}
   
}
