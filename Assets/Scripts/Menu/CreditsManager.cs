using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.PlayCreditsMusic();
    }
}
