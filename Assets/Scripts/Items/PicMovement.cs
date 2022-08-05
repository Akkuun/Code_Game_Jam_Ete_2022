using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class PicMovement : MonoBehaviour
{

    private Rigidbody2D m_rigidBody;
    private float m_movementSpeed = 6f;
    private bool m_isGrounded;
    private float m_currentJumpTimecounter;
    private bool m_isJumping;

    public LayerMask m_groundLayer;
    public Transform m_feet;
    public bool m_playerCanDoubleJump;

    

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
        Vector2 positionTotal = new Vector2(positionPerso.x-1, positionPerso.y+1);
        transform.position = positionTotal;
    }

   
}
