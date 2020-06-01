using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drone : MonoBehaviour
{
    public GameObject MagnetPowerUpSignal;
    public GameObject bulletBg;
    public GameObject bulletRemain;
    public List<GameObject> newBulletBg = new List<GameObject>();
    public List<GameObject> newBulletTransparent = new List<GameObject>();
    public GameObject bulletRemainSpot;

    public CameraScript cameraScript;

    Vector3 dronePosition;
    Vector3 newdronePosition;
    bool sumDistance = true;
    bool sumMoney = true;
    public int firstRunValue = 0;
    public int scoreValue = 0;
    public int highscoreValue = 0;
    internal int point;
    int tapTime = 0;
    bool startGame = true;
    internal bool lockDrone = false;
    public bool isDamaged;
    public bool isMagnetic;
    public bool isCharging = false;
    internal int totalDistance;
    Animator droneAnimController;
    internal int lives = 3;
    public GameObject weaponObj;
    public GameObject batteryBarObj;
    GameObject droneBodyObj;
    GameObject dronePropellerObj;
    GameObject highScoreMedalObj;
    public GameObject coinObj;
    public GameObject liveOne;
    public GameObject liveTwo;
    public GameObject liveThree;
    public GameObject bulletSpot;
    public GameObject bulletObj;
    public GameObject coin;
    public GameObject tap;
    GameObject distanceTextObj;
    GameObject highScoreTextObj;

    int count = 5;
    internal int coinQuantity;
    bool canFire = false;
    int bulletQuantity = 4;
    int bulletLevel;
    int magnetLevel;
    int livesLevel;
    internal int distance = 0;
    Text distanceText;
    Text highScoreText;
    float distanceSpeed = 1;
    internal bool gameOver = false;
    GameControl gamecontrol;
    int money;
    int totalMoney;
    Color newMagnetSignalColour;

    //sesler
    AudioSource auSource;
    AudioClip auDrone;
    // Use this for initialization
    void Start()
    {

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        auSource = GetComponent<AudioSource>();
        auSource.volume = 0.5f;
        bulletLevel = PlayerPrefs.GetInt("bulletLevel");
        magnetLevel = PlayerPrefs.GetInt("magnetLevel");
        livesLevel = PlayerPrefs.GetInt("livesLevel");
        tap = GameObject.Find("Tap");
        droneBodyObj = GameObject.FindWithTag("DroneBody");
        dronePropellerObj = GameObject.FindWithTag("DronePropeller");
        totalDistance = PlayerPrefs.GetInt("totalDistance");
        droneAnimController = GetComponent<Animator>();
        distanceTextObj = GameObject.Find("DistanceText");
        distanceText = distanceTextObj.GetComponent<Text>();
        highScoreTextObj = GameObject.Find("HighScoreText");
        highScoreText = highScoreTextObj.GetComponent<Text>();
        highScoreMedalObj = GameObject.Find("HighScoreMedal");
        weaponObj.gameObject.GetComponent<Renderer>().enabled = false;
        gamecontrol = GameObject.Find("GameController").GetComponent<GameControl>();

        StartCoroutine("distanceMeter");
        StartCoroutine("tapCounter");
        dronePosition.y = Screen.width / 2;
        //PlayerPrefs.DeleteAll(); //delete data
        firstRunValue = PlayerPrefs.GetInt("firstRun", 0);
        highscoreValue = PlayerPrefs.GetInt("highScore");
        highScoreMedalObj.SetActive(false);
        MagnetPowerUpSignal.SetActive(false);

        highScoreText.text = "High Score: " + highscoreValue.ToString();
        Time.timeScale = 1;

        bulletQuantity = bulletQuantity * bulletLevel;
        Color newMagnetSignalColour = MagnetPowerUpSignal.GetComponent<SpriteRenderer>().color;

        float x = bulletRemainSpot.transform.position.x;
        for (int i = 0; i < bulletQuantity; i++)
        {
            x = x + 0.25f;
            newBulletTransparent.Add(Instantiate(bulletRemain, new Vector2(x, bulletRemainSpot.transform.position.y), Quaternion.identity));
            Color newBulletTransparentSprite = newBulletTransparent[i].GetComponent<SpriteRenderer>().color;
            newBulletTransparentSprite.a = 0.4f;
            newBulletTransparent[i].GetComponent<SpriteRenderer>().color = newBulletTransparentSprite;
            
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (firstRunValue == 1)
        {
            Destroy(tap.gameObject);
        }
        if (Input.GetMouseButton(0))
        {

            firstRunValue = 1;
            PlayerPrefs.SetInt("firstRun", firstRunValue);
            Destroy(tap.gameObject);
            startGame = false;
        }
        if (count < 1)
        {
            isMagnetic = false;
            StopCoroutine("countTime");
            StopCoroutine("MagnetSignal");
            MagnetPowerUpSignal.SetActive(false);
        }
        //Debug.Log(Screen.height / 2);
        if (dronePosition.y > Screen.height / 1.2f)
        {
            dronePosition.y -= Screen.height * 1.2f / 100;
        }
        if (transform.position.y < -3)
        {
            dronePosition.y += Screen.height * 1 / 100;
        }


        if (!IsPointerOverUIObject())
        {
            if (Input.GetMouseButton(0))
            {
                if (auSource.pitch >= 1.8f)
                {
                    auSource.pitch = 1.8f;
                }
                else
                {
                    auSource.pitch = auSource.pitch + 0.01f;
                }

                dronePosition.y += Screen.height * 2 / 100;
                lockDrone = false;
            }
            else
            {
                if (auSource.pitch <= 1)
                {
                    auSource.pitch = 1;
                }
                else
                {
                    auSource.pitch = auSource.pitch - 0.01f;
                }
            }
        }
        if (startGame == true)
        {
            newdronePosition = new Vector3(Screen.width / 8, Screen.height / 2, 15);
        }
        else
        {

            if (lockDrone == true)
            {
                dronePosition.y -= 0;
            }
            else
            {
                dronePosition.y -= Screen.height * 1 / 100;
            }


            newdronePosition = new Vector3(Screen.width / 8, dronePosition.y, 15);

        }

        transform.position = Camera.main.ScreenToWorldPoint(newdronePosition);
    }
    Vector3 cord;
    void FixedUpdate()
    {
        if (lives == 2)
        {
            liveOne.GetComponent<Renderer>().enabled = true;
            liveTwo.GetComponent<Renderer>().enabled = true;
            liveThree.GetComponent<Renderer>().enabled = false;
        }
        else if (lives == 1)
        {
            liveOne.GetComponent<Renderer>().enabled = true;
            liveTwo.GetComponent<Renderer>().enabled = false;
            liveThree.GetComponent<Renderer>().enabled = false;
        }
        else if (lives == 0)
        {
            StopCoroutine("distanceMeter");
            if (sumDistance == true)
            {
                totalDistance = totalDistance + distance;
                PlayerPrefs.SetInt("totalDistance", totalDistance);

                sumDistance = false;
            }
            liveOne.GetComponent<Renderer>().enabled = false;
            liveTwo.GetComponent<Renderer>().enabled = false;
            liveThree.GetComponent<Renderer>().enabled = false;
            droneBodyObj.GetComponent<Renderer>().enabled = false;
            dronePropellerObj.GetComponent<Renderer>().enabled = false;
            weaponObj.gameObject.GetComponent<Renderer>().enabled = false;
            gameOver = true;
            droneAnimController.SetBool("isGameOver", true);
            Destroy(gameObject, 1);

            if (distance > highscoreValue)
            {
                highScoreMedalObj.SetActive(true);
                PlayerPrefs.SetInt("highScore", distance);
                StopCoroutine("distanceMeter");
            }
            if (sumMoney == true)
            {
                totalMoney = totalMoney + money;
                PlayerPrefs.SetInt("totalMoney", totalMoney);
                totalMoney = PlayerPrefs.GetInt("totalMoney");
                Debug.Log(totalMoney);
                sumMoney = false;
            }
        }
        /*  cord = Camera.main.ScreenToWorldPoint(Input.mousePosition);



          Vector3 newdronePosition = new Vector3(dronePosition.x+100, Input.mousePosition.y,15);
          transform.position = Camera.main.ScreenToWorldPoint(newdronePosition);
          */

    }

    /* void OnMouseDown()
     {
         dronePosition = Camera.main.WorldToScreenPoint(transform.position);

     }
     void OnMouseDrag()
     {
         Vector3 newdronePosition = new Vector3(dronePosition.x, Input.mousePosition.y, dronePosition.z);
         transform.position = Camera.main.ScreenToWorldPoint(newdronePosition);

     }*/
    void UpdateAnimations()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnergyPowerUp")
        {
            isCharging = true;
        }
        if (other.gameObject.tag == "Magnet")
        {
            count = 5;
            isMagnetic = true;
            count = count * magnetLevel / 2;
            MagnetPowerUpSignal.SetActive(true);
            StartCoroutine(MagnetSignal(true)); 
            StartCoroutine("countTime");

        }
        if (other.gameObject.tag == "BulletPowerUp")
        {

            var bulletClones = GameObject.FindGameObjectsWithTag("BulletBg");
            foreach (var clone in bulletClones)
            {
                Destroy(clone);
            }
            while (newBulletBg.Count > 0)
            {
                newBulletBg.RemoveAt(newBulletBg.Count - 1);

            }



            bulletQuantity = 4;
            bulletQuantity = bulletQuantity * bulletLevel;

            canFire = true;
            weaponObj.gameObject.GetComponent<Renderer>().enabled = true;
            float x = bulletRemainSpot.transform.position.x;


            for (int i = 0; i < bulletQuantity; i++)
            {
                x = x + 0.25f;
                newBulletBg.Add(Instantiate(bulletBg, new Vector2(x, bulletRemainSpot.transform.position.y), Quaternion.identity));

            }

        }

        if (other.gameObject.tag == "Coin")
        {

            Destroy(other.gameObject);
            coinQuantity--;
            totalMoney = PlayerPrefs.GetInt("totalMoney");
            money++;


        }
        if (other.gameObject.tag == "Fusion" || other.gameObject.tag == "Bird" )
        {
            isDamaged = true;
            StartCoroutine(cameraScript.Shake(.2f, .2f));
            StartCoroutine("takeDamage");
            livesLevel--;
            if (livesLevel == 0)
            {
                lives--;
                livesLevel = PlayerPrefs.GetInt("livesLevel");
            }


        }

        if (other.gameObject.tag=="GroundCollider")
        {
            isDamaged = true;
            StartCoroutine(cameraScript.Shake(.2f, .2f));
            StartCoroutine("takeDamage");
            lives = 0;
        }
        if (other.gameObject.tag == "Coin")
        {


            batteryBarObj.GetComponent<BatteryBar>().isCharging = true;


        }


    }

    IEnumerator takeDamage()
    {
        droneAnimController.SetBool("isDestroyed", true);
        yield return new WaitForSeconds(0.5f);
        droneAnimController.SetBool("isDestroyed", false);
        StopCoroutine("takeDamage");
    }
    IEnumerator countTime()
    {
        while (true)
        {
            count--;

            yield return new WaitForSeconds(1);
        }

    }
    public void produceBullet()
    {
        if (canFire && bulletQuantity > 0)
        {

            Instantiate(bulletObj, new Vector2(bulletSpot.transform.position.x, bulletSpot.transform.position.y), Quaternion.identity);
            Destroy(newBulletBg[bulletQuantity - 1]);

            bulletQuantity--;
            if (bulletQuantity == 0)
            {
                weaponObj.gameObject.GetComponent<Renderer>().enabled = false;

            }
        }
        else
        {
            weaponObj.gameObject.GetComponent<Renderer>().enabled = false;
            canFire = false;

        }


    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    IEnumerator distanceMeter()
    {
        while (true)
        {
            if (distanceSpeed > 0.2f)
            {
                distanceSpeed -= 0.003f;

            }
            else
            {
                distanceSpeed = 0.2f;

            }
            distance++;
            distanceText.text = distance.ToString() + " m";
            yield return new WaitForSeconds(distanceSpeed);

        }
    }
    IEnumerator tapCounter()
    {
        while (true)
        {
            tapTime++;
            yield return new WaitForSeconds(1);

        }
    }
    public void lockDronebtn()
    {
        lockDrone = true;
    }

    IEnumerator MagnetSignal(bool fadeAway)
    {
        while (true)
        {
            newMagnetSignalColour.r = 1;
            newMagnetSignalColour.g = 1;
            newMagnetSignalColour.b = 1;
            // fade from opaque to transparent
            if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                newMagnetSignalColour.a = i;
                MagnetPowerUpSignal.GetComponent<SpriteRenderer>().color = newMagnetSignalColour;
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                newMagnetSignalColour.a = i;
                MagnetPowerUpSignal.GetComponent<SpriteRenderer>().color = newMagnetSignalColour;
                yield return null;
            }
        }
        }
    }
}
    
