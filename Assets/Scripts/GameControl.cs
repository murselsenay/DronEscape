using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    internal float speed = -5;
    float gameSpeed = 3;
    int finalDistance;
    bool isgamePaused = false;
    GameObject gameOverPanelObj;
    GameObject gameOverScoreTextObj;
    GameObject pausePanelObj;
    GameObject pauseBtnObj;
    GameObject energyFullObj;
    GameObject energy4Obj;
    GameObject energy3Obj;
    GameObject energy2Obj;
    GameObject energy1Obj;
    GameObject lowBatteryObj;
    Text lowBatteryText;
    Text gameOverScoreText;
    Drone Drone;
    bool isBatteryLow = false;
    internal float energy = 50;
    internal float startEnergy;
    int energyReduceTime = 2;
    int energyLevel;
    int lowBatteryTimer = 10;

    //sesler
    AudioSource auSource;

    GameObject adsManagerObj;
    AdsManager adsManager;

    public Image FadeInOut;
    public Animator FadeAnimator;
    // Use this for initialization
    void Start()
    {
        
        auSource = GetComponent<AudioSource>();
        auSource.Play();
        adsManagerObj = GameObject.Find("AdsManager");
        adsManager = adsManagerObj.GetComponent<AdsManager>();
        startEnergy = energy;
        energyLevel = PlayerPrefs.GetInt("energyLevel");
        Drone = GameObject.Find("Drone").GetComponent<Drone>();
        StartCoroutine("getFaster");
        gameOverPanelObj = GameObject.Find("GameOverBg");
        pauseBtnObj = GameObject.Find("Pause");
        pausePanelObj = GameObject.Find("PauseBg");
        gameOverScoreTextObj = GameObject.Find("Score_Value");
        lowBatteryObj = GameObject.Find("LowBattery");
        lowBatteryText = lowBatteryObj.GetComponent<Text>();
        energyFullObj = GameObject.Find("EnergyFull");
        energy4Obj = GameObject.Find("Energy4");
        energy3Obj = GameObject.Find("Energy3");
        energy2Obj = GameObject.Find("Energy2");
        energy1Obj = GameObject.Find("Energy1");

        gameOverScoreText = gameOverScoreTextObj.GetComponent<Text>();
        pausePanelObj.SetActive(false);
        gameOverPanelObj.SetActive(false);
        lowBatteryObj.SetActive(false);
        StartCoroutine("energyTime");
        StartCoroutine("lowBattery");
        energyReduceTime = energyReduceTime * energyLevel;

        //reklam çağırma
        adsManager.RequestInterstitial();
        //fade efek
        FadeInOut.enabled = false;
        FadeInOut.raycastTarget = false;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(energyReduceTime);
        if (Drone.isCharging == true)
        {
            energy = energy + startEnergy / 100 * 20;
            lowBatteryTimer = 10;
            Drone.isCharging = false;
        }
        if (energy <= startEnergy / 100 * 100 && energy > startEnergy / 100 * 80)
        {
            energyFullObj.SetActive(true);
            energy4Obj.SetActive(false);
            energy3Obj.SetActive(false);
            energy2Obj.SetActive(false);
            energy1Obj.SetActive(false);

        }
        else if (energy <= startEnergy / 100 * 80 && energy > startEnergy / 100 * 60)
        {
            energyFullObj.SetActive(false);
            energy4Obj.SetActive(true);
            energy3Obj.SetActive(false);
            energy2Obj.SetActive(false);
            energy1Obj.SetActive(false);

        }
        else if (energy <= startEnergy / 100 * 60 && energy > startEnergy / 100 * 40)
        {
            energyFullObj.SetActive(false);
            energy4Obj.SetActive(false);
            energy3Obj.SetActive(true);
            energy2Obj.SetActive(false);
            energy1Obj.SetActive(false);

        }
        else if (energy <= startEnergy / 100 * 40 && energy > startEnergy / 100 * 20)
        {
            energyFullObj.SetActive(false);
            energy4Obj.SetActive(false);
            energy3Obj.SetActive(false);
            energy2Obj.SetActive(true);
            energy1Obj.SetActive(false);

        }
        else if (energy <= startEnergy / 100 * 20)
        {

            energyFullObj.SetActive(false);
            energy4Obj.SetActive(false);
            energy3Obj.SetActive(false);
            energy2Obj.SetActive(false);
            energy1Obj.SetActive(true);
            energy = startEnergy / 100 * 20;


        }
        if (lowBatteryTimer<=0)
        {
            Drone.lives = 0;
            lowBatteryObj.SetActive(false);
            StopCoroutine("lowBattery");
        }

        if (Drone.gameOver == true)
        {
            gameOverScoreText.text = Drone.distance.ToString() + " m";
            gameOverPanelObj.SetActive(true);
            Drone.gameOver = false;
        }
    }
    
    IEnumerator getFaster()
    {
        while (true)
        {
            if (speed > -15)
            {


                speed = speed - Time.deltaTime * gameSpeed;


            }
            else
            {
                speed = -15;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    void GameOver()
    {

    }
    public void loadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void gamePausebtn()
    {
        adsManager.ShowInterstitial();
        if (isgamePaused == false)
        {
            pausePanelObj.SetActive(true);
            Time.timeScale = 0;
            isgamePaused = true;
            Drone.lockDrone = true;
            pauseBtnObj.SetActive(false);

        }

    }
    public void gamePlaybtn()
    {

        if (isgamePaused == true)
        {

            pausePanelObj.SetActive(false);
            pauseBtnObj.SetActive(true);
            Time.timeScale = 1;
            isgamePaused = false;
            Drone.lockDrone = false;

        }

    }
    public void mainMenubtn()
    {
        

        StartCoroutine("Fading");

    }
    IEnumerator energyTime()
    {
        while (true)
        {
            if (energy > 0)
            {
                energy -= 5;
                yield return new WaitForSeconds(energyReduceTime);
                //Debug.Log(energy);
            }

            else {
                energy = 0;
            }
            yield return new WaitForSeconds(energyReduceTime);
        }

    }
    IEnumerator lowBattery()
    {
        while (true)
        {
            if (energy <= startEnergy / 100 * 20)
            {
                lowBatteryObj.SetActive(true);
                lowBatteryTimer -= 1;
                lowBatteryText.text = "LOW BATTERY ! " + lowBatteryTimer;
                yield return new WaitForSeconds(1);
                lowBatteryObj.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            
            yield return new WaitForSeconds(0);


        }
    }
    IEnumerator Fading()
    {
        Time.timeScale = 1;
        FadeInOut.enabled = true;
        FadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => FadeInOut.color.a == 1);
        SceneManager.LoadScene("MainMenu");


    }
}
    
