using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D bulletBody;
    public GameObject bulletAnim;
    AudioSource auSource;
    AudioClip auBullet;
    xBonusController bonusController;
   
   
    // Use this for initialization
    void Start()
    {
        bonusController = GameObject.Find("xBonusController").GetComponent<xBonusController>();
        auSource = GetComponent<AudioSource>(); 
        bulletBody = GetComponent<Rigidbody2D>();
        bulletBody.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
        bulletAnim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x > 9)
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

        if (other.gameObject.tag == "Bird" || other.gameObject.tag=="Fusion")
        {
            bonusController.bonusActive = true;
            StartCoroutine("Fading");
            bulletBody.velocity = Vector2.zero;
            Destroy(other.gameObject);
            Destroy(gameObject,0.4f);
            
            



        }


    }
    IEnumerator Fading()
    {

        
        bulletAnim.SetActive(true);
        yield return new WaitForSeconds(1);
        bulletAnim.SetActive(false);
    }
    
}
