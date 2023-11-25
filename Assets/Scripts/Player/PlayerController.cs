using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public GameObject _visuals;
    public bool canJump;
    public UnityAction OnPlayerDead;
    
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _verticalforce;
    [SerializeField] private Vector3 _horizontalforce;
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private int _selectedCharacter;
    [SerializeField] private int _playerScore;
    [SerializeField] private int _playerMoney;
    [SerializeField] private float _maxTouchY;
    [SerializeField] private float _moveSpeed;
    

    private void OnEnable()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponentInChildren<Rigidbody>();
        ResetPlayerScore();
        RespawnPlayer();
        _playerMoney = PlayerPrefs.GetInt("PlayerMoney");
        _selectedCharacter = PlayerPrefs.GetInt("PlayerCharacter");
        Debug.Log("Selected Char " + _selectedCharacter);
        PlayerPrefs.Save();
        int lenght = _characters.Length;
        
        for (int i = 0; i < lenght; i++)
        {
            if (i == _selectedCharacter)
                _characters[i].gameObject.SetActive(true);
            else
                _characters[i].gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (InputManager.Instance.GetAxis("Vertical") > _maxTouchY)
        {
            if (isGrounded())
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(_verticalforce, ForceMode.Impulse);
            }
        }
        
        _horizontalforce.x = InputManager.Instance.GetAxis("Horizontal") * _moveSpeed;
        _rigidbody.AddForce(_horizontalforce, ForceMode.Force);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_verticalforce, ForceMode.Impulse);
            transform.position = transform.position += _verticalforce;
            Debug.Log("Presed Space");
        }
    }

    public void AddPlayerScore(int value) { _playerScore += value; }

    public void AddPlayerMoney(int value)
    {
        _playerMoney += value;
        PlayerPrefs.SetInt("PlayerMoney",_playerMoney);
        PlayerPrefs.Save();
    }
    public int GetPlayerScore() { return _playerScore; }
    public int GetPlayerMoney() { return _playerMoney; }
    public void ResetPlayerScore() { _playerScore = 0; }

    public void DestroyPlayer()
    {
        GameManager.Instance.SetPlayerHighScore(_playerScore);
        OnPlayerDead?.Invoke();
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }
        gameObject.SetActive(false);
    }
    public void RespawnPlayer() { gameObject.SetActive(true); }

    /// <summary>
    /// Check If The Player Is At Ground Level
    /// </summary>
    /// <returns></returns>
    public bool isGrounded()
    {
        return canJump;
    }
}