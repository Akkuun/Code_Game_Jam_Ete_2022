using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinishScript : MonoBehaviour
{

  private bool playedOnce= false;

    
   public PlayableDirector timeline;
    public PlayableAsset cutscene;


    void OnTriggerEnter2D(Collider2D other)
    {
   
       if(!playedOnce)   StartCoroutine(StartCutscene()); playedOnce=true;

       // Destroy(other.gameObject,5);

    }

    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(.2f);
 
      
        timeline.playableAsset = cutscene;
        timeline.Play();

       
    }



}

