using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTriggerTransition : MonoBehaviour{

    public AudioMixerSnapshot snapshot01, snapshot02;

    public string tagToCompare = "Player";

    private void OnTriggerEnter2D(Collider2D col) {
        
        if(col.transform.CompareTag(tagToCompare)){
            snapshot02.TransitionTo(.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {

         if(col.transform.CompareTag(tagToCompare)){
            snapshot01.TransitionTo(.1f);
        }
    }
}