using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentObject : MonoBehaviour
{
    [SerializeField] Transform m_target;

    public Vector3 TargetPosition
    {
        get { return m_target.position; }
        set { m_target.position = value; }
    }

    // Update is called once per frame
    public void Start()
    {
        Debug.Log("starting Agent ...");
        TargetPosition = m_target.position;
    }
}
