using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour{

    public Animator animator;

    public KeyCode keyToTrigger = KeyCode.A;
    public KeyCode keyToBool = KeyCode.S;
    public string triggerToPlay = "Fly";

    void OnValidate() { // o OnValidate vai pega automaticamente os valores das variáveis
        if (animator == null) animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(keyToTrigger)){
            animator.SetTrigger(triggerToPlay);
        }

        // !animator.GetBool(triggerToPlay) invertendo valor triggerToPlay se for true ele vira false se for false e vira true
        if(Input.GetKeyDown(keyToBool)){
            animator.SetBool(triggerToPlay, !animator.GetBool(triggerToPlay));
        }

        // if(Input.GetKeyDown(keyToBool)){
        //     animator.SetBool(triggerToPlay, true);
        // }else if(Input.GetKeyDown(keyToBool)){
        //     animator.SetBool(triggerToPlay, false);
        // }

    }
}
