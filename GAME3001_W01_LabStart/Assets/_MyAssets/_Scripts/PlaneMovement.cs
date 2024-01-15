using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;
    [SerializeField] Vector3 m_targetPosition;
    [SerializeField] float m_speed = 5f;
    

   
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            m_targetPosition = m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
            m_targetPosition.z = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, m_targetPosition, 5 * Time.deltaTime);
    }
}
