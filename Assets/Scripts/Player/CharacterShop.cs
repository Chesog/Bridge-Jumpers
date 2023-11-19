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
}