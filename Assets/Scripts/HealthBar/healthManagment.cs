using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManagment : MonoBehaviour
{

    public Image healthBar;
    public float maxLifePoint = 100;
    public float currentLifePoint;


    private PlayerMovements player;
    private bool dashDone;
    private bool jumpDone;

    // Start is called before the first frame update
    void Start()
    {
   player =GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();      
    currentLifePoint = maxLifePoint; 
    healthBar.fillAmount=currentLifePoint/100;
    
        
    }

    // Update is called once per frame
    void Update()
    {
    //si le joeur a fait son dash mais qu'il est pas encore termine' on fait l'action  et apres on dit que le dash est fini'
        if (player.getHasDashed() &&  !dashDone) TakeDamage(20); dashDone = true;

        // si le joueur n'a pas dash et que le dash est fini 
        if (!player.getHasDashed() &&  dashDone) dashDone = false;

        

        
        
        
        //si le joueur a fait son double saut et que son saut est pas  fini 
        if (player.getIsDoubleJumping()  && !jumpDone && !player.getIsFalling() ) TakeDamage(20); jumpDone=true;
        
        //si le perso est au sol et qu'il ne saute pas alors son saut est fini
        if ( player.getIsFalling() && jumpDone ) jumpDone =false;
        
     
    }



    void TakeDamage(int dammage){
        currentLifePoint -= dammage;
        //if(currentLifePoint<=0)    UnityEditor.EditorApplication.isPlaying = false;
        healthBar.fillAmount=currentLifePoint/100;
    }
}
