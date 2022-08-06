using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pic = 0; 
    private int canon = 0; 
    [SerializeField] private GameObject picItem; 
    [SerializeField] private GameObject canonItem;

    private PlayerMovements m_playerMovements; 
    
    //Détection de la collision avec un obstacle et désactivation de celui-ci
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("test" + collision.gameObject.layer);
        Debug.Log("test" + collision.gameObject.name);
        if (collision.gameObject.layer == 6)
        {
           
            collision.gameObject.SetActive(false);
        }
    }*/
   
    private void OnTriggerEnter2D(Collider2D collision){
        
       
        if(collision.gameObject.CompareTag("Pic")){ //récupère le type d'obstacle

       
 
            if(pic == 0){
                pic+=1;
                /*
                if(collision.transform.gameObject.layer == 6){ //le fait disparaitre
                    collision.gameObject.SetActive(false);
                }
                picItem.SetActive(true);*/

                if (collision.transform.gameObject.layer == 6)
                {
                    //récupère le parent parent (pike = children, children)
                    collision.gameObject.transform.parent.gameObject.SetActive(false);
                }
            }
            
        }
        if(collision.gameObject.CompareTag("Canon")){
          
            if(canon == 0){
                canon+=1; 
                
                canonItem.SetActive(true);
        
                
                if(collision.transform.gameObject.layer == 6){
                    //récupère le parent parent (bullet = children, children)
                    collision.gameObject.transform.parent.gameObject.SetActive(false);
                }
                
            }
            

        }

    }

    void Update(){
        m_playerMovements = GameObject.Find("Player").GetComponent<PlayerMovements>();
        UseItem();

    }

    private void UseItem(){

        if(pic == 0){
            picItem.SetActive(false); 
        }else{
            if(Input.GetKeyDown("a")){
                picItem.SetActive(false);
                m_playerMovements.setHasDoubleJump(true); 
                //m_playerMovements.Jump();
                
            }
        }

        if(canon == 0){
            canonItem.SetActive(false); 
        }else{
            if(Input.GetKeyDown("e")){
                canonItem.SetActive(false);
                m_playerMovements.setHasDash(true); 
                //m_playerMovements.Jump();
                
            }
            
        }

    }
}
