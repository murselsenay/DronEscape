using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coution : MonoBehaviour {
    public GameObject Fusion;
    GameObject Coution1;
    GameObject Coution2;
    GameObject Coution3;
    GameObject Coution4;
    Drone Drone;

    //sesler
    AudioSource auSource;
    AudioClip auCoution;

    // Use this for initialization
    void Start () {
        Drone = GameObject.Find("Drone").GetComponent<Drone>();
        auSource = GetComponent<AudioSource>();
        gameObject.GetComponent<Renderer>().enabled = false;
        StartCoroutine("produceCoution");
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Drone.gameOver == true)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
    void activeCoution()
    {
        

    }
    IEnumerator produceCoution()
    {
       
        while (true)
        { 
        int random = Random.Range(1, 30);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(random);
        gameObject.GetComponent<Renderer>().enabled = true;
        auSource.Play();
        produceFusion();
        yield return new WaitForSeconds(2.1f);
        auSource.Stop();
        gameObject.GetComponent<Renderer>().enabled = false;
        }
        
    }
    void produceFusion()
    {
        Instantiate(Fusion, new Vector2(transform.position.x+20, transform.position.y), Quaternion.identity);

    }
}
