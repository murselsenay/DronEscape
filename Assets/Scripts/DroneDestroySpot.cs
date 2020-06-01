using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDestroySpot : MonoBehaviour {
    Animator droneDestroySpot;
    Drone drone;
    // Use this for initialization
    void Start () {
        drone = GameObject.Find("Drone").GetComponent<Drone>();
        droneDestroySpot= GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (drone.isDamaged==true)
        {
            StartCoroutine("takeDamage");
            drone.isDamaged = false;
        }
	}
    IEnumerator takeDamage()
    {
        droneDestroySpot.SetBool("isDroneDamaged", true);
        yield return new WaitForSeconds(0.4f);
        droneDestroySpot.SetBool("isDroneDamaged", false);
    }
}
