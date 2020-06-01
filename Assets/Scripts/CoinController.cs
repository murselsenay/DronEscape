using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    public GameObject Coin;
    public List<GameObject> CoinSpots=new List<GameObject>();
    float CoinPositionX = 15;
    int coins = 0;
    public int coinOrder;
    GameObject CoinSpotTop;
    GameObject CoinSpotMiddle;
    GameObject CoinSpotBottom;
    GameObject[] DestroyedCoin;
    Drone Drone;
    bool coinFr = true;
    int randomCoinSpot = 1;

    // Use this for initialization


    void Start () {
        CoinSpotTop = GameObject.FindWithTag("CoinTop");
        CoinSpotMiddle = GameObject.FindWithTag("CoinMiddle");
        CoinSpotBottom = GameObject.FindWithTag("CoinBottom");
        Drone = GameObject.Find("Drone").GetComponent<Drone>();
        //InvokeRepeating("produceCoin", 1,2f);
        
        
        CoinSpots.Add(CoinSpotTop.gameObject);
        CoinSpots.Add(CoinSpotMiddle.gameObject);
        CoinSpots.Add(CoinSpotBottom.gameObject);
        randomCoinSpot = Random.Range(0, 3);
        StartCoroutine("coinFreq");
    }
	
	// Update is called once per frame
	void Update () {
        
        
        /* if (CoinQuantity<10)
         { 
         NewCoin.Add(Instantiate(Coin, new Vector2(CoinPositionX,CoinSpotMiddle.transform.position.y), Quaternion.identity));

             CoinPositionX += 1;
         }*/
        
       if (Drone.gameOver==true)
        {
            StopAllCoroutines();
        }


    }
   
    public void produceCoin()
    {

        CoinPositionX = 15;
        if (Drone.coinQuantity < 30)
        {
            if (randomCoinSpot == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(Coin, new Vector2(CoinPositionX, CoinSpotTop.transform.position.y), Quaternion.identity);
                    CoinPositionX += 1;
                    Drone.coinQuantity++;
                }

            }
            if (randomCoinSpot == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(Coin, new Vector2(CoinPositionX, CoinSpotMiddle.transform.position.y), Quaternion.identity);
                    CoinPositionX += 1;
                    Drone.coinQuantity++;
                }

            }
            if (randomCoinSpot == 3)
            {
                
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(Coin, new Vector2(CoinPositionX, CoinSpotBottom.transform.position.y), Quaternion.identity);
                    CoinPositionX += 1;
                    Drone.coinQuantity++;
                }

            }
        }
        //CoinQuantity++;
        randomCoinSpot = Random.Range(1, 4);
        Debug.Log("random:" + randomCoinSpot.ToString());


       // transform.Translate(Vector2.left * 0.1f);


    }
    IEnumerator coinFreq()
    {
        while (true)
        { 
        
         if (Drone.coinQuantity<20)
            { 
        for (int i=0;i<30;i++)
        {
            Instantiate(Coin, new Vector2(CoinPositionX, CoinSpots[randomCoinSpot].transform.position.y), Quaternion.identity);
            CoinPositionX += 1;
                coins++;
                Drone.coinQuantity++;
                if (coins==10)
                {
                    randomCoinSpot = Random.Range(0, 3);
                    coins = 0;
                }
        }
            }
            CoinPositionX = 15;
            yield return new WaitForSeconds(1);
        }
    }

    }
  

