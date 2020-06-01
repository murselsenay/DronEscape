using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour {
    Rigidbody2D fusionBody;
    GameObject Explosion;
    GameObject GameControlObj;
    GameControl gameControl;
    // Use this for initialization
    void Start () {
        GameControlObj = GameObject.Find("GameController");
        gameControl = GameControlObj.GetComponent<GameControl>();

        fusionBody = GetComponent<Rigidbody2D>();
        fusionBody.AddForce(new Vector2(-2*gameControl.speed*-1, 0), ForceMode2D.Impulse);
        
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(gameControl.speed.ToString());
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
          
            fusionBody.velocity = Vector2.zero;
            Destroy(gameObject);
            


        }
        if (other.gameObject.tag == "Bullet")
        {

            fusionBody.velocity = Vector2.zero;
            



        }


    }
}
