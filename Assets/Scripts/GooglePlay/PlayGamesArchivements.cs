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
}
