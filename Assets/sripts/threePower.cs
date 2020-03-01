using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threePower : MonoBehaviour
{


  
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    
    private int id;
     [SerializeField]
    private AudioClip _soundPower;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

           
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("GameObject2 collided with " + other.name);
        if (other.tag == "Player")
        {      AudioSource.PlayClipAtPoint(_soundPower,Camera.main.transform.position,1f);
            Player obj = other.GetComponent<Player>();
            if (obj != null)
            {
                obj.threeFire = true;
            }

            if (id == 0)
            {
                obj.turnThreeOn();
            }
            if(id==1){
              obj.speedPowerOn();
            }
            if(id==2){
              obj.shildOn();
            }



            Destroy(this.gameObject);
        }


    }


}
