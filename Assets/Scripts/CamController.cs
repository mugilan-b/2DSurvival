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
    private bool isEnabled = false;
    private float camHeight;    //Height (Z value) at which Camera is present, we use -10
    private bool isStarted = false;
    private Vector3 targetPos;
    private bool justStarted = false;

    public GameObject Player;
    public float spd;   //Measure of how fast it smoothly moves on disable. Typical = 20
    public float spd2;  //Measure of how fast it smoothly moves on enable. Typical = 10
    public float moveConstant;  //Typical Value = 1.2
    //Moveconstant is a measure of maximum offset the camera can have from the player

    void Start()
    {       
        Cam = this.GetComponent<Camera>();
        Vector3 p = Cam.ViewportToWorldPoint(new Vector3(1, 1, Cam.nearClipPlane));
        XSize = p.x - Player.transform.position.x;
        YSize = p.y - Player.transform.position.y;
        camHeight = transform.localPosition.z;
    }

    IEnumerator MoveTowards()
    {           
        if(transform.localPosition.x != 0f && transform.localPosition.y != 0f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, 0f, camHeight), Time.deltaTime * spd);
            yield return null;
        }
        else
        {
            isStarted = false;
        }
    }
    IEnumerator MoveTowards2()
    {
        if((transform.localPosition.x - targetPos.x) != 0f && (transform.localPosition.y - targetPos.y) != 0f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * spd2);
            yield return null;
        }
        else
        {
            justStarted = false;
        }
    }

    void Update()
    {
        if(isStarted)
        {
            StartCoroutine(MoveTowards());
        }        
        //camHeight = transform.localPosition.z;
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!isEnabled)
            {
                justStarted = true;
            }
            isEnabled = !isEnabled;            
        }
        if(isEnabled)
        { 
            mousePositionX = Input.mousePosition.x;
            mousePositionY = Input.mousePosition.y;
            if (mousePositionX <= Screen.currentResolution.width && mousePositionY <= Screen.currentResolution.height)
            {
                desiredX = XSize * (((mousePositionX - (Screen.currentResolution.width / 2)) * moveConstant) / Screen.currentResolution.width);
                desiredY = YSize * (((mousePositionY - (Screen.currentResolution.height / 2)) * moveConstant) / Screen.currentResolution.height);
            }
            targetPos = new Vector3(desiredX, desiredY, camHeight);
            if(justStarted)
            {
                StartCoroutine(MoveTowards2());
            }                        
        }
        else
        {
            if(!isStarted)
            {
                isStarted = true;
                StartCoroutine(MoveTowards());
            }
        }
    }
}

