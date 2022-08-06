using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikeAnimation : MonoBehaviour
{

    public Animator m_animator;
    private bool isPikeHurt = false;

    private float timerDuration = 1f;
    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (currentTimer <= 0 && m_animator.GetBool("isHurt"))
        {
            m_animator.SetBool("isHurt", false);
            Destroy(gameObject.transform.parent.gameObject);
        }
        else if (currentTimer > 0 && m_animator.GetBool("isHurt"))
        {
            currentTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_animator.SetBool("isHurt", true);

        if (m_animator.GetBool("isHurt"))
        {
            currentTimer = timerDuration;
        }
       
    }
}
