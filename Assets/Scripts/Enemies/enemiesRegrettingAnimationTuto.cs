using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesRegrettingAnimationTuto : MonoBehaviour
{
    public Animator m_animator;

    private float timerDuration = 1f;
    private float currentTimer;
    [SerializeField] private AudioSource uwuSound;

    public GameObject screenUwu;

    

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timerDuration;
    }

    

    private void FixedUpdate()
    {
        
        
        if (currentTimer <= 0 && m_animator.GetBool("isRegretting"))
        {
           
            m_animator.SetBool("isRegretting", false);
            if (transform.gameObject.layer == 6)
            {
                GameObject bg = GameObject.Find("BackgroundMusic");
                bg.SetActive(false);
                uwuSound.Play();

                
                if (gameObject.CompareTag("Pic") || gameObject.CompareTag("Canon"))
                {
                   
                    Destroy(gameObject.transform.parent.gameObject);
                    GameObject picObject = Instantiate(screenUwu) as GameObject;

                }
                
            }

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
