using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // this script is made for the main menu and switching between scnes in game 
    // also will deal with the stats page if that is implemented 
    void Start()
    {
        // keeps cusor in the play area 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Will cause the application to exit when called through the quit game button 
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); 
#endif
    }
    // will start the game through the start game button 
    public void StartGame()
    {
        SceneManager.LoadScene("World"); 
    }
}
