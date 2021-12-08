using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float bullForce;
    public GameObject player;

    private Rigidbody2D playerRB;
    private Vector2 lookVector;
    private Rigidbody2D rb;
    private WeaponHandler WeapH;
    private float lookAngle;
    private Vector2 fireVector;
    private float deviation;
    private float fireAngle;


    void Start()
    {
        rb = BulletPrefab.GetComponent<Rigidbody2D>();
        WeapH = this.GetComponent<WeaponHandler>();
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    public void Shoot(int cW, bool isMoving, float inacc = 3.5f, float movementFactor = 3f)
    {
        //inacc is the base(when at rest) maximum possible angle deviation of the random inaccuracy from the aiming angle, in DEGREES
        deviation = Random.Range(-1f, 1f);
        if (isMoving)
        {
            deviation = deviation * inacc * movementFactor;
        }
        else
        {
            deviation = deviation * inacc;
        }
        fireAngle = (lookAngle * Mathf.Rad2Deg) + deviation;
        fireAngle = fireAngle * Mathf.Deg2Rad;
        fireVector = new Vector2(Mathf.Cos(fireAngle), Mathf.Sin(fireAngle));
        Rigidbody2D bulletInstance;
        bulletInstance = Instantiate(rb, transform.position, transform.rotation) as Rigidbody2D;
        bulletInstance.velocity = playerRB.velocity;
        bulletInstance.AddForce(fireVector * bullForce);
    }
    void FixedUpdate()
    {
        lookAngle = WeapH.setAngle * Mathf.Deg2Rad;
        lookVector = new Vector2(Mathf.Cos(lookAngle), Mathf.Sin(lookAngle));
    }
}
