using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameIsOver = false;

    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        if (gameIsOver)
            return;
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }


    void EndGame()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner"); //destroys the wave spawners so that no enemies keep on spawning at gameover screen
            foreach (GameObject spawner in spawners)
            GameObject.Destroy(spawner);
     GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //destroys the enemies in the scene, because they will keep making sounds otherwise
         foreach(GameObject enemy in enemies)
         GameObject.Destroy(enemy);
        gameIsOver = true;
        Debug.Log("Game over!");
        gameOverUI.SetActive(true);
    }

}
