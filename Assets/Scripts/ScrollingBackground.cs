using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    public float speed;
    public float backgroundSize;
    Vector3 startPosition;
    GameControl gamecontrol;


    // Use this for initialization
    void Start()
    {
        // Getting backgrounds start position
        startPosition = transform.position;
        StartCoroutine("getFaster");
        gamecontrol = GameObject.Find("GameController").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate((new Vector3(-1, 0, 0))*gamecontrol.speed*Time.deltaTime*-1);
        if (transform.position.x< backgroundSize)
        {
            transform.position = startPosition;
        }
    }
    IEnumerator getFaster()
    {
        while(true)
        { 
        speed+=0.1f;
        yield return new WaitForSeconds(20);
        }
    }
}
