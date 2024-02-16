using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    private float _currentSpeed;
    private bool _isRunning = false;
    public Rigidbody2D rb;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed, speedRun, forceJump = 2;

    // Update is called once per frame
    void Update(){
        
        HandleJump();
        HandleMoviment();
    }


    private void HandleMoviment(){

        /*
        if(Input.GetKey(KeyCode.LeftControl)){
            _currentSpeed = speedRun;
            //Debug.Log("speedRun LeftControl " + speedRun);
        }else{
            _currentSpeed = speed;
            //Debug.Log("speed LeftControl " + speed);
        }
        */

        _isRunning = Input.GetKey(KeyCode.LeftControl);

        if(Input.GetKey(KeyCode.LeftArrow)){
           // rb.MovePosition(rb.position - velocity * Time.deltaTime);
           // "?" verificando se verdadeiro or ":" nao
           rb.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? -_currentSpeed : -speedRun, rb.velocity.y);
        }else if(Input.GetKey(KeyCode.RightArrow)){
           // rb.MovePosition(rb.position + velocity * Time.deltaTime);
           rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
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
