using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private Rigidbody2D m_rigidBody;

    private bool m_isJumping;
    private bool m_isGrounded;
    private bool m_isDashing;
    private bool m_hasDashed;
    private bool m_canDoubleJump;
    private bool m_facingRight;
    private bool m_isDoubleJumping;
    private bool m_isFalling;
    private bool soundPlayedOnce = false;
    private bool canReplay = false;
    private bool soundPlayedTwice = false;
    private bool m_canMoveToLeft;
    private bool m_canMoveToRight;

    private float m_movementSpeed = 6f;
    private float m_checkRadius = 0.3f;
    private float m_jumpForce = 9f;
    private float m_maxJumpTime = 0.2f;
    private float m_dashSpeed = 30f;
    private float m_maxDashTime = 0.25f;
    private float m_currentDashTime;
    private float m_currentJumpTime;
    private float m_initDashTime = 1f;

    private Transform rayCastOrigin;

    private RaycastHit2D hit2D;

    private Vector3 respawnPoint;
    private Transform spawnPoint;
    private bool isMovingSpawnPointTrigger;

    private float timerDuration = 1f;
    private float currentTimer;
    private float currentTimerHealthBar;

    private ItemCollector m_itemCollector;

    [SerializeField] private AudioSource jumpSound;

    //-------------------------------------

    public LayerMask m_groundLayer;

    public Animator m_animator;

    public Transform m_feet;

    public bool m_playerHasDoubleJump;
    public bool m_playerHasDashing;

    private HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_itemCollector = GetComponent<ItemCollector>();
        m_currentDashTime = m_maxDashTime;
        m_currentJumpTime = m_maxJumpTime;
        m_isDashing = false;
        m_facingRight = true;
        m_animator.SetFloat("initDashCount", m_initDashTime);

        respawnPoint = transform.position;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;

        currentTimer = timerDuration;

        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_isGrounded = Physics2D.OverlapCircle(m_feet.position, m_checkRadius, m_groundLayer);
        if (!m_animator.GetBool("isDying"))
        {
            if (m_isGrounded)
            {
                m_animator.SetBool("isJumping", false);
            }
            else if (!m_animator.GetBool("isDashing"))
            {
                m_animator.SetBool("isJumping", true);
                
            }
            if (m_playerHasDashing || m_itemCollector.CanUseItem("canon") || m_isDashing)
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

        if (currentTimer <= 0 && m_animator.GetBool("isDying") && !isMovingSpawnPointTrigger)
        {
            transform.position = respawnPoint;
            m_animator.SetBool("isDying", false);
            m_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
     
        }
        else if (currentTimer <= 0 && m_animator.GetBool("isDying") && isMovingSpawnPointTrigger)
        {
            transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            m_animator.SetBool("isDying", false);
            m_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
  
        }

        else if (currentTimer > 0 && m_animator.GetBool("isDying"))
        {
            currentTimer -= Time.deltaTime;
        }

        if (healthBar.getIsDead())
        {
            m_animator.SetBool("isDying", true);

            if (m_animator.GetBool("isDying"))
            {
                currentTimerHealthBar = timerDuration;
                m_rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            Invoke("healthBarRespawn", 1);

        }

    }

    void healthBarRespawn()
    {

        while (m_animator.GetBool("isDying"))
        {
            if (currentTimerHealthBar <= 0 && !isMovingSpawnPointTrigger)
            {
                transform.position = respawnPoint;
                m_animator.SetBool("isDying", false);
                m_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                healthBar.resetLife();
            }
            else if (currentTimerHealthBar <= 0 && isMovingSpawnPointTrigger)
            {
                transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
                m_animator.SetBool("isDying", false);
                m_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                healthBar.resetLife();
            }
            else if (currentTimerHealthBar > 0)
            {
                currentTimerHealthBar -= Time.deltaTime;
            }
        }
    }

    private void HorizontalMovements()
    {
        float horitonalInput = Input.GetAxisRaw("Horizontal");
        if(horitonalInput > 0 || horitonalInput < 0 && !m_animator.GetBool("isJumping"))
        {
            m_animator.SetFloat("Speed", 1);
        }
        else
        {
            m_animator.SetFloat("Speed", 0);
        }
        if(m_animator.GetBool("isJumping"))
        {
            m_animator.SetFloat("Speed", 0);
        }

        if (horitonalInput > 0 && !m_facingRight)
        {
            Flip();
        }
        else if(horitonalInput < 0 && m_facingRight)
        {
            Flip();
        }
        //Vector2 position = transform.position;
        //position.x += m_movementSpeed * horitonalInput * Time.deltaTime;
        //transform.position = position;
        m_rigidBody.velocity = new Vector2(m_movementSpeed * horitonalInput * Time.fixedDeltaTime * 50, m_rigidBody.velocity.y);
    }

    private void Jump()
    {
        float jumpInput = Input.GetAxisRaw("Jump");
        

        //Au sol, il reg�n�re son double jump
        if (m_isGrounded && (m_playerHasDoubleJump || m_itemCollector.CanUseItem("pic")))
        {
            m_canDoubleJump = true;
        }
        //Si il est au sol et qu'il saute
        if(m_isGrounded && jumpInput == 1) 
        {
            m_animator.SetBool("isJumping", false);
            m_animator.SetBool("isFalling", false);
            m_isJumping = true;
            m_currentJumpTime = m_maxJumpTime;

            m_isFalling = true;
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, Vector2.up.y * m_jumpForce);
            jumpSound.Play();
        }
        //Si il saute avec espace enfoncé et qu'il saute depuis pas longtemps
        if (jumpInput == 1 && m_isJumping && m_currentJumpTime > 0)
        {
            //jumpSound.Play();
        
            //Si il a la capacité de double jump et qu'il ne peut plus sauter
            if((m_playerHasDoubleJump || m_itemCollector.CanUseItem("pic")) && !m_canDoubleJump)
            {
                if (m_itemCollector.CanUseItem("pic") && !m_itemCollector.IsItemUsed("pic"))
                {
                    m_itemCollector.UseItem("pic");
                }
                canReplay = true;
                m_animator.SetBool("isJumping", true);
                m_animator.SetBool("isFalling", false);
                m_isFalling=false;
                m_animator.SetBool("isDoubleJumping", true);
                m_isDoubleJumping = true;
                
              
            }
            else
            {
                m_animator.SetBool("isJumping", true);
                m_animator.SetBool("isFalling", false);
                m_isFalling=false;
                m_isDoubleJumping = !m_isDoubleJumping;

                if (!soundPlayedOnce)
                {
                    soundPlayedOnce = !soundPlayedOnce;
                    jumpSound.Play();
                }
                else if(!soundPlayedOnce && canReplay && !soundPlayedTwice)
                {
                    soundPlayedTwice = !soundPlayedTwice;
                    jumpSound.Play();
                    jumpSound.Play();
                }

            }

            //m_rigidBody.velocity = Vector2.up * m_jumpForce;
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, Vector2.up.y * m_jumpForce);
            m_currentJumpTime -= Time.fixedDeltaTime;
        }
        //Si il est dans les airs et qu'il saute depuis trop longtemps ou qu'il est dans les airs sans sauter
        if((!m_isGrounded && m_currentJumpTime < 0) ||(!m_isGrounded && jumpInput == 0))
        {
            m_animator.SetBool("isFalling", true);
            m_isFalling=true;
            m_isDoubleJumping=true;
            
            
        }
        //Si il saute pas mais qu'il est dans les airs
        if (jumpInput == 0 && !m_isGrounded)
        {
            m_isDoubleJumping=false;
            //Si le joueur a la capacit� pour double sauter et peut double sauter
            if ((m_playerHasDoubleJump || m_itemCollector.CanUseItem("pic")) && m_canDoubleJump)
            {
                m_animator.SetBool("isJumping", false);
                m_canDoubleJump = false;
                m_isJumping = true;
                m_currentJumpTime = m_maxJumpTime;
                jumpSound.Play();
                jumpSound.Play();
            }
            //Sinon si il a pas la capacité pour double jump
            else if(!(m_playerHasDoubleJump || m_itemCollector.CanUseItem("pic")) || (!m_canDoubleJump && (m_playerHasDoubleJump || m_itemCollector.CanUseItem("pic")) && m_currentJumpTime != m_maxJumpTime))
            {
                m_isJumping = false;
            }
        }
        //Sinon si il saute pas et qu'il est par terre
        else if (jumpInput == 0 && m_isGrounded)
        {
            m_itemCollector.ChangeUsedItem("pic");
            m_animator.SetBool("isFalling", false);
            m_animator.SetBool("isJumping", false);
            m_animator.SetBool("isDoubleJumping", false);
            m_isFalling=false;
            m_isDoubleJumping=false;

            soundPlayedOnce = false;
            canReplay = false;
            soundPlayedTwice = false;
        }

        if (jumpInput == 1 && m_isGrounded && m_isDoubleJumping)
        {
            m_animator.SetBool("isFalling", false);
            m_animator.SetBool("isJumping", true);
            m_animator.SetBool("isDoubleJumping", false);
            m_isDoubleJumping = false;
            soundPlayedOnce = false;
            canReplay = false;
            soundPlayedTwice = false;
        }

    }

    private void Dash()
    {
        if (Input.GetAxisRaw("Fire1") > 0 || m_isDashing)
        {
            if(!m_isGrounded && !m_hasDashed)
            {
                if (m_itemCollector.CanUseItem("canon") && !m_itemCollector.IsItemUsed("canon"))
                {
                    m_itemCollector.UseItem("canon");
                }
                m_isDashing = true;

                m_animator.SetBool("isJumping", false);
                m_animator.SetBool("isFalling", false);
                m_animator.SetBool("isDashing", true);
                m_isFalling=false;
                if (m_animator.GetFloat("initDashCount") < 0)
                {
                    m_rigidBody.gravityScale = 3.6f;
                    if (m_currentDashTime <= 0 && m_isDashing)
                    {
                        m_animator.SetBool("isDashing", false);
                        m_animator.SetFloat("initDashCount", m_initDashTime);
                        m_animator.SetBool("isFalling", true);
                        m_isFalling=true;
                        m_isDashing = false;
                        m_hasDashed = true;
                        m_rigidBody.velocity = Vector2.zero;
                    }
                    else if (m_currentDashTime > 0)
                    {
                        m_currentDashTime -= Time.deltaTime;
                        if (m_facingRight)
                        {
                            m_rigidBody.velocity = Vector2.right * m_dashSpeed;
                        }
                        else
                        {
                            m_rigidBody.velocity = Vector2.left * m_dashSpeed;
                        }

                    }
                }
                else
                {
                    m_rigidBody.gravityScale = 0f;
                    m_rigidBody.velocity = Vector2.zero;
                    m_animator.SetFloat("initDashCount", m_animator.GetFloat("initDashCount") - Time.fixedDeltaTime);
                }
                
            }
        }

        if (m_isGrounded)
        {
            m_itemCollector.ChangeUsedItem("canon");
            m_currentDashTime = m_maxDashTime;
            m_isDashing = false;
            m_hasDashed = false;
            m_animator.SetBool("isDashing", false);
            m_animator.SetFloat("initDashCount", m_initDashTime);
            m_animator.SetBool("isFalling", false);
            m_isFalling = false;
        }
    }

    //Collision detection with an object, when there is a collision the object will disappear, the position of the character will be the respawn point  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            m_animator.SetBool("isDying", true);

            if (m_animator.GetBool("isDying"))
            {
                currentTimer = timerDuration;
                m_rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

            }

        }

        if(collision.gameObject.tag == "Plateform") transform.parent=collision.transform;
         if(collision.gameObject.tag != "Plateform") transform.parent=null;
    }

    //Trigger detection, if the character trigger a checkpoint, his respawn point will be the point of trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
            /*GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
            
            foreach(GameObject checkpoint in checkpoints)
            {
                if(respawnPoint != collision.gameObject.transform.position)
                {
                    collision.gameObject.GetComponent<Animator>().SetBool("isActivated", false);
                }
                else
                {
                    collision.gameObject.GetComponent<Animator>().SetBool("isActivated", true);
                }
            }*/
            isMovingSpawnPointTrigger = false;

        }
        else if (collision.tag == "MovingCheckpoint")
        {
            isMovingSpawnPointTrigger = true;
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        m_facingRight = !m_facingRight;
    }

    public bool getHasDashed(){

    return m_hasDashed;
    }

    public bool getIsGrounded(){

    return m_isGrounded;
    }

    public bool getIsDoubleJumping(){

    return m_isDoubleJumping;
    }

    public bool getIsJumping(){
        return m_isJumping;
    }

    public bool getHasDoubleJumped(){

    return m_playerHasDoubleJump;

    }

    public bool getIsFalling(){
        return m_isFalling;
    }
    //doit faire avec hasdoublejumped plutot

    public void setHasDoubleJump(bool doubleJump){
        m_playerHasDoubleJump = doubleJump;
        Jump();
    }

    public void setHasDash(bool dash){
        m_playerHasDashing = dash;
        Dash();
    }

    
    
  
   
    
    
}