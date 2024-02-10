using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Function1 : MonoBehaviour
{
    [SerializeField]
    public GameObject Agent1;
    [SerializeField]
    public GameObject Target1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Seeking()
    {

    }
    // Update is called once per frame
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
            Agent1.SetActive(false);
            Target1.SetActive(false);
        }
    }
}
