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
    [SerializeField] private int _playerScore;
    [SerializeField] private float _maxTouchY;
    [SerializeField] private float _moveSpeed;
    public Character[] playerUnlockCharacters;

    
    private void OnEnable()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponentInChildren<Rigidbody>();
        ResetPlayerScore();
        RespawnPlayer();
        _visuals.SetActive(true);
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
    public int GetPlayerScore() { return _playerScore; }
    public void ResetPlayerScore() { _playerScore = 0; }

    public void SetPlayerCharacter(Character[] playerUnlockCharacters)
    {
        this.playerUnlockCharacters = playerUnlockCharacters;
        int lenght = this.playerUnlockCharacters.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (this.playerUnlockCharacters[i].isSelected)
                playerUnlockCharacters[i].gameObject.SetActive(true);
            else
                playerUnlockCharacters[i].gameObject.SetActive(false);
        }
    }

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