using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour {
    Rigidbody2D bulletPowerUpBody;
    GameControl gamecontrol;
    // Use this for initialization
    void Start () {
        bulletPowerUpBody = GetComponent<Rigidbody2D>();
        gamecontrol = GameObject.Find("GameController").GetComponent<GameControl>();
        bulletPowerUpBody.AddForce(new Vector2(gamecontrol.speed, 0), ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
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

            bulletPowerUpBody.velocity = Vector2.zero;
            Destroy(gameObject);



        }
    }
}
