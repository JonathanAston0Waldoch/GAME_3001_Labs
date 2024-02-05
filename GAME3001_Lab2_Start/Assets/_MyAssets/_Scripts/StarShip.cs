using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : AgentObject
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float rotationSpeed;

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
            //Seek();
            SeekForwards();
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

    private void SeekForwards() // always move towards while rotating to the target.
    {
        //Calculate direction to the target 
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;

        //Caluclate the angle to rotate towards the target 
        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90;

        //Smoothly rotate towards the target 
        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z); //Delta angle from target to ship
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);

        // Move along the forward vector using Rigidbody2D
        rb.velocity = transform.up * movementSpeed;
    }
}
