using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    GameControl gamecontrol;
    Rigidbody2D magnetBody;
    
    
    // Use this for initialization
    void Start()
    {

        gamecontrol = GameObject.Find("GameController").GetComponent<GameControl>();
        magnetBody = GetComponent<Rigidbody2D>();
        magnetBody.AddForce(new Vector2(gamecontrol.speed, 0), ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (transform.position.x < -20)
        {
            SelfDestroy();

        }
        
    }
    void SelfDestroy()
    {

        Destroy(gameObject);


    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Drone")
        {
            
            magnetBody.velocity = Vector2.zero;
            Destroy(gameObject);
            


        }
    }
    
}