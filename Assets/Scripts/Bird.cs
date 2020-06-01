using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D birdBody;
    bool UpDown;
    // Use this for initialization
    void Start()
    {

        birdBody = GetComponent<Rigidbody2D>();
        StartCoroutine("goUpDown");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (UpDown == true)
        {
            goDown();
        }
        else if (UpDown == false)
        {
            goUp();
        }

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

            birdBody.velocity = Vector2.zero;
            Destroy(gameObject);



        }
        if (other.gameObject.tag == "Bullet")
        {

            birdBody.velocity = Vector2.zero;




        }


    }
    void goDown()
    {
        birdBody.AddForce(new Vector2(-2, -2), ForceMode2D.Force);
    }
    void goUp()
    {
        birdBody.AddForce(new Vector2(-2, 3), ForceMode2D.Force);
    }
    IEnumerator goUpDown()
    {
        while(true)
        { 
        UpDown = true;
        yield return new WaitForSeconds(1);
        UpDown = false;
        yield return new WaitForSeconds(1);
        }
    }
}
