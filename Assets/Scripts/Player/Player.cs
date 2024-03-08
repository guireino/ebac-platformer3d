using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour{

    public HealthBase healthBase;
    public Rigidbody2D rb;

    /*
    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed, speedRun, forceJump = 2;

    [Header("Animation setup")]
    public Ease ease = Ease.OutBack;
    public SOFloat soJumpScaleY, soJumpScaleX, soAnimationDuration;
    //public float jumpScaleY = 1.5f, jumpScaleX = 0.7f, animationDuration = .3f;

    [Header("Animation Player")]
    private float _currentSpeed;
    private bool _isRunning = false;

    public float playerSwipeDuration = .1f;
    public string boolRun = "Run", triggerDeath = "Death";*/

    [Header("Setup")]
    private Animator _currentPlayer;
    private float _currentSpeed;
    private bool _isRunning = false;
    public SOPlayerSetup soPlayerSetup;

    //public Animator animator;

    void Awake() {

        if(healthBase != null){
            healthBase.OnKill += OnPlayerKill; // add += registando morte player
        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
    }

    private void OnPlayerKill(){
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    } 

    // Update is called once per frame
    void Update(){
        
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment(){
        
        //verificando se esta andando ou corrento
        if(Input.GetKey(KeyCode.LeftControl)){
            _currentSpeed = soPlayerSetup.speedRun;
            //Debug.Log("speedRun LeftControl " + speedRun);
            _currentPlayer.speed = 2;
        }else{
            _currentSpeed = soPlayerSetup.speedRun;
            _currentSpeed = soPlayerSetup.speed;
            //Debug.Log("speed LeftControl " + speed);
            _currentPlayer.speed = 1;
        }
        

        _isRunning = Input.GetKey(KeyCode.LeftControl);

        if(Input.GetKey(KeyCode.LeftArrow)){
           // rb.MovePosition(rb.position - velocity * Time.deltaTime);
           // "?" verificando se verdadeiro or ":" nao
           //rb.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? -_currentSpeed : -speedRun, rb.velocity.y);
           rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
           //rb.transform.localScale = new Vector3(-1, 1, 1); // monanto sprite de lado

           if(rb.transform.localScale.x != -1){  // se for igual -1
                rb.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);  // DOScaleX vai virar sprite do player
                //animator.speed = 2;
           }

           _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }else if(Input.GetKey(KeyCode.RightArrow)){
           // rb.MovePosition(rb.position + velocity * Time.deltaTime);
           
           rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);

           if(rb.transform.localScale.x != 1){  // se for igual 1
                rb.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);  // DOScaleX vai virar sprite do player
           } 

           rb.transform.localScale = new Vector3(1, 1, 1); // mudando sprite de lado

            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }else{
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        if(rb.velocity.x > 0){
            rb.velocity += soPlayerSetup.friction;
        }else if(rb.velocity.x < 0){
            rb.velocity -= soPlayerSetup.friction;
        }

    }

    private void HandleJump(){

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * soPlayerSetup.forceJump;

            rb.transform.localScale = Vector2.one; // resetando escala player
            DOTween.Kill(rb.transform);  // matando animação para volta origina

            HandleScaleJump();
        }
    }

    private void HandleScaleJump(){

        // LoopType  vai fazer um loop como um yoyo e vai escala e voltar para tamanho original
        rb.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        rb.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe(){
        Destroy(gameObject);
    }

}