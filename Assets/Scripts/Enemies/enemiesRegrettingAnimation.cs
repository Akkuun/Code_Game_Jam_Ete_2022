using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesRegrettingAnimation : MonoBehaviour
{

    public Animator m_animator;

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
        if (currentTimer <= 0 && m_animator.GetBool("isRegretting"))
        {
            m_animator.SetBool("isRegretting", false);
            Destroy(gameObject.transform.parent.gameObject);
        }
        else if (currentTimer > 0 && m_animator.GetBool("isRegretting"))
        {
            currentTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_animator.SetBool("isRegretting", true);

        if (m_animator.GetBool("isRegretting"))
        {
            currentTimer = timerDuration;
        }
       
    }
}
