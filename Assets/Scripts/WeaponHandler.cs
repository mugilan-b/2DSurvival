using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public int currWeap;
    public float setAngle = 0f;
    public float sizeOfDeadZone;
    //Size of Rotation deadzone is in pixels. 35 would be an appropriate value.
    public float fireRateDelay;
    public int fireMode = 2;
    //fireMode = 0 -> single; 1 -> burst-fire/3shot; -> 2 -> automatic;
    public int currentAmmo;
    public int maxMagAmmo;
    public GameObject player;

    public int totalAmmo;
    public float reloadTime;

    private Rigidbody2D playerRB2;
    private float theta = 0f;
    private float distanceToMouseCursor = 0f;
    private float xDisp = 0f;
    private float yDisp = 0f;
    private Fire fire;
    private float nextFire;
    private int i = 1;
    private int magtemp;
    private float coolDownEnd;


    void Start()
    {
        fire = this.GetComponent<Fire>();
        maxMagAmmo = 300;
        currentAmmo = maxMagAmmo;
        totalAmmo = 900;
        reloadTime = 1;
        playerRB2 = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        xDisp = Input.mousePosition.x - (Screen.currentResolution.width / 2);
        yDisp = Input.mousePosition.y - (Screen.currentResolution.height / 2);
        distanceToMouseCursor = Mathf.Sqrt((xDisp * xDisp) + (yDisp * yDisp));
        if (distanceToMouseCursor > sizeOfDeadZone)
        {
            theta = Mathf.Atan((Input.mousePosition.y - (Screen.currentResolution.height / 2)) / ((Input.mousePosition.x - (Screen.currentResolution.width / 2)))) * Mathf.Rad2Deg;
            if (Input.mousePosition.y > Screen.currentResolution.height / 2)
            {
                if (theta < 0f)
                {
                    setAngle = theta + 180f;
                }
                if (theta > 0f)
                {
                    setAngle = theta;
                }
            }
            if (Input.mousePosition.y < Screen.currentResolution.height / 2)
            {
                if (theta > 0f)
                {
                    setAngle = theta + 180f;
                }
                if (theta < 0f)
                {
                    setAngle = theta + 360f;
                }
            }
            if (theta == 0f)
            {
                if (Input.mousePosition.x > Screen.currentResolution.width / 2)
                {
                    setAngle = 0f;
                }
                if (Input.mousePosition.x < Screen.currentResolution.width / 2)
                {
                    setAngle = 180f;
                }
            }
        }
        transform.eulerAngles = new Vector3(0.0f, 0.0f, setAngle);
        if (fireMode == 0)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextFire && currentAmmo > 0 && Time.time > coolDownEnd)
            {
                nextFire = Time.time;
                if (playerRB2.velocity.magnitude != 0)
                {
                    fire.Shoot(currWeap, true);
                }
                if (playerRB2.velocity.magnitude == 0)
                {
                    fire.Shoot(currWeap, false);
                }
                currentAmmo -= 1;
                nextFire = nextFire + fireRateDelay;
            }
        }
        if (fireMode == 1)
        {
            //To-Do burst fire

        }
        if (fireMode == 2)
        {
            if (Input.GetButton("Fire1") && currentAmmo > 0)
            {
                if (Time.time >= nextFire && Time.time > coolDownEnd)
                {
                    nextFire = Time.time;
                    if (playerRB2.velocity.magnitude != 0)
                    {
                        fire.Shoot(currWeap, true);
                    }
                    if (playerRB2.velocity.magnitude == 0)
                    {
                        fire.Shoot(currWeap, false);
                    }
                    currentAmmo -= 1;
                    nextFire = nextFire + fireRateDelay;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && totalAmmo > 0 && Time.time > coolDownEnd)
        {
            coolDownEnd = Time.time + reloadTime;
            magtemp = maxMagAmmo - currentAmmo;  // Number of bullets to be reloaded
            if (totalAmmo > magtemp)
            {
                totalAmmo = totalAmmo - magtemp;
                currentAmmo = maxMagAmmo;
            }
            else
            {
                currentAmmo = currentAmmo + totalAmmo;
                totalAmmo = 0;
            }
        }
    }
}
