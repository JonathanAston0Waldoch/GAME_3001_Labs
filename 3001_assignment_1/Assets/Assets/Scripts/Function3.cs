using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Function3 : AgentObject3
{
    [SerializeField]
    public GameObject Agent3;
    [SerializeField]
    public GameObject Target3;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb3;
    

    
    new void Start()
    {
        base.Start();
        rb3 = GetComponent<Rigidbody2D>();

        
    }

    private void Arrival()
    {
        Vector2 desiredVelocity = (TargetPosition - transform.position).normalized * moveSpeed;
        Vector2 steeringForce = desiredVelocity - rb3.velocity;

        Vector2 steering = desiredVelocity - rb3.velocity;
        
        

        rb3.AddForce(steeringForce);
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, moveSpeed * Time.deltaTime);
        rb3.velocity = desiredVelocity;

        float distance = (desiredVelocity.magnitude);

        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        int i = 10;
        while (i > 0)
        {
            rb3.velocity = rb3.velocity / 3 / 4 ;
            rb3.velocity += rb3.velocity;
            i--;
        }
    }
    public void ResetScene(int sceneIndextoLoad)
    {
        sceneIndextoLoad = 1;
        SceneLoader.LoadSceneByIndex(sceneIndextoLoad);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Agent3.SetActive(true);
            Target3.SetActive(true);
            Arrival();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ResetScene(1);
        }
    }
}
