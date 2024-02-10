using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentObject : MonoBehaviour
{
    [SerializeField]
    Transform m_target;
    

    public Vector3 TargetPosition
    {
        get { return m_target.position; }
        set { m_target.position = value;}
    }
    // Start is called before the first frame update
    public void Start()
    {
        TargetPosition = m_target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
