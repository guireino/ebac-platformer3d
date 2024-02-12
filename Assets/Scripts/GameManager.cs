using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using Ebac.Core.Singleton;

public class GameManager : Singleton<GameManager>{

    private GameObject _currentPlayer;

    [Header("player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public Ease ease = Ease.OutBack; // Ease serve para ajuste a animação
    public float duration = .2f;
    public float delay = .05f;

    public void Start() {
        Init();
    }

    public void Init(){
        SpawnPlayer();
    }

    private void SpawnPlayer(){
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay); // fazendo o player aparecer crescendo
    }

    // public static GameManager Instance;

    // private void Awake(){

    //     //verificando se tem instance objeto GameManager
    //     if(Instance == null){
    //         Instance = this;          
    //     }else{
    //         Destroy(gameObject);
    //     }
    // }
}