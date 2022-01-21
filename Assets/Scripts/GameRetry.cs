using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRetry : MonoBehaviour
{
    public Text roundsText;
    

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString(); //displays the number of rounds(waves) the player has survived
    }


    public void Retry()
    {
        
        SceneManager.LoadScene(1); //reloads the MainScene
    }

    
}
