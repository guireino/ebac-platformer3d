using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using UnityEngine;
using TMPro;

public class ItemManager : Singleton<ItemManager>{

    //public static ItemManager Instance;

    public int coins;
    public TextMeshProUGUI uiTextCoins;

    // private void Awake() {

    //     if(Instance == null){
    //         Instance = this;
    //     }else{
    //         Destroy(gameObject);
    //     }
    // }

    private void Start(){
        Reset();
    }

    private void Reset(){
        coins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1){
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI(){
        uiTextCoins.text = coins.ToString();
    }

}