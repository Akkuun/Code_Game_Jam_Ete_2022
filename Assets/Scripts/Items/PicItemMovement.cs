using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class PicItemMovement : MonoBehaviour
{

   
    private float m_movementSpeed = 6f;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        HorizontalMovements(); 
       
    }


    private void HorizontalMovements()
    {
        float horitonalInput = Input.GetAxisRaw("Horizontal");
        Vector2 position = transform.position;
        position.x += +m_movementSpeed * horitonalInput * Time.deltaTime;
        Vector2 positionPerso = GameObject.FindGameObjectWithTag("Player").transform.position;

        Vector2 positionTotal = new Vector2(positionPerso.x-0.5f, positionPerso.y+1);
        transform.position = positionTotal;
        
         
        
        
    }

   
}
