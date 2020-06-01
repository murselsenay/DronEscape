using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGroup : MonoBehaviour {

    public float backgroundSize;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++)
        {
            layers[i] = transform.GetChild(i);
            leftIndex = 0;
            rightIndex = layers.Length - 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) 
        {
            ScrollLeft();
        }
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x + viewZone)) 
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {

        layers[rightIndex].position = Vector2.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
            }

    private void ScrollRight()
    {

        layers[leftIndex].position = Vector2.left * (layers[rightIndex].position.x - backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex < 0)
        {
            leftIndex = layers.Length - 1;
        }
    }

}
