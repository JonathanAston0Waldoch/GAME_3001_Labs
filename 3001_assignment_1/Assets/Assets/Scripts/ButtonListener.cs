using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 on the keyboard was pressed!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2 on the keyboard was pressed!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 on the keyboard was pressed!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4 on the keyboard was pressed!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("5 on the keyboard was pressed!");
        }
    }
}
