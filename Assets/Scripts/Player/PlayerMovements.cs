using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private Rigidbody2D m_rigidBody;

    private bool m_isJumping;
    private bool m_isGrounded;
    private bool m_isDashing;
    private bool m_canDoubleJump;

    private float m_movementSpeed = 6f;
    private float m_checkRadius = 0.3f;
    private float m_jumpForce = 9f;
    private float m_maxJumpTime = 0.2f;
    private float m_dashSpeed = 30f;
    private float m_maxDashTime = 0.15f;
    private float m_currentDashTime;
    private float m_currentJumpTime;

    //-------------------------------------

    public LayerMask m_groundLayer;

    public Transform m_feet;

    public bool m_playerHasDoubleJump;
    public bool m_playerHasDashing;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_currentDashTime = m_maxDashTime;
        m_currentJumpTime = m_maxJumpTime;
        m_isDashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_isGrounded = Physics2D.OverlapCircle(m_feet.position, m_checkRadius, m_groundLayer);
        if (m_playerHasDashing)
        {
            if (!m_isDashing && m_currentDashTime >= m_maxDashTime)
            {
                HorizontalMovements();
                Jump();
            }
            Dash();
        }
        else
        {
            HorizontalMovements();
            Jump();
        }
    }

    private void HorizontalMovements()
    {
        float horitonalInput = Input.GetAxisRaw("Horizontal");
        Vector2 position = transform.position;
        position.x += +m_movementSpeed * horitonalInput * Time.deltaTime;
        transform.position = position;
    }

    private void Jump()
    {
        float jumpInput = Input.GetAxisRaw("Jump");

        if (m_isGrounded == true && m_playerHasDoubleJump)
        {
            m_canDoubleJump = true;
        }
        if(m_isGrounded == true && jumpInput == 1) 
        {
            m_isJumping = true;
            m_currentJumpTime = m_maxJumpTime;
            m_rigidBody.velocity = Vector2.up * m_jumpForce;
        }
        if (jumpInput == 1 && m_isJumping && m_currentJumpTime > 0)
        {
            m_rigidBody.velocity = Vector2.up * m_jumpForce;
            m_currentJumpTime -= Time.deltaTime;
        }
        if (jumpInput == 0 && !m_isGrounded)
        {
            if (m_playerHasDoubleJump && m_canDoubleJump)
            {
                m_canDoubleJump = false;
                m_isJumping = true;
                m_currentJumpTime = m_maxJumpTime;
            }
        }
        else if (jumpInput == 0 && m_isGrounded)
        {
            m_isJumping = false;
        }
    }

    private void Dash()
    {
        if (Input.GetAxisRaw("Fire1") > 0 || m_isDashing)
        {
            if(!m_isGrounded)
            {
                if (m_currentDashTime <= 0 && m_isDashing)
                {
                    m_isDashing = false;
                    m_rigidBody.velocity = Vector2.zero;
                }
                else if (m_currentDashTime > 0)
                {
                    m_isDashing = true;
                    m_currentDashTime -= Time.deltaTime;
                    m_rigidBody.velocity = Vector2.right * m_dashSpeed;
                }
            }
        }

        if (m_isGrounded)
        {
            m_currentDashTime = m_maxDashTime;
            m_isDashing = false;
        }
    }

    //Détection de la collision avec un obstacle et désactivation de celui-ci
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
