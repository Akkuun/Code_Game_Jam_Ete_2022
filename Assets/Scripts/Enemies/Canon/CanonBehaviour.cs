using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    private float m_curentDelay;
    private bool m_hasSpawned;

    //----------------------

    public Animator m_animator;

    public GameObject m_bulletPrefab;

    public float m_maxDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        m_curentDelay = m_maxDelay;
        m_hasSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_curentDelay > 0)
        {
            m_curentDelay -= Time.deltaTime;
        }
        else
        {
            m_curentDelay = m_maxDelay;
            m_hasSpawned = false;
            m_animator.SetBool("Shoot", true);
        }
        if (m_curentDelay < m_maxDelay-0.50f && !m_hasSpawned)
        {
            SpawnBullet();
            m_animator.SetBool("Shoot", false);
            m_hasSpawned = true;
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(m_bulletPrefab, transform) as GameObject;
        
        if(transform.localScale.x == -1)
        {
            bullet.GetComponentInChildren<BulletBehaviour>().ChangeDirection();
        }
    }
}
