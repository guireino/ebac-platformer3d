using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour{


    [Header("Speed setup")]
    public Rigidbody2D rb;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed, speedRun, forceJump = 2;

    [Header("Animation setup")]
    public Ease ease = Ease.OutBack;
    public float jumpScaleY = 1.5f, jumpScaleX = 0.7f, animationDuration = .3f;

    [Header("Animation Player")]
    private float _currentSpeed;
    private bool _isRunning = false;
    public Animator animator;
    public float playerSwipeDuration = .1f;
    public string boolRun = "Run";

    // Update is called once per frame
    void Update(){
        
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment(){
        
        //verificando se esta andando ou corrento
        if(Input.GetKey(KeyCode.LeftControl)){
            _currentSpeed = speedRun;
            //Debug.Log("speedRun LeftControl " + speedRun);
            animator.speed = 2;
        }else{
            _currentSpeed = speed;
            //Debug.Log("speed LeftControl " + speed);
            animator.speed = 1;
        }
        

        _isRunning = Input.GetKey(KeyCode.LeftControl);

        if(Input.GetKey(KeyCode.LeftArrow)){
           // rb.MovePosition(rb.position - velocity * Time.deltaTime);
           // "?" verificando se verdadeiro or ":" nao
           //rb.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? -_currentSpeed : -speedRun, rb.velocity.y);
           rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
           //rb.transform.localScale = new Vector3(-1, 1, 1); // monanto sprite de lado

           if(rb.transform.localScale.x != -1){  // se for igual -1
                rb.transform.DOScaleX(-1, playerSwipeDuration);  // DOScaleX vai virar sprite do player
                //animator.speed = 2;
           }

           animator.SetBool(boolRun, true);
        }else if(Input.GetKey(KeyCode.RightArrow)){
           // rb.MovePosition(rb.position + velocity * Time.deltaTime);
           
           rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);

           if(rb.transform.localScale.x != 1){  // se for igual 1
                rb.transform.DOScaleX(1, playerSwipeDuration);  // DOScaleX vai virar sprite do player
           } 

           rb.transform.localScale = new Vector3(1, 1, 1); // mudando sprite de lado

           animator.SetBool(boolRun, true);
        }else{
            animator.SetBool(boolRun, false);
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

            rb.transform.localScale = Vector2.one; // resetando escala player
            DOTween.Kill(rb.transform);  // matando animação para volta origina

            HandleScaleJump();
        }
    }

    private void HandleScaleJump(){

        // LoopType  vai fazer um loop como um yoyo e vai escala e voltar para tamanho original
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}