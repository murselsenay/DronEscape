using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    
    public int adaptPosition;
    public bool maintainWidth = true;
    float defaultWidth;
    float defaultHeight;

    Vector3 CameraPos;
	// Use this for initialization
	void Start () {
        CameraPos = Camera.main.transform.position;
        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
		if (maintainWidth==true)
        {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;

            Camera.main.transform.position = new Vector3(CameraPos.x, 1 * (defaultHeight - Camera.main.orthographicSize), CameraPos.z);
        }
        else
        {
            Camera.main.transform.position = new Vector3(1 * (defaultWidth - Camera.main.orthographicSize * Camera.main.aspect), CameraPos.y, CameraPos.z);
        }
	}
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, orginalPos.z);
            
            elapsed += Time.deltaTime;

            yield return null;

        }

        transform.localPosition = orginalPos;
    }
}
