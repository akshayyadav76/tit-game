using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     
[SerializeField]
private GameObject _shildActive;
  public bool shidl = false;
[SerializeField]
private GameObject _playerExplod;
  [SerializeField]
  public int lives = 3;
  public bool threeFire =false;
    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0.0f;
    private bool powerSpeedOn =false;
    private AudioSource _laserAudio;
  
    private UiManger uiManger;
     public Joystick joystick;

     [SerializeField]
    private GameObject _leser;
    [SerializeField]
    private GameObject _threeeLeser;

    [SerializeField]
    private float _speed2= 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        /// transform.position =new Vector3(2,0,0);
        _laserAudio = GetComponent<AudioSource>();
        uiManger = GameObject.Find("Canvas").GetComponent<UiManger>();
        uiManger.UpdateLives(lives);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     fire();
        // }
       fire();
     


    }

    public void fire()
    {
               _laserAudio.Play();
        if (Time.time > canFire)
        {
            if (threeFire)
            {
                 //left
                Instantiate(_threeeLeser, transform.position + new Vector3(-0.84f,0.27f,0),Quaternion.identity);
              
            }else{
                Instantiate(_leser, transform.position + new Vector3(0, 1.5f, 0),
                           Quaternion.identity); 
            }


            canFire = Time.time + fireRate;
        }


    }

    private void movement() {

        if(joystick.Horizontal >= .2f){
          
          if(powerSpeedOn){
transform.Translate(Vector3.right * _speed2 * 1.8f* Time.deltaTime  );
          }else{
 transform.Translate(Vector3.right * _speed2 * Time.deltaTime );
          }


        }else if(joystick.Horizontal <=-.2f){
  if(powerSpeedOn){
transform.Translate(Vector3.left * _speed2 * 1.8f* Time.deltaTime  );
          }else{
 transform.Translate(Vector3.left * _speed2 * Time.deltaTime  );
          }
        }



         if(joystick.Vertical >= .2f){
          
          if(powerSpeedOn){
transform.Translate(Vector3.up * _speed2 * 1.8f* Time.deltaTime  );
          }else{
 transform.Translate(Vector3.up * _speed2 * Time.deltaTime  );
          }


        }else if(joystick.Vertical <=-.2f){
  if(powerSpeedOn){
transform.Translate(Vector3.down * _speed2 * 1.8f* Time.deltaTime  );
          }else{
 transform.Translate(Vector3.down * _speed2 * Time.deltaTime  );
          }
        }


        // float movement = Input.GetAxis("Horizontal");
        // float upmovement = Input.GetAxis("Vertical");

        // 1,0,0,*1

        // if(powerSpeedOn){
           
        //    transform.Translate(Vector3.up * _speed2 * 1.8f* Time.deltaTime * upmovement );
        // }else{
       
        // transform.Translate(Vector3.up * _speed2 * Time.deltaTime * upmovement );
        // }
   

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.y < -4.3)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, 0);
        }
        //-2.6
        if (transform.position.x > 11.15)
        {
            transform.position = new Vector3(-8.41f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.41f)
        {
            transform.position = new Vector3(11.15f, transform.position.y, 0);
        }
    }

   public void turnThreeOn(){
        threeFire = true;
         StartCoroutine(turnThreeDown());
    }

    public void speedPowerOn(){
        powerSpeedOn =true;
        turnSpeedUp();

    }
    public void damageLives(){

         if(shidl == true){
        shidl =false;
         _shildActive.SetActive(false);
        return;
        }
        lives--;
        uiManger.UpdateLives(lives);

        //lives = lives -1;
       
        if(lives < 1){
            Instantiate(_playerExplod,transform.position,Quaternion.identity);
            
            Destroy(this.gameObject);
            SceneManager.LoadScene("start");
        }
        
    }
   
public void shildOn(){

    shidl = true;
    _shildActive.SetActive(true);
}
public IEnumerator turnThreeDown(){
    yield return new WaitForSeconds(5.0f);
    threeFire =false;
} 
public IEnumerator turnSpeedUp()
{
    yield return new WaitForSeconds(5.0f);
    powerSpeedOn =false;
}


}
