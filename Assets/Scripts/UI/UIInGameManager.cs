using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using UnityEngine;
using TMPro;

public class UIInGameManager : Singleton<UIInGameManager>{

    public TextMeshProUGUI uiTextCoins;

    public static void UpdateTextCoins(string s){
        Instance.uiTextCoins.text = s; // instance para pegar valor text no método static
    }
}