using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] Text playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

     public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("LevelOne");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
