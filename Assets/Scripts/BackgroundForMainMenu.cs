using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundForMainMenu : MonoBehaviour {

    
    public float backgroundSize;
    Vector3 startPosition;


    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate((new Vector3(-1, 0, 0)) * Time.deltaTime * 1);
        if (transform.position.x < backgroundSize)
        {
            transform.Translate(new Vector3(startPosition.x - backgroundSize*2, 0, 0));
        }
    }
   
}
