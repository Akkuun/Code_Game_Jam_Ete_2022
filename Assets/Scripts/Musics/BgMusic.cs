using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public static BgMusic bgInstance;

    private void Awake(){ //Garde la musique même durant un changement de scene 
        if(bgInstance != null && bgInstance != this){
            Destroy(this.gameObject); 
            return;
        }

        bgInstance = this;
        DontDestroyOnLoad(this);
    }
}
