using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikeAnimation : MonoBehaviour
{

    public Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_animator.SetBool("isHurt", true);
        Destroy(gameObject);
        Debug.Log("Test");
    }
}
