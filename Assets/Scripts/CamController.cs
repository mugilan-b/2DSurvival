using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private float mousePositionX;
    private float mousePositionY;
    private float desiredX = 0;
    private float desiredY = 0;
    private Camera Cam;
    private float XSize;
    private float YSize;
    private Vector2 XYSize;
    private bool isEnabled = false;
    private float camHeight; //Height (Z value) at which Camera is present, we use -10
    
    public GameObject Player;
    public float moveConstant;  //Typical Value = 10
    //Moveconstant is a measure of maximum offset the camera can have from the player

    void Start()
    {
        Cam = this.GetComponent<Camera>();
        Vector3 p = Cam.ViewportToWorldPoint(new Vector3(1, 1, Cam.nearClipPlane));
        XSize = p.x - Player.transform.position.x;
        YSize = p.y - Player.transform.position.y;
        XYSize = new Vector2(XSize, YSize);
    }


    void Update()
    {
        camHeight = transform.localPosition.z;
        if(Input.GetKeyDown(KeyCode.E))
        {
            isEnabled = !isEnabled;
        }
        if(isEnabled)
        { 
            mousePositionX = Input.mousePosition.x;
            mousePositionY = Input.mousePosition.y;
            if (mousePositionX <= Screen.currentResolution.width && mousePositionY <= Screen.currentResolution.height)
            {
                desiredX = (XSize * (((mousePositionX - (Screen.currentResolution.width / 2)) * moveConstant) / Screen.currentResolution.width));
                desiredY = (YSize * (((mousePositionY - (Screen.currentResolution.height / 2)) * moveConstant) / Screen.currentResolution.height));
            }
            transform.localPosition = new Vector3(desiredX, desiredY, camHeight);
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                transform.localPosition = new Vector3(0, 0, camHeight);
            }
        }
    }
}

