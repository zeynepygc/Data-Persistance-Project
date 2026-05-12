using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{

    public TMP_InputField nameInput; //name from the user
    public TMP_Text bestScoreText;   //for best score 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScoreText.text =
            $"Best Score : {MainManager.Instance.HighScorePlayerName} = {MainManager.Instance.HighScore}";
    }

    public void StartNew()
    {
        MainManager.Instance.PlayerName = nameInput.text;
        SceneManager.LoadScene(1); //load main scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
