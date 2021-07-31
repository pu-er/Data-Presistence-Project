using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string PlayerName {get; set;}
    public string BestPlayer {get; set;}
    public int BestPlayerScore {get; set;}
    public static DataManager Instance;


     private void Awake() {
         if(DataManager.Instance != null)
         {
             Destroy(this.gameObject);
             return;
         }

         Instance = this;
         DontDestroyOnLoad(this.gameObject);
         LoadData();
        
    }

    [System.Serializable]
     class SaveRecord
     {
         public string PlayerName;
         public string BestPlayer;
         public int BestPlayerScore;

         public SaveRecord( string playerName, string bestPlayer, int bestPlayerScore)
         {
             PlayerName = playerName;
             BestPlayer = bestPlayer;
             BestPlayerScore = bestPlayerScore;

         }

     }
   public void SaveData()
    {
        SaveRecord saveRecord = new SaveRecord(this.PlayerName, this.BestPlayer,
         this.BestPlayerScore);
        string json = JsonUtility.ToJson(saveRecord);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveRecord saveRecord = JsonUtility.FromJson<SaveRecord>(json);
            this.PlayerName = saveRecord.PlayerName;
            this.BestPlayer = saveRecord.BestPlayer;
            this.BestPlayerScore = saveRecord.BestPlayerScore;
        }
    }
  
}
