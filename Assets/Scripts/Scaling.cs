using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    public GameObject lives;
    public GameObject coutions;
    public GameObject bullets;


    // Use this for initialization
    void Start()
    {
        Vector3 livesPosition = new Vector3(Screen.width / 1.2f, Screen.height / 1.05f, 15);
        lives.gameObject.transform.position = Camera.main.ScreenToWorldPoint(livesPosition);

        Vector3 coutionsPosition = new Vector3(Screen.width / 1.05f, Screen.height / 2, 50);
        coutions.gameObject.transform.position = Camera.main.ScreenToWorldPoint(coutionsPosition);

        Vector3 bulletsPosition = new Vector3(Screen.width / 4f, Screen.height / 18, 50);
        bullets.gameObject.transform.position = Camera.main.ScreenToWorldPoint(bulletsPosition);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
