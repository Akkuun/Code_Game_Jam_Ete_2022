using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pic = 0; 
    [SerializeField] private GameObject imagePic; 
    
    
   
    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.CompareTag("Pic")){
            if(pic == 0){
                pic+=1; 
                
                imagePic.SetActive(true);
               
                Debug.Log("pic" + pic);
            }
            Debug.Log("pic" + pic);

        }

    }


    private void UseItem(){
        if(pic == 0){
            Debug.Log("pas de pic");
        }else{
            imagePic.SetActive(false); 
        }

    }
}
