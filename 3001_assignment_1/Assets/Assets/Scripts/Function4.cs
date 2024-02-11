using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Function4 : AgentObject4
{
    [SerializeField]
    public GameObject Agent4;
    [SerializeField]
    public GameObject Target4;
    [SerializeField] public GameObject obstacle;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField] float whiskerLength = 1.5f;
    [SerializeField] float frontWhiskerAngle = 45f;
    [SerializeField] float backWhiskerAngle = 135f;
    [SerializeField] float avoidanceWeight = 2f;
    private Rigidbody2D rb4;
    new void Start()
    {
        base.Start();
        rb4 = GetComponent<Rigidbody2D>();
    }

    private void Avoid()
    {
        bool hitleft = CastWhisker(frontWhiskerAngle);
        bool hitright = CastWhisker(-frontWhiskerAngle);
        bool hitBackLeft = CastWhisker(backWhiskerAngle);
        bool hitBackRight = CastWhisker(-backWhiskerAngle);

        // Adjust rotation based on detected obstacles.
        if (hitleft)
        {
            // Rotate clockwise if the left whisker is hit
            RotateClockwise();
        }
        else if (hitright & !hitleft)
        {
            // Rotate counterclockwise if the right whisker hit
            RotateCounterClockwise();
        }
        // Adjust rotation based on detected obstacles.
        if (hitBackLeft)
        {
            // Rotate clockwise if the left whisker is hit
            RotateClockwise();
        }
        else if (hitBackRight & !hitBackLeft)
        {
            RotateCounterClockwise();
        }
    }
    private void RotateClockwise()
    {
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;
        // Rotate clockwise based on rotationSpeed and a weight.
        transform.Rotate(Vector3.forward, -rotationSpeed * avoidanceWeight * Time.deltaTime);

        rb4.velocity = directionToTarget * moveSpeed;
    }
    private void RotateCounterClockwise()
    {
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;
        // Rotate counterclockwise based on rotationSpeed and a weight.
        transform.Rotate(Vector3.forward, rotationSpeed * avoidanceWeight * Time.deltaTime);

        rb4.velocity = transform.up * moveSpeed;
        
        rb4.velocity += directionToTarget * moveSpeed;
    }
    private bool CastWhisker(float angle)
    {
        Color rayColor = Color.red;
        bool hitResult = false;

        // Calculate the direction of the whisker
        Vector2 whiskerDirection = Quaternion.Euler(0, 0, angle) * transform.up;

        // Cast a ray in the whisker direction;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, whiskerDirection, whiskerLength);

        // Check if the ray hits an obstacle
        if (hit.collider != null)
        {
            Debug.Log("Obstacle Detected!!!");

            rayColor = Color.green;
            hitResult = true;
        }
        Debug.DrawRay(transform.position, whiskerDirection * whiskerLength, rayColor);
        return hitResult;
    }
    private void SeekForward()
    {
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;
        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90.0f;
        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);
        rb4.velocity = directionToTarget * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Target")
        {
            Debug.Log("succesfuly avoided the obstacle");
            // What is this!?! Didn't you learn how to create a static sound manager last week in 1017?
        }
    }
    public void ResetScene(int sceneIndextoLoad)
    {
        sceneIndextoLoad = 1;
        SceneLoader.LoadSceneByIndex(sceneIndextoLoad);
    }
    void Update()
    {
        Avoid();
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Agent4.SetActive(true);
            Target4.SetActive(true);
            obstacle.SetActive(true);
            SeekForward();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ResetScene(1);
        }
    }
}
