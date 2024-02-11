using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Vector3 targetPosition = Vector3.zero;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
