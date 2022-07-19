using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(20, 20, 500, 500), "Thanks for playing!");
        if (GUI.Button(new Rect(20, 50, 100, 50), "Restart"))
        {
            SceneManager.LoadScene("TutorialScene");
            Time.timeScale = 1;
        }
    }
}
