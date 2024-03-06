using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour{

    public Vector3 direction;

    public float timeToDestroy = 2f, side = 1;
    public int damageAmount = 1;

    private void Awake() {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D col) {

        var enemy = col.transform.GetComponent<EnemyBase>();

        if(enemy != null){
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}