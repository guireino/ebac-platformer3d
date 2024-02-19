using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour{

    private int _currentLife;
    private bool _isDead = false;

    public int startLife = 10;
    public float delayToKill = 0f;
    public bool destroyOnKill = false;

    // Start is called before the first frame update
    void Awake(){
        Init();
    }

    private void Init(){
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage){

        if (_isDead) return; // retornando o if para nao processar o resto do código, e ele estiver morto

        _currentLife -= damage;

        if(_currentLife <= 0){
            Kill();
        }
    }

    private void Kill(){

        _isDead = true;

        if(destroyOnKill){
            Destroy(gameObject, delayToKill);
        }
    }

}