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
