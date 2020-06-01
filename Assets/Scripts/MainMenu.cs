using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    DateTime quitDate;
    long date_bin;
    public Text lifeCount;
    public Text notEnoughBatteryText;
    int playLife;
    bool fullLife = true;
    public Animator BatteryCountAnim;
    public Button decreaseBtn;
    public Text timerText;
    public float timeStamp;
    public bool usingTimer = false;
    GameObject upgradePanelObj;
    GameObject upgradeDronePanelObj;
    GameObject NotEnoughBatteryPanelObj;
    GameObject levelTextObj;
    int totalDistance;
    GameObject levelBarSliderObj;
    Slider levelBarSlider;
    float lastTotalDistance;
    Text levelText;
    int level;

    GameObject bulletUpgradeObj;
    Image bulletUpgrade;
    GameObject bulletObj;
    Image bullet;
    GameObject bulletBtnObj;
    Button bulletBtn;
    GameObject levelBulletTextObj;
    Text levelBulletText;
    GameObject bulletPriceTextObj;
    Text bulletPriceText;
    GameObject bulletRequiredTextObj;
    Text bulletRequiredText;
    internal int bulletLevel=1;
    public int bulletPrice;
    int firstBulletUpgrade;

    GameObject magnetUpgradeObj;
    Image magnetUpgrade;
    GameObject magnetObj;
    Image magnet;
    GameObject magnetBtnObj;
    Button magnetBtn;
    GameObject levelMagnetTextObj;
    Text levelMagnetText;
    GameObject magnetPriceTextObj;
    Text magnetPriceText;
    GameObject magnetRequiredTextObj;
    Text magnetRequiredText;
    internal int magnetLevel=1;
    public int magnetPrice;
    int firstMagnetUpgrade;

    GameObject energyUpgradeObj;
    Image energyUpgrade;
    GameObject energyObj;
    Image energy;
    GameObject energyBtnObj;
    Button energyBtn;
    GameObject levelEnergyTextObj;
    Text levelEnergyText;
    GameObject energyPriceTextObj;
    Text energyPriceText;
    GameObject energyRequiredTextObj;
    Text energyRequiredText;
    internal int energyLevel=1;
    public int energyPrice;
    int firstEnergyUpgrade;

    GameObject livesUpgradeObj;
    Image livesUpgrade;
    GameObject livesObj;
    Image lives;
    GameObject livesBtnObj;
    Button livesBtn;
    GameObject levelLivesTextObj;
    Text levelLivesText;
    GameObject livesPriceTextObj;
    Text livesPriceText;
    GameObject livesRequiredTextObj;
    Text livesRequiredText;
    internal int livesLevel = 1;
    public int livesPrice;
    int firstLivesUpgrade;

    GameObject totalMoneyTextObj;
    Text totalMoneyText;
    int totalMoney;
    int firstRun;
    //bodyupgrades

    GameObject droneBodyUpgrade01Obj;
    Button droneBodyUpgrade01;
    GameObject droneBodyUpgrade02Obj;
    Button droneBodyUpgrade02;
    GameObject droneBodyUpgrade03Obj;
    Button droneBodyUpgrade03;
    GameObject droneBodyUpgrade04Obj;
    Button droneBodyUpgrade04;

    GameObject body01TextObj;
    GameObject body02TextObj;
    GameObject body03TextObj;
    GameObject body04TextObj;

    int body02price = 10000;
    int body03price = 50000;
    int body04price = 100000;

    public Image FadeInOut;
    public Animator FadeAnimator;
    //sesler
    AudioSource auSource;
    float passedTime=0;
    double passedMin;

    GameObject adsManagerObj;
    AdsManager adsManager;
    // Use this for initialization
    void Start () {
        
        passedTime = Time.time;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        firstRun = PlayerPrefs.GetInt("FirstRunMM", 0);

        if (firstRun == 0)
        {
            PlayerPrefs.SetInt("PlayLife", 5);
            playLife = PlayerPrefs.GetInt("PlayLife");
            PlayerPrefs.SetString("date", DateTime.Now.ToBinary().ToString());
            firstRun = 1;
            PlayerPrefs.SetInt("FirstRunMM", firstRun);
        }
        //PlayerPrefs.SetFloat("lastTotalDistance", 1250);

        //PlayerPrefs.SetInt("totalMoney", 9999999);
        //resetGame();
        adsManagerObj = GameObject.Find("AdsManager");
        adsManager = adsManagerObj.GetComponent<AdsManager>();

        adsManager.RequestRewardBasedVideo();

        auSource = GetComponent<AudioSource>();
        auSource.Play();
        Time.timeScale = 1;
        bulletUpgradeObj = GameObject.Find("BulletUpgrade");
        bulletUpgrade = bulletUpgradeObj.GetComponent<Image>();
        bulletObj = GameObject.Find("Bullet");
        bullet = bulletObj.GetComponent<Image>();
        bulletBtnObj = GameObject.Find("BulletBtn");
        bulletBtn = bulletBtnObj.GetComponent<Button>();
        levelBulletTextObj = GameObject.Find("LevelBullet");
        levelBulletText = levelBulletTextObj.GetComponent<Text>();
        bulletPriceTextObj = GameObject.Find("BulletPriceText");
        bulletPriceText = bulletPriceTextObj.GetComponent<Text>();
        bulletRequiredTextObj = GameObject.Find("MagnetRequired");
        bulletRequiredText = bulletRequiredTextObj.GetComponent<Text>();

        magnetUpgradeObj = GameObject.Find("MagnetUpgrade");
        magnetUpgrade = magnetUpgradeObj.GetComponent<Image>();
        magnetObj = GameObject.Find("Magnet");
        magnet = magnetObj.GetComponent<Image>();
        magnetBtnObj = GameObject.Find("MagnetBtn");
        magnetBtn = magnetBtnObj.GetComponent<Button>();
        levelMagnetTextObj = GameObject.Find("LevelMagnet");
        levelMagnetText = levelMagnetTextObj.GetComponent<Text>();
        magnetPriceTextObj = GameObject.Find("MagnetPriceText");
        magnetPriceText = magnetPriceTextObj.GetComponent<Text>();
        magnetRequiredTextObj = GameObject.Find("MagnetRequired");
        magnetRequiredText = magnetRequiredTextObj.GetComponent<Text>();


        energyUpgradeObj = GameObject.Find("EnergyUpgrade");
        energyUpgrade = energyUpgradeObj.GetComponent<Image>();
        energyObj = GameObject.Find("Energy");
        energy = energyObj.GetComponent<Image>();
        energyBtnObj = GameObject.Find("EnergyBtn");
        energyBtn = energyBtnObj.GetComponent<Button>();
        levelEnergyTextObj = GameObject.Find("LevelEnergy");
        levelEnergyText = levelEnergyTextObj.GetComponent<Text>();
        energyPriceTextObj = GameObject.Find("EnergyPriceText");
        energyPriceText = energyPriceTextObj.GetComponent<Text>();
        energyRequiredTextObj = GameObject.Find("EnergyRequired");
        energyRequiredText = energyRequiredTextObj.GetComponent<Text>();

        livesUpgradeObj = GameObject.Find("LivesUpgrade");
        livesUpgrade = livesUpgradeObj.GetComponent<Image>();
        livesObj = GameObject.Find("Lives");
        lives = livesObj.GetComponent<Image>();
        livesBtnObj = GameObject.Find("LivesBtn");
        livesBtn = livesBtnObj.GetComponent<Button>();
        levelLivesTextObj = GameObject.Find("LevelLives");
        levelLivesText = levelLivesTextObj.GetComponent<Text>();
        livesPriceTextObj = GameObject.Find("LivesPriceText");
        livesPriceText = livesPriceTextObj.GetComponent<Text>();
        livesRequiredTextObj = GameObject.Find("LivesRequired");
        livesRequiredText = livesRequiredTextObj.GetComponent<Text>();

        firstBulletUpgrade =PlayerPrefs.GetInt("firstBulletUpgrade");
        firstMagnetUpgrade = PlayerPrefs.GetInt("firstMagnetUpgrade");
        firstEnergyUpgrade = PlayerPrefs.GetInt("firstEnergyUpgrade");
        firstLivesUpgrade = PlayerPrefs.GetInt("firstLivesUpgrade");

        droneBodyUpgrade01Obj = GameObject.Find("DroneBodyUpgrade01");
        droneBodyUpgrade01 = droneBodyUpgrade01Obj.GetComponent<Button>();
        droneBodyUpgrade02Obj = GameObject.Find("DroneBodyUpgrade02");
        droneBodyUpgrade02 = droneBodyUpgrade02Obj.GetComponent<Button>();
        droneBodyUpgrade03Obj = GameObject.Find("DroneBodyUpgrade03");
        droneBodyUpgrade03 = droneBodyUpgrade03Obj.GetComponent<Button>();
        droneBodyUpgrade04Obj = GameObject.Find("DroneBodyUpgrade04");
        droneBodyUpgrade04 = droneBodyUpgrade04Obj.GetComponent<Button>();
        body01TextObj = GameObject.Find("Body01Text");
        body02TextObj = GameObject.Find("Body02Text");
        body03TextObj = GameObject.Find("Body03Text");
        body04TextObj = GameObject.Find("Body04Text");


       
        //fade efek
        FadeInOut.enabled = false;
        FadeInOut.raycastTarget = false;



        calculatePassedMin();
        timeLeft = PlayerPrefs.GetFloat("TimeLeft");

        

        if (passedMin >= 10 && playLife<4)
        {
            FinishAction();
            
        }
        else
        {
            playLife = PlayerPrefs.GetInt("PlayLife", 5);
            lifeCount.text = playLife.ToString();
        }
        if (playLife==5)
        {
            timerText.text = "Full";
            notEnoughBatteryText.text = "Full";


        }
        else
        {
            SetTimer(3);
        }
     
       

        if (firstBulletUpgrade==0)
        {
            PlayerPrefs.SetInt("bulletPrice", 1000);
            PlayerPrefs.SetInt("bulletLevel", 1);
            firstBulletUpgrade = 1;
            PlayerPrefs.SetInt("firstBulletUpgrade", firstBulletUpgrade);
        }
        if (firstMagnetUpgrade == 0)
        {
            PlayerPrefs.SetInt("magnetPrice", 1000);
            PlayerPrefs.SetInt("magnetLevel", 1);
            firstMagnetUpgrade = 1;
            PlayerPrefs.SetInt("firstMagnetUpgrade", firstMagnetUpgrade);
        }
        if (firstEnergyUpgrade == 0)
        {
            PlayerPrefs.SetInt("energyPrice", 1000);
            PlayerPrefs.SetInt("energyLevel", 1);
            firstEnergyUpgrade = 1;
            PlayerPrefs.SetInt("firstEnergyUpgrade", firstEnergyUpgrade);
        }
        if (firstLivesUpgrade == 0)
        {
            PlayerPrefs.SetInt("livesPrice", 1000);
            PlayerPrefs.SetInt("livesLevel", 1);
            firstLivesUpgrade = 1;
            PlayerPrefs.SetInt("firstLivesUpgrade", firstLivesUpgrade);
        }

        bulletLevel = PlayerPrefs.GetInt("bulletLevel");
        magnetLevel = PlayerPrefs.GetInt("magnetLevel");
        energyLevel = PlayerPrefs.GetInt("energyLevel");
        livesLevel = PlayerPrefs.GetInt("livesLevel");
        Debug.Log(bulletLevel);
        
        totalMoneyTextObj = GameObject.Find("TotalMoneyText");
        totalMoneyText = totalMoneyTextObj.GetComponent<Text>();


        if (bulletLevel == 10)
        {
            bulletPriceText.text = "Reached full.";
        }
        else
        { 
        bulletPrice = PlayerPrefs.GetInt("bulletPrice");
        bulletPriceText.text = bulletPrice.ToString();
        }

        bulletLevel = PlayerPrefs.GetInt("bulletLevel");
        levelBulletText.text = "LVL ." + bulletLevel;

        if (magnetLevel == 10)
        {
            magnetPriceText.text = "Reached full.";
        }
        else
        {
            magnetPrice = PlayerPrefs.GetInt("magnetPrice");
            magnetPriceText.text = magnetPrice.ToString();
        }
        magnetLevel = PlayerPrefs.GetInt("magnetLevel");
        levelMagnetText.text = "LVL ." + magnetLevel;

        if (energyLevel == 10)
        {
            energyPriceText.text = "Reached full.";
        }
        else
        {
            energyPrice = PlayerPrefs.GetInt("energyPrice");
            energyPriceText.text = energyPrice.ToString();
        }
        energyLevel = PlayerPrefs.GetInt("energyLevel");
        levelEnergyText.text = "LVL ." + energyLevel;

        if (livesLevel == 10)
        {
            livesPriceText.text = "Reached full.";
        }
        else
        {
            livesPrice = PlayerPrefs.GetInt("livesPrice");
            livesPriceText.text = livesPrice.ToString();
        }
        livesLevel = PlayerPrefs.GetInt("livesLevel");
        levelLivesText.text = "LVL ." + livesLevel;

        /*bulletBtn.enabled = false;
        magnetBtn.enabled = false;
        energyBtn.enabled = false;
        livesBtn.enabled = false;*/

        totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalMoneyText.text = totalMoney.ToString();

        disabledImage(bullet);
        disabledImage(magnet);
        disabledImage(energy);
        disabledImage(lives);
        
        disabledImage(bulletUpgrade);
        disabledImage(magnetUpgrade);
        disabledImage(energyUpgrade);
        disabledImage(livesUpgrade);


        levelTextObj = GameObject.Find("LevelText");
        upgradePanelObj = GameObject.Find("UpgradePanel");
        upgradeDronePanelObj = GameObject.Find("UpgradeDronePanel");
        NotEnoughBatteryPanelObj = GameObject.Find("NotEnoughBatteryPanel");
        upgradePanelObj.SetActive(false);
        upgradeDronePanelObj.SetActive(false);
        NotEnoughBatteryPanelObj.SetActive(false);
        totalDistance =PlayerPrefs.GetInt("totalDistance");
        levelBarSliderObj = GameObject.Find("LevelBarSlider");
        levelBarSlider = levelBarSliderObj.GetComponent<Slider>();
        lastTotalDistance = PlayerPrefs.GetFloat("lastTotalDistance");
        levelText = levelTextObj.GetComponent<Text>();
        level=PlayerPrefs.GetInt("level");
        if (level==0)
        {
            level = 1;
        }
        
        lastTotalDistance = lastTotalDistance + totalDistance/level;
        PlayerPrefs.SetFloat("lastTotalDistance", lastTotalDistance);
        Debug.Log(lastTotalDistance + "=" + lastTotalDistance + "+" + totalDistance + "/" + level);
        if (lastTotalDistance>=100)
        {
            
            Debug.Log(lastTotalDistance % 100);
            lastTotalDistance = PlayerPrefs.GetFloat("lastTotalDistance");
            levelBarSlider.value = lastTotalDistance%100;
            levelText.text=((int)(lastTotalDistance / 100)).ToString();
            PlayerPrefs.SetInt("level", int.Parse(levelText.text));
            PlayerPrefs.SetFloat("lastTotalDistance", lastTotalDistance);
        }
        else
        {
            levelText.text = "0";
            lastTotalDistance = PlayerPrefs.GetFloat("lastTotalDistance");
            levelBarSlider.value = lastTotalDistance;
            lastTotalDistance += totalDistance;
            levelBarSlider.value += totalDistance;
            PlayerPrefs.SetFloat("lastTotalDistance", lastTotalDistance);
        }
        
        
        Debug.Log(lastTotalDistance);



        PlayerPrefs.DeleteKey("totalDistance");
    }
    void disabledImage(Image targetImage)
    {

        var disabledColor = targetImage.color;
        disabledColor.a = 0.5f;
        targetImage.color = disabledColor;
    }
    void enabledImage(Image targetImage)
    {

        var disabledColor = targetImage.color;
        disabledColor.a = 1f;
        targetImage.color = disabledColor;
    }
    // Update is called once per frame
    void Update () {
        if (playLife==5)
        {
            usingTimer = false;
        }
        PlayerPrefs.SetString("date", DateTime.Now.ToBinary().ToString());
        PlayerPrefs.SetFloat("TimeLeft", (float)timeLeft);

        bulletLevel = PlayerPrefs.GetInt("bulletLevel");
        magnetLevel = PlayerPrefs.GetInt("magnetLevel");
        energyLevel = PlayerPrefs.GetInt("energyLevel");
        livesLevel = PlayerPrefs.GetInt("livesLevel");

        if (usingTimer)
        {
            SetUIText();
        }

        if (level >= 10)
        {
            body02TextObj.SetActive(false);
            if (totalMoney >= body02price)
            {
                droneBodyUpgrade02.interactable = true;
            }
            else
            {
                droneBodyUpgrade02.interactable = false;
            }
        }
        if (level >= 15)
        {

            body03TextObj.SetActive(false);
            if (totalMoney >= body03price)
            {
                droneBodyUpgrade03.interactable = true;
            }
            else
            {
                droneBodyUpgrade03.interactable = false;
            }
        }
        if (level >= 20)
        {
            body04TextObj.SetActive(false);
            if (totalMoney >= body04price)
            {
                droneBodyUpgrade04.interactable = true;
            }
            else
            {
                droneBodyUpgrade04.interactable = false;
            }
        }

        //bullet
        if (bulletLevel<=4)
        { 
        if (totalMoney>100 && level>=3)
        {
            bulletBtn.enabled = true;
            enabledImage(bulletUpgrade);
            enabledImage(bullet);
            
        }
        else
        {
            bulletBtn.enabled = false;
            disabledImage(bulletUpgrade);
            disabledImage(bullet);
        }

        if (totalMoney<bulletPrice)
        {
            bulletBtn.enabled = false;
            disabledImage(bulletUpgrade);
            disabledImage(bullet);
        }
        }
        else
        {
            bulletBtn.enabled = false;
            disabledImage(bulletUpgrade);
            disabledImage(bullet);
            bulletPriceText.text = "Reached full.";
        }
        //magnet
        if (magnetLevel <= 4)
        {
            if (totalMoney > 100 && level >= 3)
            {
                magnetBtn.enabled = true;
                enabledImage(magnetUpgrade);
                enabledImage(magnet);

            }
            else
            {
                magnetBtn.enabled = false;
                disabledImage(magnetUpgrade);
                disabledImage(magnet);
                
            }
            if (totalMoney < magnetPrice)
            {
                magnetBtn.enabled = false;
                disabledImage(magnetUpgrade);
                disabledImage(magnet);
            }
        }
        else
        {
            magnetBtn.enabled = false;
            disabledImage(magnetUpgrade);
            disabledImage(magnet);
            magnetPriceText.text = "Reached full.";
        }
        //energy
        if (energyLevel <= 4)
        {
            if (totalMoney > 100 && level >= 3)
            {
                energyBtn.enabled = true;
                enabledImage(energyUpgrade);
                enabledImage(energy);

            }
            else
            {
                energyBtn.enabled = false;
                disabledImage(energyUpgrade);
                disabledImage(energy);
            }
            if (totalMoney < energyPrice)
            {
                energyBtn.enabled = false;
                disabledImage(energyUpgrade);
                disabledImage(energy);
            }
        }
        else
        {
            energyBtn.enabled = false;
            disabledImage(energyUpgrade);
            disabledImage(energy);
            energyPriceText.text = "Reached full.";
        }
        //lives
        if (livesLevel <= 2)
        {
            if (totalMoney > 100 && level >= 3)
            {
                livesBtn.enabled = true;
                enabledImage(livesUpgrade);
                enabledImage(lives);

            }
            else
            {
                livesBtn.enabled = false;
                disabledImage(livesUpgrade);
                disabledImage(lives);
            }
            if (totalMoney < livesPrice)
            {
                livesBtn.enabled = false;
                disabledImage(livesUpgrade);
                disabledImage(lives);
            }
        }
        else
        {
            livesBtn.enabled = false;
            disabledImage(livesUpgrade);
            disabledImage(lives);
            livesPriceText.text = "Reached full.";
        }
    }
    public void startGame()
    {
        
        
        if (playLife == 5)
        {
            passedTime = Time.time;
            calculatePassedMin();
            SetTimer(3);
            playLife = PlayerPrefs.GetInt("PlayLife");
            playLife -= 1;
            PlayerPrefs.SetInt("PlayLife", playLife);
            playLife = PlayerPrefs.GetInt("PlayLife");
            lifeCount.text = playLife.ToString();
            fullLife = true;
            StartCoroutine("Fading");
        }
        else
        {
            
            if (playLife < 1)
            {

                NotEnoughBatteryPanel();
            }
            else
            {
                playLife = PlayerPrefs.GetInt("PlayLife");
                playLife -= 1;
                PlayerPrefs.SetInt("PlayLife", playLife);
                lifeCount.text = playLife.ToString();
                fullLife = false;
                StartCoroutine("Fading");
            }
            
        }
        

    }
    public void upgradePanel()
    {
        upgradePanelObj.SetActive(true);
    }
    public void upgradeDronePanel()
    {
        upgradeDronePanelObj.SetActive(true);
    }
    public void NotEnoughBatteryPanel()
    {
        NotEnoughBatteryPanelObj.SetActive(true);
    }
    public void upgradePanelExit()
    {
        upgradePanelObj.SetActive(false);
    }
    public void upgradeDronePanelExit()
    {
        upgradeDronePanelObj.SetActive(false);
    }
    public void NotEnoughBatteryPanelExit()
    {
        NotEnoughBatteryPanelObj.SetActive(false);
    }
    public void upgradeBullet()
    {
        bulletLevel++;
        levelBulletText.text = "LVL ." + bulletLevel;
        PlayerPrefs.SetInt("bulletLevel", bulletLevel);
        totalMoney -= bulletPrice;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        totalMoneyText.text = totalMoney.ToString();
        bulletLevel = PlayerPrefs.GetInt("bulletLevel");
        bulletPrice *= bulletLevel;
        bulletPriceText.text = bulletPrice.ToString();
        PlayerPrefs.SetInt("bulletPrice", bulletPrice);
    }
    public void upgradeMagnet()
    {
        magnetLevel++;
        levelMagnetText.text = "LVL ." + magnetLevel;
        PlayerPrefs.SetInt("magnetLevel", magnetLevel);
        totalMoney -= magnetPrice;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        totalMoneyText.text = totalMoney.ToString();
        magnetLevel = PlayerPrefs.GetInt("magnetLevel");
        magnetPrice *= magnetLevel;
        magnetPriceText.text = magnetPrice.ToString();
        PlayerPrefs.SetInt("magnetPrice", magnetPrice);
    }
    public void upgradeEnergy()
    {
        energyLevel++;
        levelEnergyText.text = "LVL ." + energyLevel;
        PlayerPrefs.SetInt("energyLevel", energyLevel);
        totalMoney -= energyPrice;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        totalMoneyText.text = totalMoney.ToString();
        energyLevel = PlayerPrefs.GetInt("energyLevel");
        energyPrice *= energyLevel;
        energyPriceText.text = energyPrice.ToString();
        PlayerPrefs.SetInt("energyPrice", energyPrice);

    }
    public void upgradeLives()
    {
        livesLevel++;
        levelLivesText.text = "LVL ." + livesLevel;
        PlayerPrefs.SetInt("livesLevel", livesLevel);
        totalMoney -= livesPrice;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        totalMoneyText.text = totalMoney.ToString();
        livesLevel = PlayerPrefs.GetInt("livesLevel");
        livesPrice *= livesLevel;
        livesPriceText.text = livesPrice.ToString();
        PlayerPrefs.SetInt("livesPrice", livesPrice);
    }
    void resetGame()
    {
        PlayerPrefs.SetInt("bulletLevel", 1);
        PlayerPrefs.SetInt("magnetLevel", 1);
        PlayerPrefs.SetInt("energyLevel", 1);
        PlayerPrefs.SetInt("livesLevel", 1);
        bulletPrice = 1000;
        magnetPrice = 1000;
        energyPrice = 1000;
        livesPrice = 1000;
        PlayerPrefs.SetInt("bulletPrice", bulletPrice);
        PlayerPrefs.SetInt("magnetPrice", magnetPrice);
        PlayerPrefs.SetInt("energyPrice", energyPrice);
        PlayerPrefs.SetInt("livesPrice", livesPrice);
    }
    IEnumerator Fading()
    {
        FadeInOut.enabled = true;
        FadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => FadeInOut.color.a == 1);
        SceneManager.LoadScene("Game");
        

    }
    public void SetTimer(float time)
    {
        if (usingTimer)
            return;


        if (playLife==5)
        {
            timeStamp = 600;
            usingTimer = true;
        }
        else
        {
            timeLeft = PlayerPrefs.GetFloat("TimeLeft");
           
            timeStamp =(float)timeLeft;
            Debug.Log("timestamp    " + timeStamp);
            usingTimer = true;
        }
        
    }
    double timeLeft;
    public void SetUIText()
    {
    
        
        if (usingTimer==true)
        {
            

            timeLeft = timeStamp - Time.time + passedTime - (passedMin * 60);
                Debug.Log(timeStamp + " " + Time.time + " " + passedTime + " " + passedMin * 60);
            Debug.Log((timeLeft).ToString());
            PlayerPrefs.SetFloat("TimeLeft", (float)timeLeft);

           

;        }

        if (timeLeft<=0)
        {
            FinishAction();
            return;
        }
        double hours;
        double minutes;
        double seconds;
        double miniseconds;
        GetTimeValues(timeLeft, out hours, out minutes, out seconds, out miniseconds);

        if (hours>0)
        {
            timerText.text = string.Format("{0}:{1}",hours, minutes);
            notEnoughBatteryText.text = string.Format("{0}:{1}", hours, minutes);
        }
        else // if (minutes>0) mini seconds kullanmak için
        {
            timerText.text = string.Format("{0}:{1}", minutes, seconds);
            notEnoughBatteryText.text = string.Format("{0}:{1}", minutes, seconds);
        }
        /* miniseconds kullanmak için
        else
        {
            timerText.text = string.Format("{0}:{1}", seconds, miniseconds);
        }*/

    }
    public void GetTimeValues(double time, out double hours, out double minutes, out double seconds, out double miniseconds)
    {
        hours = (int)(time / 3600f);
        minutes = (int)((time-hours* 3600)/ 60f);
        seconds = (int)((time - hours * 3600-minutes*60));
        miniseconds=(int)((time - hours * 3600 - minutes * 60- seconds)*100);
    }
    public void FinishAction()
    {
        playLife = 5;
        PlayerPrefs.SetInt("PlayLife", playLife);
        timerText.text = "Full";
        notEnoughBatteryText.text = "Full";
        lifeCount.text = playLife.ToString();
        PlayerPrefs.SetFloat("TimeLeft", 600);
        PlayerPrefs.SetString("date", DateTime.Now.ToBinary().ToString());
        usingTimer = false;
    }
    void OnApplicationQuit()
    {
        
        PlayerPrefs.SetString("date", DateTime.Now.ToBinary().ToString());
        PlayerPrefs.SetFloat("TimeLeft", (float)timeLeft);
        Debug.Log(timeLeft.ToString());

        System.DateTime datevalue1 = new System.DateTime(2018, 5, 29,22,27,00);
        System.DateTime datevalue2 = System.DateTime.Now;

        

        double hours = (datevalue2 - datevalue1).TotalMinutes;
        Debug.Log("It has been " + hours.ToString() + " hours since the beginning of the year");
        Debug.Log(datevalue1.ToString());
    }
    public void decreaseLifeCount()
    {

        playLife += 1;
        PlayerPrefs.SetInt("PlayLife", playLife);

    }
    public void calculatePassedMin()
    {
        long old_date_bin = long.Parse(PlayerPrefs.GetString("date"));
        quitDate = DateTime.FromBinary(old_date_bin);
        System.DateTime nowDate = System.DateTime.Now;
        passedMin = (nowDate - quitDate).TotalMinutes;
        Debug.Log("geçen süre " + passedMin.ToString());
    }
    public void showRewardedVideo()
    {
        adsManager.ShowRewardBasedVideo();
    }
    public void buyFullVersion()
    {
        IAPManager.Instance.BuyFullVersion();
    }
}
