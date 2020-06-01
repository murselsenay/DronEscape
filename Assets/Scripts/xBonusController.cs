using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xBonusController : MonoBehaviour {
    public GameObject xBonus;
    public bool bonusActive = false;
    bool bonusReady = false;
    int bonusCounter = 0;
    int bonusActiveCounter = 0;
    public bool bonusMoneyActive=false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (bonusActive==true)
        {
            bonusActiveCounter += 1;
            bonusActive = false;
        }
        if (bonusActiveCounter==1)
        {
            StartCoroutine("bonusActiveRoutine");
        }
        else if (bonusActiveCounter==2 && bonusReady==true)
        { 
        if (bonusReady==true && bonusCounter<1)
        {
            Instantiate(xBonus, new Vector2(transform.position.x, 0), Quaternion.identity);
            bonusMoneyActive = true;
            bonusCounter = 1;
        }
        }
    }
    IEnumerator bonusActiveRoutine()
    {

        bonusReady = true;
        yield return new WaitForSeconds(2);
        bonusReady = false;
        bonusActive = false;
        bonusCounter = 0;
        bonusActiveCounter = 0;

        }

    }

