using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    /* Make sure you've entered values and referenced RB2D of Player in the Inspector
     * Typical values of variables given in comments
     * W/S = Y Axis
     * A/D = X Axis
     */
    public float maxSpeed;          //typical value = 10  
    public float force;             //typical value = 400
    public Rigidbody2D playerRB;
    public float frictionConst;     //typical value = 60

    private float x;
    private float y;
    private float X;
    private float Y;
    private float vx;
    private float vy;
    private Vector2 friction;
    private Vector2 moveVector;

    void Start()
    {
        playerRB = playerRB.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal"); //a, d
        y = Input.GetAxis("Vertical"); //w, s
        vx = playerRB.velocity.x;
        vy = playerRB.velocity.y;

        friction = new Vector3(vx * frictionConst, vy * frictionConst);

        if (Mathf.Abs(playerRB.velocity.x) >= maxSpeed)
        {
            X = 0;
        }
        else
        {
            X = x;
        }

        if (Mathf.Abs(playerRB.velocity.y) >= maxSpeed)
        {
            Y = 0;
        }
        else
        {
            Y = y;
        }

        moveVector = new Vector2(X * force, Y * force) - friction;
        playerRB.AddRelativeForce(moveVector);
    }

}
