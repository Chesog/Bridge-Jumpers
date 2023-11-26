using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinsGameplay : MonoBehaviour
{ 
    [SerializeField] private PlayerController _player;
    [SerializeField] private TextMeshProUGUI _coinsLabel;
    
    void Update()
    {
        _coinsLabel.text = _player.GetPlayerMoney().ToString();
    }
}
