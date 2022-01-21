using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyonLoad : MonoBehaviour
{
    //keeps the MainTheme object persistent trough scenes
    private void Awake() {
        
        DontDestroyOnLoad(transform.gameObject);
    }
}
