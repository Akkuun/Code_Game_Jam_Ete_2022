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
    
    
   
    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.CompareTag("Pic")){
            if(pic == 0){
                pic+=1; 
                
                picItem.SetActive(true);
               
               
            }
            
        }
        if(collision.gameObject.CompareTag("Canon")){
            if(canon == 0){
                canon+=1; 
                
                canonItem.SetActive(true);
               
                Debug.Log("canon" + canon);
            }
            Debug.Log("canon" + canon);

        }

    }


    private void UseItem(){
        if(pic == 0){
            Debug.Log("pas de pic");
        }else{
            picItem.SetActive(false); 
        }

         if(canon == 0){
            Debug.Log("pas de canon");
        }else{
            canonItem.SetActive(false); 
        }

    }
}
