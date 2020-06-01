using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    Rigidbody2D coinBody;

    GameControl gamecontrol;
    Drone Drone;
    public float DronexPos;
    public float DroneyPos;
    internal float time = 0;
    


    // Use this for initialization
    void Start () {
        
        DronexPos = GameObject.Find("Drone").transform.position.x;
        DroneyPos = GameObject.Find("Drone").transform.position.y;
        coinBody = GetComponent<Rigidbody2D>();
        gamecontrol = GameObject.Find("GameController").GetComponent<GameControl>();
        
        Drone = GameObject.Find("Drone").GetComponent<Drone>();
        //coinBody.AddForce(new Vector2(gamecontrol.speed, 0), ForceMode2D.Impulse);
        coinBody.velocity = new Vector2(gamecontrol.speed, 0);

        
    }
	
	// Update is called once per frame
	void Update () {
        
        //MoveToward();
         if (transform.position.x < -10)
         {
            Drone.coinQuantity--;
             SelfDestroy();
           
        }

        
        
        if (Drone.isMagnetic==true)
        {
            magnetPowerUp();
            
            
        }
        
        

        /*  
          if (Drone.isMagnetic == true && time<50)
          {
              magnetPowerUp();
              time++;
              Debug.Log(time.ToString());
          }
          else
          {
              time = 0;
              Drone.isMagnetic = false;

          }*/

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        

    }
    void SelfDestroy()
    {
        
        Destroy(gameObject);
        

    }
    void magnetPowerUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Drone").transform.position, Time.deltaTime * 30);
    }
   

    
}
