using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUIHandler : MonoBehaviour
{
    public InputField playerNameInput;
    public static string playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerNameInput.text = playerName;
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void SaveName(string newName) {
        playerName = newName;
    }
}
