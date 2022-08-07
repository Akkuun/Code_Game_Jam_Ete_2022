using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{

    public bool toTheRight,toTheLeft;
    public bool down,up;


    private int direction = 1;
    public int coef;

    public Rigidbody2D m_Rigidbody;

    private Vector3 movement;
    
    

    void FixedUpdate()
    {
        if(toTheLeft) GetComponent<Animator>().SetBool("Expulsion", false);
        if(toTheRight) GetComponent<Animator>().SetBool("Expulsion", true);
        if(down) GetComponent<Animator>().SetBool("Expulsion", true);
        if(up) GetComponent<Animator>().SetBool("Expulsion", false);
    }
   
    

    void OnTriggerStay2D(Collider2D collision) {
        m_Rigidbody=   collision.gameObject.GetComponent<Rigidbody2D>();

        if(toTheLeft) m_Rigidbody.AddForce(Vector2.left * coef);
        if(toTheRight) m_Rigidbody.AddForce(Vector2.right * coef);
        if(down) m_Rigidbody.AddForce(Vector2.down * coef);
        if(up) m_Rigidbody.AddForce(Vector2.up * coef);
      
    }


}
