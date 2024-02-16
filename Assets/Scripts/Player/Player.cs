using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public Rigidbody2D rb;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed, forceJump = 2;

    // Update is called once per frame
    void Update(){
        
        HandleJump();
        HandleMoment();
    }


    private void HandleMoment(){

        if(Input.GetKey(KeyCode.LeftArrow)){
           // rb.MovePosition(rb.position - velocity * Time.deltaTime);
           rb.velocity = new Vector2(-speed, rb.velocity.y);
        }else if(Input.GetKey(KeyCode.RightArrow)){
           // rb.MovePosition(rb.position + velocity * Time.deltaTime);
           rb.velocity = new Vector2(speed, rb.velocity.y);
        }


        if(rb.velocity.x > 0){
            rb.velocity += friction;
        }else if(rb.velocity.x < 0){
            rb.velocity -= friction;
        }

    }

    private void HandleJump(){

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * forceJump;
        }
    }

}
