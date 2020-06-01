using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript2 : MonoBehaviour {

    public float speed;
    public float backgroundSize;
    Vector3 startPosition;
    GameControl gamecontrol;


    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        StartCoroutine("getFaster");
        gamecontrol = GameObject.Find("GameController").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate((new Vector3(-1, 0, 0)) * gamecontrol.speed * Time.deltaTime * -1);
        if (transform.position.x < backgroundSize)
        {
            transform.Translate(new Vector3(startPosition.x - backgroundSize, 0, 0));
        }
    }
    IEnumerator getFaster()
    {
        while (true)
        {
            speed += 0.1f;
            yield return new WaitForSeconds(20);
        }
    }
}
