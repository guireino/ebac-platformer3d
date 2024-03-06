using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour{

    [SerializeField] private FlashColor _flashColor;
    private int _currentLife;
    private bool _isDead = false;

    public Action OnKill;
    public int startLife = 10;
    public float delayToKill = 0f;
    public bool destroyOnKill = false;

    // Start is called before the first frame update
    void Awake(){

        Init();

        if(_flashColor == null){
            _flashColor = GetComponent<FlashColor>();
        }
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

        if(_flashColor != null){
            _flashColor.Flash();
        }
    }

    private void Kill(){

        _isDead = true;

        if(destroyOnKill){
            Destroy(gameObject, delayToKill);
        }

        OnKill?.Invoke(); // if(OnKill != null) = ?
    }
}