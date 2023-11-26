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

    private void Start()
    {
        throw new NotImplementedException();
    }

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
            Social.ReportProgress("CgkI3Ji-p9sLEAIQAQ",100f, succes =>  {
                if (succes)
                {
                    Debug.Log("Achievement unlocked: FirstTime");
                    PlayerPrefs.SetString("FirstTime","FirstTime");
                }
                else
                {
                    Debug.LogError("Failed to unlock achievement: ");
                }
            });
            
            PlayGamesPlatform.Instance.ReportProgress("CgkI3Ji-p9sLEAIQAQ",100f, succes =>  {
                if (succes)
                {
                    Debug.Log("Achievement unlocked: FirstTime");
                    PlayerPrefs.SetString("FirstTime","FirstTime");
                }
                else
                {
                    Debug.LogError("Failed to unlock achievement: FirstTime");
                }
            });
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
                Social.ReportProgress("CgkI3Ji-p9sLEAIQAg",100f, succes => {
                    if (succes)
                    {
                        Debug.Log("Achievement unlocked: TheMadKing");
                        PlayerPrefs.SetString("TheMadKing","TheMadKing");
                    }
                    else
                    {
                        Debug.LogError("Failed to unlock achievement: ");
                    }
                });
            }
            
            PlayGamesPlatform.Instance.ReportProgress("CgkI3Ji-p9sLEAIQAg",100f, succes =>  {
                if (succes)
                {
                    Debug.Log("Achievement unlocked: TheMadKing");
                    PlayerPrefs.SetString("TheMadKing","TheMadKing");
                }
                else
                {
                    Debug.LogError("Failed to unlock achievement: TheMadKing");
                }
            });
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
                Social.ReportProgress("CgkI3Ji-p9sLEAIQAw",100f, succes => {
                    if (succes)
                    {
                        Debug.Log("Achievement unlocked: LetTheMagicBegin");
                        PlayerPrefs.SetString("LetTheMagicBegin","LetTheMagicBegin");
                    }
                    else
                    {
                        Debug.LogError("Failed to unlock achievement: LetTheMagicBegin");
                    }
                });
            }
            
            PlayGamesPlatform.Instance.ReportProgress("CgkI3Ji-p9sLEAIQAw",100f, succes =>  {
                if (succes)
                {
                    Debug.Log("Achievement unlocked: LetTheMagicBegin");
                    PlayerPrefs.SetString("LetTheMagicBegin","LetTheMagicBegin");
                }
                else
                {
                    Debug.LogError("Failed to unlock achievement: LetTheMagicBegin");
                }
            });
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
                Social.ReportProgress("CgkI3Ji-p9sLEAIQBA",100f, succes => {
                    if (succes)
                    {
                        Debug.Log("Achievement unlocked: UniteTheKingdom");
                        PlayerPrefs.SetString("UniteTheKingdom","UniteTheKingdom");
                    }
                    else
                    {
                        Debug.LogError("Failed to unlock achievement: UniteTheKingdom");
                    }
                });
                
                PlayGamesPlatform.Instance.ReportProgress("CgkI3Ji-p9sLEAIQBA",100f, succes =>  {
                    if (succes)
                    {
                        Debug.Log("Achievement unlocked: UniteTheKingdom");
                        PlayerPrefs.SetString("UniteTheKingdom","UniteTheKingdom");
                    }
                    else
                    {
                        Debug.LogError("Failed to unlock achievement: UniteTheKingdom");
                    }
                });
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
                Social.ReportProgress("CgkI3Ji-p9sLEAIQBQ",100f, succes => {
                    if (succes)
                    {
                        Debug.Log("Achievement unlocked: AxeToMeetYou");
                        PlayerPrefs.SetString("AxeToMeetYou","AxeToMeetYou");
                    }
                    else
                    {
                        Debug.LogError("Failed to unlock achievement: ");
                    }
                });
            }
            
            PlayGamesPlatform.Instance.ReportProgress("CgkI3Ji-p9sLEAIQBQ",100f, succes =>  {
                if (succes)
                {
                    Debug.Log("Achievement unlocked: AxeToMeetYou");
                    PlayerPrefs.SetString("AxeToMeetYou","AxeToMeetYou");
                }
                else
                {
                    Debug.LogError("Failed to unlock achievement: AxeToMeetYou");
                }
            });
        }
#endif
    }
}
