using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgentObject2 : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
