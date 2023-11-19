using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject OptionsPanel;
    public void ToggleOptions()
    {
        if (OptionsPanel.activeInHierarchy)
            OptionsPanel.SetActive(false);
        else
            OptionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}