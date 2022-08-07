using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinishScript : MonoBehaviour
{

    [SerializeField] 
    private GameObject _cutscene;

    
   


    void OnTriggerEnter2D(Collider2D other)
    {
   
      if(other.CompareTag("Player"))
      {
       Debug.Log("aaaaa");      
      _cutscene.SetActive(true);
      }

    }

    



}

