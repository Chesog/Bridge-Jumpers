using System;
using System.Text;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine;

public class SaveDataHandler : MonoBehaviour
{
        private bool isLoading = false;
        private bool isSaving;
        [SerializeField] string fileName = "BridgeJumpers_SaveFile";
        [SerializeField] public Character[] _characters;
        public static SaveDataHandler instance;

        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
            LoadData();
        }

        private void OnApplicationQuit()
        {
           SaveDataToJson();
        }

        public void SaveDataToJson()
        {
            if (!PlayGamesPlatform.Instance.localUser.authenticated)
            {
                Debug.LogWarning("User is not authenticated to Google Play Services");
                return;
            }

            if (isSaving)
            {
                Debug.LogWarning("Already saving data");
                return;
            }

            isSaving = true;
            
            PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
                fileName,
                DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseMostRecentlySaved,
                (status, metadata) =>
                {
                    if (status != SavedGameRequestStatus.Success)
                    {
                        Debug.LogError("Error opening saved game");
                        isSaving = false;
                        return;
                    }

                    SaveData data = new SaveData
                    {
                        PlayerHighScore = PlayerPrefs.GetInt("PlayerHighScore"),
                        PlayerMoney = PlayerPrefs.GetInt("PlayerMoney"),
                        RunTutorial = PlayerPrefs.GetInt("RunTutorial"),
                        PlayerDeaths = PlayerPrefs.GetInt("CurrentDeaths"),
                    };
                    for (int i = 0; i < _characters.Length; i++)
                    {
                        data.gameCharacters[i] = PlayerPrefs.GetInt(_characters[i].name);
                    }

                    string jsonString = JsonUtility.ToJson(data);
                    byte[] savedData = Encoding.ASCII.GetBytes(jsonString);

                    SavedGameMetadataUpdate updatedMetadata = new SavedGameMetadataUpdate.Builder()
                        .WithUpdatedDescription("My Save File Description")
                        .Build();
                    Debug.Log("Game Saved");
                    
                    PlayGamesPlatform.Instance.SavedGame.CommitUpdate
                    (
                        metadata,
                        updatedMetadata,
                        savedData,
                        (commitStatus, _) =>
                        {
                            isSaving = false;
                        });
                });
        }

        public void LoadData()
        {
            if (isLoading)
            {
                Debug.LogWarning("Load already in progress");
                return;
            }

            isLoading = true;

            PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
                fileName,
                DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime,
                (status, metadata) =>
                {
                    if (status != SavedGameRequestStatus.Success)
                    {
                        Debug.LogError("Error opening saved game");
                        isLoading = false;
                        return;
                    }

                    PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(
                        metadata,
                        (readStatus, savedData) =>
                        {
                            if (readStatus != SavedGameRequestStatus.Success)
                            {
                                Debug.LogError("Error reading saved game data");
                                isLoading = false;
                                return;
                            }

                            string jsonString = Encoding.ASCII.GetString(savedData);
                            SaveData data = JsonUtility.FromJson<SaveData>(jsonString);

                            PlayerPrefs.SetInt("PlayerHighScore",data.PlayerHighScore);
                            PlayerPrefs.SetInt("PlayerMoney",data.PlayerMoney);
                            PlayerPrefs.SetInt("RunTutorial",data.RunTutorial);
                            PlayerPrefs.SetInt("CurrentDeaths",data.PlayerDeaths);

                            for (int i = 0; i < data.gameCharacters.Length; i++)
                            {
                                PlayerPrefs.SetInt(_characters[i].name,data.gameCharacters[i]);
                            }
                            
                            isLoading = false;
                            
                            Debug.Log("Game Loaded");
                        });
                });
        }


[System.Serializable]
public class SaveData
{
    public int PlayerHighScore;
    public int PlayerMoney;
    public int RunTutorial;
    public int PlayerDeaths;
    public int[] gameCharacters;
}

}
