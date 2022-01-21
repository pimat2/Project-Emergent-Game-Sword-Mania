using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitKey : MonoBehaviour
{
       void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
