using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public TMP_Text scoresText;
    public TMP_Text livesText;
    public int maxLives = 5;

    private int _currentScore;
    private int _currentLives;

    private void Start()
    {
        scoresText.text = "Scores: " + _currentScore;
        livesText.text = "Lives: " + maxLives;
        _currentLives = maxLives;
    }

    public void GetPoints()
    {
        _currentScore++;
        scoresText.text = "Scores: " + _currentScore;
    }

    public void LoseLife()
    {
        _currentLives--;
        livesText.text = "Lives: " + _currentLives;
        Logging();
    }
    
    /////Block 1
    
    //gets the path of the directory where we want to store our logs
    private static string GetDirectoryPath()
    {
        return Application.dataPath + "/StreamingAssets/_Logs/";

    }

    
    //if your folder and file has not been created yet, it will be created. This also ensures your data goes to the correct file and folder:
    private static void VerifyDirectory()
    {
        var dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
    
    ////end of Block 1
    
    ////Block 2
    
    public void Logging()
    {
        if (_currentLives >= 1) return;
        
        VerifyDirectory(); 			//checks if folder path already exists, if not it is created
        var saveFileLocation = Application.dataPath + "/StreamingAssets/_Logs/";
        var filePath = $"{saveFileLocation}{DateTime.Now:yyMMdd_HHmmss}.csv";

        using (var sw = File.CreateText(filePath))
        {
            sw.WriteLine("Lives: " + _currentLives);
        }
        using (var sw = File.AppendText(filePath))
            sw.WriteLine("Score: " + _currentLives);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    ////end of Block 2

}
