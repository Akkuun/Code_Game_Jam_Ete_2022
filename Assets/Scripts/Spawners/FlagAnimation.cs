using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlagAnimation : MonoBehaviour
{
    public Animator m_animator;
    private GameObject[] goArray;
    [SerializeField] private AudioSource checkpointSound;
    void Start()
    {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Checkpoint");
  
        goArray = gameObjectArray ;
    }

    // Update is called once per frame
    void Update()
    {

     }



    private void OnTriggerEnter2D(Collider2D collision)

    {
        foreach(GameObject  go in goArray){
            if(go.name != "Checkpoint")
            {
                Debug.Log(Mathf.Round(go.transform.position.x)+"  |  "+Mathf.Round(transform.position.x));
                if(Mathf.Round(go.transform.position.x) != Mathf.Round(transform.position.x))
                {
                     go.GetComponent<Animator>().SetBool("isActivated", false);
                }
                else
                {
                    go.GetComponent<Animator>().SetBool("isActivated", true);
                }
            }
        }
    
        checkpointSound.Play();
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        foreach (GameObject checkpoint in checkpoints)
        {
            if(collision.gameObject.GetComponent<Animator>() != null)
            {
                collision.gameObject.GetComponent<Animator>().SetBool("Enabled", false);
            }
        }
        m_animator.SetBool("isActivated", true);
    }
}
