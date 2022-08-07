using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetEvent : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu; 

    public void Pause(){
		pauseMenu.SetActive(true); 
        Time.timeScale = 0f; 

	}

    public void Resume(){
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f; 

    }

    public void Home(){
        Time.timeScale = 1f; 
		SceneManager.LoadScene("MenuScene"); 

	}

    public void Reset(){
        /*ObstaclesRespawn currentObstacle = GameObject.FindGameObjectsWithTag("ObstacleRespawn").GetComponent<ObstaclesRespawn>();
        currentObstacle.Respawn(); */
        GameObject[] i = GameObject.FindGameObjectsWithTag("Player");
        
        /*HealthBar pv = GameObject.FindGameObjectsWithTag("Player").GetComponent<HealthBar>();
        pv.resetLife(); */
    }
    


}
