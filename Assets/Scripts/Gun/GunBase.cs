using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour{

    private Coroutine _currentCoroutine;
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot, playerSideReference;
    public float timeBetweenShoot = .3f;

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(KeyCode.S)){
            _currentCoroutine = StartCoroutine(StartShoot());
        }else if(Input.GetKeyUp(KeyCode.S)){

            //Shoot();
            if(_currentCoroutine != null){
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot(){

        while (true){
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot(){
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}