using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{
    [SerializeField] private Character[] _characters;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterPrice;
    [SerializeField] private TextMeshProUGUI playerMoneyText;
    [SerializeField] private GameObject[] _buyButtons;
    [SerializeField] private int _playerMoney;
    private int _currentIndex;

    private void OnEnable()
    {
        _currentIndex = 0;
        int lenght = _characters.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex)
                _characters[i].character.SetActive(true);
            else
                _characters[i].character.SetActive(false);
        }
        characterName.text = _characters[_currentIndex].name;
        characterPrice.text = "$ : " + _characters[_currentIndex].price;
        
        _playerMoney = PlayerPrefs.GetInt("PlayerMoney");
        playerMoneyText.text = _playerMoney.ToString();
    }

    public void nextCharacter()
    {
        int lenght = _characters.Length;
        _currentIndex++;
        if (_currentIndex >= lenght)
            _currentIndex = 0;

        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex)
                _characters[i].character.SetActive(true);
            else
                _characters[i].character.SetActive(false);
        }

        characterName.text = _characters[_currentIndex].name;
        characterPrice.text = "$ : " + _characters[_currentIndex].price;
    }

    public void previousCharacter()
    {
        int lenght = _characters.Length;
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = lenght - 1;

        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex)
                _characters[i].character.SetActive(true);
            else
                _characters[i].character.SetActive(false);
        }
        
        characterName.text = _characters[_currentIndex].name;
        characterPrice.text = "$ : " + _characters[_currentIndex].price;
    }

    public void BuyCharacter()
    {
        if (_playerMoney >= _characters[_currentIndex].price)
        {
            _characters[_currentIndex].isBought = true;
            _playerMoney -= (int)_characters[_currentIndex].price;
            PlayerPrefs.SetInt("PlayerMoney",_playerMoney);
            PlayerPrefs.Save();
            playerMoneyText.text = _playerMoney.ToString();
        }
    }

    public void SelecCharacter()
    {
        int lenght = _characters.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex && _characters[_currentIndex].isBought)
                _characters[_currentIndex].isSelected = true;
            else
                _characters[_currentIndex].isSelected = false;
        }
    }
}