using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool buildMode;
    public bool paused;
    public Camera topCam;
    public GameObject platform;
    public GameObject player;
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        buildMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (buildMode)
        {
            Time.timeScale = 0;
        }
        else if (!buildMode)
        {
            Time.timeScale = 1;
        }
        if (buildMode == true && !paused)
        {
            Cursor.lockState = CursorLockMode.None;
            if (!topCam.gameObject.activeSelf)
            {
                topCam.gameObject.SetActive(true);
            }
            if (!platform.gameObject.activeSelf)
            {
                platform.gameObject.SetActive(true);
            }
            if (!ground.gameObject.activeSelf)
            {
                ground.gameObject.SetActive(true);
            }
            if (player.activeSelf)
            {
                player.SetActive(false);
            }
        }
        if (buildMode == false && !paused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (topCam.gameObject.activeSelf)
            {
                topCam.gameObject.SetActive(false);
            }
            if (ground.gameObject.activeSelf)
            {
                ground.gameObject.SetActive(false);
            }
            if (!player.activeSelf)
            {
                player.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buildMode = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (paused)
            {
                paused = false;
                Time.timeScale = 1;
            }
        }
    }

    private void OnGUI()
    {
        if (buildMode && !paused)
        {
            GUI.skin.label.fontSize = 17;
            GUI.Label(new Rect(20, 20, 500, 500), "Your goal is to platform from the blue square to the green square.");
            GUI.Label(new Rect(20, 35, 500, 500), "Press 1 to place a platform that won't move.");
            GUI.Label(new Rect(20, 50, 600, 500), "Press 2 to place a platform that will move but makes you jump higher.");
            GUI.Label(new Rect(20, 65, 500, 500), "Press the right mouse button to remove a platform");
            GUI.Label(new Rect(20, 80, 500, 500), "Press spacebar to start platforming");
        }

        if (paused)
        {
            GUI.skin.label.fontSize = 19;
            GUI.Label(new Rect(20, 20, 500, 500), "You paused the game");
            if (GUI.Button(new Rect(20, 50, 100, 50), "Restart"))
            {
                SceneManager.LoadScene("TutorialScene") ;
                Time.timeScale = 1;
            }
        }
    }
}
