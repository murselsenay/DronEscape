using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgForMenu : MonoBehaviour {

    public float speed;
    public float backgroundSize;
    Vector3 startPosition;
    GameControl gamecontrol;


    // Use this for initialization
    void Start()
    {
        // Getting backgrounds start position
        startPosition = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate((new Vector3(-1, 0, 0)) *Time.deltaTime );
        if (transform.position.x < backgroundSize)
        {
            transform.position = startPosition;
        }
    }
}
