using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{

    public bool isAttractiveMode,isNonAttractiveMode;
    public bool is_trigger = false;
    private int direction = 1;
    public Rigidbody2D m_Rigidbody;
    public int coef;
    private Vector3 movement;

     void Start()
    {
        Debug.Log(m_Rigidbody);
        // AddForce is a function of RigidBody2D
       //m_Rigidbody.AddForce(new Vector2(coef, 0), ForceMode2D.Impulse);
       
    }
   
    

    void OnTriggerStay2D(Collider2D collision) {
     m_Rigidbody=   collision.gameObject.GetComponent<Rigidbody2D>();
    
    
    if(isNonAttractiveMode) m_Rigidbody.AddForce(-Vector2.right * coef);
    if(isAttractiveMode) m_Rigidbody.AddForce(Vector2.right * coef);
       //m_Rigidbody.AddForce(new Vector3(coef, 0.0f, 0.0f));
      
    }
    /*
    void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Player"){
        Debug.Log("JumpForce Added");

        m_Rigidbody =  GetComponent();
       m_Rigidbody.AddForce(new Vector2(0.0f, coef));
    //   m_Rigidbody.AddForce(new Vector2(coef, 0), ForceMode2D.Impulse);
     //  m_Rigidbody.AddForce(Vector2.down * coef);
    }
}
*/
    void OnTriggerExit2D(Collider2D collision)
    {
   

     
    }


}
