using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour {
    Image batteryBar;
    public bool isCharging=false;
    GameObject MoneyBoxCountTextObj;
    Text MoneyBoxCountText;
    int moneyBoxCount = 1;
    xBonusController bonusController;
	// Use this for initialization
	void Start () {
        bonusController = GameObject.Find("xBonusController").GetComponent<xBonusController>();
        MoneyBoxCountTextObj = GameObject.Find("MoneyBoxCountText");
        MoneyBoxCountText = MoneyBoxCountTextObj.GetComponent<Text>();
        batteryBar = GetComponent<Image>();
        MoneyBoxCountText.text = moneyBoxCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        
        /*   if (!isCharging)
           { 
           batteryBar.fillAmount -= 0.0001f;
           }
           else
           {
           batteryBar.fillAmount += 0.001f;
           }
           isCharging = false;*/
        if (batteryBar.fillAmount==1)
        {
            batteryBar.fillAmount = 0;
            moneyBoxCount++;
            MoneyBoxCountText.text = moneyBoxCount.ToString();
        }
        if (isCharging)
        
        {
            batteryBar.fillAmount += 0.01f;
        }
        isCharging = false;
        if (bonusController.bonusMoneyActive == true)
        {
            batteryBar.fillAmount += 0.03f;
            bonusController.bonusMoneyActive = false;
        }
    }
}
