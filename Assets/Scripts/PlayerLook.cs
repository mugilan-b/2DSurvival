using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public GameObject toRotate;
    public float deadZone;

    private Vector3 dispVect;
    private Vector3 lookDir;
    private float xVal;
    private float yVal;
    private float desiredX;
    private float desiredY;

    // Start is called before the first frame update
    void Start()
    {
        dispVect = new Vector3(0f, 0f, 0f); 
        lookDir = new Vector3(0f, 0f, 0f);
        xVal = 0f;
        yVal = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        xVal = Input.mousePosition.x;
        yVal = Input.mousePosition.y;
        desiredX = xVal - (Screen.currentResolution.width / 2);
        desiredY = yVal - (Screen.currentResolution.height / 2);
        dispVect = new Vector3(desiredX, desiredY, 0);
        if(dispVect.magnitude > deadZone)
        {
            //Debug.Log(dispVect);
            Debug.Log(new Vector2(desiredX, desiredY));
            toRotate.transform.up = dispVect.normalized;
        }      

    }
}
