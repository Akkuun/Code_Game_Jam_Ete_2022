using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class PicMovement : MonoBehaviour
{

    private float speed = 5f;

    private float timerDuration = 0.1f;
    private float currentTimer;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
      currentTimer = timerDuration;
      startY = transform.position.y;
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);

        float vertical = Input.GetAxisRaw("Jump");
        transform.Translate(Vector2.up * vertical * speed * Time.deltaTime);
        
        if (vertical > 0)
        {
            currentTimer = timerDuration;
        }
        
        if(currentTimer > 0 && vertical == 0)
        {
            currentTimer -= Time.deltaTime;
        }
        if(currentTimer <= 0)
        {
            if(transform.position.y > startY)
            {
                transform.Translate(Vector2.down * speed * 0.5f * Time.deltaTime);
            }
            
        }

    }
}
