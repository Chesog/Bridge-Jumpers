using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    private static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();

            return instance;
        }
    }

    public void AddScore(int value)
    {
        _playerController.AddPlayerScore(value);
        _scoreDisplay.text = _playerController.GetPlayerScore().ToString();
    }
}
