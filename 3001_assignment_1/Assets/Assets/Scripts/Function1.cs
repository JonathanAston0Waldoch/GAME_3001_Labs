using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Function1 : AgentObject
{
    [SerializeField]
    public GameObject Agent1;
    [SerializeField]
    public GameObject Target1;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotationSpeed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }
    void Lookat2D(Vector3 target)
    {
        Vector3 LookDirection = target - transform.position;
        float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void Seeking()
    {
        Lookat2D(TargetPosition);

        Vector2 desiredVelocity = (TargetPosition - transform.position).normalized * moveSpeed;
        Vector2 steeringForce = desiredVelocity - rb.velocity;

        
        rb.AddForce(steeringForce);
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, moveSpeed * Time.deltaTime);
        rb.velocity = desiredVelocity;
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Target")
        {
            Agent1.SetActive(false);
            Target1.SetActive(false);
        }
    }
    public void ResetScene(int sceneIndextoLoad)
    {
        sceneIndextoLoad = 1;
        SceneLoader.LoadSceneByIndex(sceneIndextoLoad);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Agent1.SetActive(true);
            Target1.SetActive(true);
            
                Seeking();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ResetScene(1);
        }
    }
}
