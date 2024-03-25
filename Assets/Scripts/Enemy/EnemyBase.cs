using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour{

    public HealthBase healthBase;
    public Animator animator;
    public AudioSource audioSourceKill;
    public string triggerAttack = "Attack", triggerKill = "Kill";
    public int damage = 10;
    public float timeToDestroy = 1f;

    private void Awake() {

        if(healthBase != null){
            healthBase.OnKill += OnEnemyKill; // add += registando morte inimigo
        }
    }

    private void OnEnemyKill(){
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
        if(audioSourceKill != null) audioSourceKill.Play();
        Destroy(gameObject, timeToDestroy);
    }

    public void OnCollisionEnter2D(Collision2D col){

        Debug.Log(col.transform.name);

        var health = col.gameObject.GetComponent<HealthBase>(); // buscando scripts HealthBase
        
        // se o player encostar no inimigo
        if(health != null){
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation(){
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDeathAnimation(){
        animator.SetTrigger(triggerKill);
    }

    public void Damage(int amount){
        healthBase.Damage(amount);
    }
}