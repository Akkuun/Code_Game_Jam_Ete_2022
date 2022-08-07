using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimation : MonoBehaviour
{
    public Animator m_animator;
    [SerializeField] AudioSource checkpointSound;

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
        m_animator.SetBool("isActivated", true);
    }
}
