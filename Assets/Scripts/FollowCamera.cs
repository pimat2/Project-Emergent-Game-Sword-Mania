using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //makes sure that the player is followed by the camera
    public GameObject thingtoFollow;
    void LateUpdate()
    {
        transform.position = thingtoFollow.transform.position + new Vector3(0,0,-10); 
    }
    
}
