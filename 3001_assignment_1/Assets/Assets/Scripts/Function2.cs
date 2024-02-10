using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Function2 : AgentObject2
{
    [SerializeField]
    public GameObject Agent2;
    [SerializeField]
    public GameObject Target2;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2;
    new void Start()
    {
        base.Start();
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void Fleeing()
    {
        Vector2 desiredVelocity = ( - TargetPosition + transform.position).normalized * moveSpeed;
        Vector2 steeringForce = desiredVelocity - rb2.velocity;

        
        rb2.AddForce(steeringForce);
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, moveSpeed * Time.deltaTime);
        rb2.velocity = desiredVelocity;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Agent2.SetActive(true);
            Target2.SetActive(true);
            Fleeing();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Agent2.SetActive(false);
            Target2.SetActive(false);
        }
    }
}
