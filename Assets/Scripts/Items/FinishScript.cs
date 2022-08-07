using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinishScript : MonoBehaviour
{

  

    
   public PlayableDirector timeline;
    public PlayableAsset cutscene;


    void OnTriggerEnter2D(Collider2D other)
    {
   
          StartCoroutine(StartCutscene());

    }

    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(.2f);
 
      
        timeline.playableAsset = cutscene;
        timeline.Play();
    }



}

