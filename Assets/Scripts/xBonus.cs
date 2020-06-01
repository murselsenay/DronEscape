using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xBonus : MonoBehaviour {
    bool moveTowards = true;
	// Use this for initialization
	void Start () {
            
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x<0 && moveTowards==true)
        {

            transform.Translate(new Vector3(0.4f, 0, 0));
        }
        else
        {
            if (transform.position== GameObject.Find("xBonusTarget").transform.position)
            {
                Destroy(gameObject);
            }
            else {
                transform.localScale -= new Vector3(0.02f, 0.02f, 0);
                moveTowards = false;
            xBonusTowards();
            }
        }
        
	}
    
    void xBonusTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("xBonusTarget").transform.position, Time.deltaTime *10);
    }
}
