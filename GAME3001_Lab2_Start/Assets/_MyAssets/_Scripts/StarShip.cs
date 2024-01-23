using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : AgentObject
{
    [SerializeField]
    float movementSpeed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start(); // explicitly invoking Start of AgentObject
        Debug.Log("Starting starship");

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetPosition != null)
        {
            Seek();
        }
    }

    private void Seek()
    {
        //Calculate desired velocity using kinematic seek equation
        Vector2 desiredVelocity = (TargetPosition - transform.position).normalized * movementSpeed;
        //Calculate the steering force 
        //Check current velocity and only apply for difference between desired velocity and current velocity 
        Vector2 steeringForce = desiredVelocity - rb.velocity; 

        //Apply the steering force to the agent 
        rb.AddForce(steeringForce);
    }
}
