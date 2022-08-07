using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesRegrettingAnimation : MonoBehaviour
{
    public Animator m_animator;

    private float timerDuration = 1f;
    private float currentTimer;
    
    public GameObject player;
    private GameObject arrow;

    [SerializeField] private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timerDuration;
        player = GameObject.FindGameObjectWithTag("Player");
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

            if (transform.gameObject.layer == 6)
            {
                if (gameObject.CompareTag("Pic") || gameObject.CompareTag("Canon"))
                {
                    Destroy(gameObject.transform.parent.gameObject);

                    arrow = Instantiate(item) as GameObject;
                    arrow.transform.SetParent(player.transform);
                    arrow.transform.position = new Vector3(player.transform.position.x + 0.4f, player.transform.position.y - 0.5f, player.transform.position.z);

                    Destroy(arrow.gameObject, 2);

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
