using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour{

    private Coroutine _currentCoroutine;
    public AudioRandomPlayAudioClips randomShoot;
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot, playerSideReference;
    public KeyCode keyCode = KeyCode.S;
    public float timeBetweenShoot = .3f;


    private void Awake() {
        playerSideReference = GameObject.FindObjectOfType<Player>().transform; // instanciado object do player na variável da gun
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(keyCode)){
            _currentCoroutine = StartCoroutine(StartShoot());
        }else if(Input.GetKeyUp(keyCode)){

            //Shoot();
            if(_currentCoroutine != null){
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot(){

        //esperar um tempo em cada tiro
        while (true){
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot(){

        if(randomShoot != null) randomShoot.PlayRandom();

        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}