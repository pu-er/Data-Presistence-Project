using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartMenuUIHandler : MonoBehaviour

{
    public Text highScoreText;
    public InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        if(DataManager.Instance != null)
        {
            highScoreText.text = $"Best Score : {DataManager.Instance.BestPlayer} : {DataManager.Instance.BestPlayerScore}";
            this.playerNameInput.text = DataManager.Instance.PlayerName;

        }
       

        
        
        
    }

   

    public void StartGame()
    {
        DataManager.Instance.PlayerName = playerNameInput.text;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(1);

    }


    public void Exit() {
        DataManager.Instance.SaveData();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
