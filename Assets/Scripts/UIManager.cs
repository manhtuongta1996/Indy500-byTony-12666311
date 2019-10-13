using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Load Original level 
    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(0);
        Object.DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Load Recreated level
    public void LoadSecondLevel()
    {
        SceneManager.LoadSceneAsync(2);
        Object.DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Load Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
        Destroy(this.gameObject);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0 || scene.buildIndex == 2)
        {
            Button QuitButton = GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();
            QuitButton.onClick.AddListener(QuitGame);

            Button BackButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
            BackButton.onClick.AddListener(LoadMainMenu);
        }
    }
}
