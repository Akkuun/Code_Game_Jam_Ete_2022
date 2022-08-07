using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimation : MonoBehaviour
{
    public Animator m_animator;
    [SerializeField] private AudioSource checkpointSound;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
    
        checkpointSound.Play();
=======
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        foreach (GameObject checkpoint in checkpoints)
        {
            if(collision.gameObject.GetComponent<Animator>() != null)
            {
                collision.gameObject.GetComponent<Animator>().SetBool("Enabled", false);
            }
        }
>>>>>>> f3734f1eee14111603fb0df4d964cdc6b6e6bd12
        m_animator.SetBool("isActivated", true);
    }
}
