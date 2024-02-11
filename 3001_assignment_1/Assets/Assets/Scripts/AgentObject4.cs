using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AgentObject4 : MonoBehaviour
{
    [SerializeField]
    Transform m_target;


    public Vector3 TargetPosition
    {
        get { return m_target.position; }
        set { m_target.position = value; }
    }
    public void Start()
    {
        TargetPosition = m_target.position;
    }

    
    
}
