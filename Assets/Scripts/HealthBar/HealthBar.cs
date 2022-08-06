using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 
    private int maxLifePoint = 100;
    private int currentLifePoint = 100;

    /*public void setHealth(int health){
        slider.value = health;
    }*/

    public void degat(){
        if(currentLifePoint < 20){
            Debug.Log("Game Over");
        }else{
            currentLifePoint = currentLifePoint - 20; 
            slider.value = currentLifePoint;
            
        }
    }
}
