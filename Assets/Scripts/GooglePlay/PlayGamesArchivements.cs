using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;

public class PlayGamesArchivements : MonoBehaviour
{
    public static PlayGamesArchivements Instance;
    private bool hasBeenAutenticated;
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        try
        {
#if UNITY_ANDROID
            if (Social.localUser.authenticated)
                hasBeenAutenticated = true;
            if (!PlayerPrefs.HasKey("FirstTime"))
                OpenForTheFirstTime();
#endif
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            hasBeenAutenticated = false;
            throw;
        }
    }

    public void ShowAchievements()
    {
#if UNITY_ANDROID
        if (hasBeenAutenticated)
        {
            Social.ShowAchievementsUI();
        }
#endif
    }

    public void OpenForTheFirstTime()
    {
#if UNITY_ANDROID
        if (hasBeenAutenticated)
        {
            Social.ReportProgress("CgkI3Ji-p9sLEAIQAQ",100f, succes => { });
            PlayerPrefs.SetString("FirstTime","FirstTime");
        }
#endif
    }
    
    public void TheMadKing()
    {
#if UNITY_ANDROID
        if (hasBeenAutenticated)
        {
            if (!PlayerPrefs.HasKey("TheMadKing"))
            {
                Social.ReportProgress("CgkI3Ji-p9sLEAIQAg",100f, succes => { });
                PlayerPrefs.SetString("TheMadKing","TheMadKing");
            }
        }
#endif
    }
    
    public void LetTheMagicBegin()
    {
#if UNITY_ANDROID
        if (hasBeenAutenticated)
        {
            if (!PlayerPrefs.HasKey("LetTheMagicBegin"))
            {
                Social.ReportProgress("CgkI3Ji-p9sLEAIQAw",100f, succes => { });
                PlayerPrefs.SetString("LetTheMagicBegin","LetTheMagicBegin");
            }
        }
#endif
    }
    
    public void UniteTheKingdom()
    {
#if UNITY_ANDROID
        if (hasBeenAutenticated)
        {
            if (!PlayerPrefs.HasKey("UniteTheKingdom"))
            {
                Social.ReportProgress("CgkI3Ji-p9sLEAIQBA",100f, succes => { });
                PlayerPrefs.SetString("UniteTheKingdom","UniteTheKingdom");
            }
        }
#endif
    }
    
    public void AxeToMeetYou()
    {
#if UNITY_ANDROID
        if (hasBeenAutenticated)
        {
            if (!PlayerPrefs.HasKey("AxeToMeetYou"))
            {
                Social.ReportProgress("CgkI3Ji-p9sLEAIQBQ",100f, succes => { });
                PlayerPrefs.SetString("AxeToMeetYou","AxeToMeetYou");
            }
        }
#endif
    }
}
