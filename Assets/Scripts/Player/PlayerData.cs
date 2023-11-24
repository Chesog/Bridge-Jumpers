using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scriptable Object For The Setting Of The Player
/// </summary>
[CreateAssetMenu(menuName = "Scripts/Player/Player Data")]
[Obsolete]
public class PlayerData : ScriptableObject
{
    [Header("Player SetUps")] public PlayerController _player;
    public Character[] playerUnlockCharacters;
    [SerializeField] private int _PlayerMoney;
    [SerializeField] private int _playerHighScore;

    public int GetPlayerMoney()
    {
        return _PlayerMoney;
    }

    public int GetPlayerHighScore()
    {
        return _playerHighScore;
    }

    public void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            _player = FindObjectOfType<PlayerController>();
            _player.SetPlayerCharacter(playerUnlockCharacters);
        }
    }
}