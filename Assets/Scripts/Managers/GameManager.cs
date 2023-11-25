using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private BridgeManager _bridgeManager;
    [SerializeField] private WatterBehaviour _watterBehaviour;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _scoreDisplayLose;
    [SerializeField] private TextMeshProUGUI _scoreDisplayPause;
    [SerializeField] private TextMeshProUGUI _HighscoreDisplayLose;
    [SerializeField] private TextMeshProUGUI _HighscoreDisplayPause;
    [SerializeField] private GameObject _spikes;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private int playerHighScore;
    [SerializeField] private int minScoreToSpawn;
    private bool isGamePaused;
    private static GameManager instance;
    private void Awake()
    {
        instance = this;
        if (_playerController == null)
            _playerController = FindObjectOfType<PlayerController>();
        
        _playerController.OnPlayerDead += OnPlayerDead;
        _scorePanel.SetActive(true);
        _pausePanel.SetActive(false);
        _losePanel.SetActive(false);
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value ;
        DontDestroyOnLoad(this);
    }

    private void OnPlayerDead()
    {
        _bridgeManager.canSpawn = false;
        _watterBehaviour._canMove = false;
        _scorePanel.SetActive(false);
        _pausePanel.SetActive(false);
        _losePanel.SetActive(true);
        _scoreDisplayLose.text = "Player Score :" + _playerController.GetPlayerScore();
        _HighscoreDisplayLose.text = "High Score : " + playerHighScore;
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

    public void ToglePause()
    {
        if (isGamePaused)
        {
            _scorePanel.SetActive(true);
            _pausePanel.SetActive(false);
            _losePanel.SetActive(false);
            isGamePaused = false;
            _bridgeManager.canSpawn = true;
            _watterBehaviour._canMove = true;
            _scoreDisplayPause.text = "Player Score :" + _playerController.GetPlayerScore();;
            _HighscoreDisplayPause.text = "High Score : " + playerHighScore;
        }
        else
        {
            _scorePanel.SetActive(false);
            _pausePanel.SetActive(true);
            _losePanel.SetActive(false);
            isGamePaused = true;
            _bridgeManager.canSpawn = false;
            _watterBehaviour._canMove = false;
        }
    }

    public void AddScore(int value)
    {
        _playerController.AddPlayerScore(value);
        _scoreDisplay.text = _playerController.GetPlayerScore().ToString();

        if (_playerController.GetPlayerScore() >= minScoreToSpawn)
            _spikes.SetActive(true);
    }
    
    public void AddCoins(int value)
    {
        _playerController.AddPlayerMoney(value);
    }

    public void SetPlayerHighScore(int value)
    {
        if (value > playerHighScore)
            playerHighScore = value;
    }

    private void OnDestroy()
    {
        _playerController.OnPlayerDead -= OnPlayerDead;
    }
}
