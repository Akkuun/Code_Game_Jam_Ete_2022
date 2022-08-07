using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 
    private int maxLifePoint = 100;
    private int currentLifePoint = 100;
    private bool isDead = false; 

    /*public void setHealth(int health){
        slider.value = health;
    }*/

   

    public void degat(){
        if(currentLifePoint <= 20){
            print("dead");
            isDead = true; 
            currentLifePoint = currentLifePoint - 20; 
            slider.value = currentLifePoint;
        }else{
            currentLifePoint = currentLifePoint - 20; 
            slider.value = currentLifePoint;
            
        }
    }

    public void mort(){
        
        currentLifePoint = 0; 
        slider.value = 0;
            
    }

    public void resetLife(){
        isDead = false;
        currentLifePoint = maxLifePoint; 
        slider.value = maxLifePoint;
    }

    public bool getIsDead(){
        return isDead; 
    }
}
