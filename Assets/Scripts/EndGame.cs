using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour{

    public GameObject uiEndGame;
    public string tagToCompare = "Player";

    private void OnTriggerEnter2D(Collider2D col) {
        
        if(col.transform.CompareTag(tagToCompare)){
            CallEndGame();
        }
    }

    public void CallEndGame(){
        uiEndGame.SetActive(true);
    }
}
