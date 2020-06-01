using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpot : MonoBehaviour {
    public GameObject Bird;
    public GameObject Magnet;
    public GameObject bulletPowerUp;
    public GameObject energyPowerUp;
    Drone Drone;
    public int randomBird;
    public int randomMagnet;
    public int randomBulletPowerUp;
    public int randomEnergyPowerUp;
    public float randomy;
    // Use this for initialization
    void Start () {
        
        Invoke("callBirdCoroutines", 30);
        Invoke("callMagnetCoroutines", 50);
        Invoke("callBulletPowerUpCoroutines", 20);
        Invoke("callEnergyPowerUpCoroutines", 10);
        Drone = GameObject.Find("Drone").GetComponent<Drone>();
    }
	
	// Update is called once per frame
	void Update () {
        randomy = Random.Range(-2.9f, 3.5f);
        randomBird = Random.Range(1, 30);
        randomMagnet = Random.Range(1, 30);
        randomBulletPowerUp = Random.Range(1, 30);
        randomEnergyPowerUp = Random.Range(1, 30);
        if (Drone.gameOver == true)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator produceBird()
    {
        
        while (true)
        {
            
            yield return new WaitForSeconds(randomBird);
            Instantiate(Bird, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

        }
        

    }
    IEnumerator produceMagnet()
    {

       
        while (true)
        {

            yield return new WaitForSeconds(randomMagnet);
            Instantiate(Magnet, new Vector2(transform.position.x, randomy), Quaternion.identity);

        }

    }
    IEnumerator produceBulletPowerUp()
    {


        while (true)
        {

            yield return new WaitForSeconds(randomBulletPowerUp);
            Instantiate(bulletPowerUp, new Vector2(transform.position.x, randomy), Quaternion.identity);

        }

    }
    IEnumerator produceEnergyPowerUp()
    {


        while (true)
        {

            yield return new WaitForSeconds(randomEnergyPowerUp);
            Instantiate(energyPowerUp, new Vector2(transform.position.x, randomy), Quaternion.identity);

        }

    }
    void callBirdCoroutines()
    {
        StartCoroutine("produceBird");
        
    }
    void callMagnetCoroutines()
    {
        
        StartCoroutine("produceMagnet");
    }
    void callBulletPowerUpCoroutines()
    {
        StartCoroutine("produceBulletPowerUp");

    }
    void callEnergyPowerUpCoroutines()
    {
        StartCoroutine("produceEnergyPowerUp");

    }

}
