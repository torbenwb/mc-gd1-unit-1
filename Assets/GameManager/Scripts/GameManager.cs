using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ScreenWipe screenWipe;
    public InputField enterName;
    public static UnityEvent<string> newValidName = new UnityEvent<string>();
    public GameObject inGameMenu;
    static string currentScene = "Menu";

    private void Awake()
    {
        if (!instance){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
        {
            if (currentScene != "Menu") SceneTransition("Menu");
            else Application.Quit();
        }
    }

    void OpenInGameMenu()
    {
        inGameMenu.SetActive(true);
        PlayerController.inMenu = true;
    }

    void CloseInGameMenu()
    {
        inGameMenu.SetActive(false);
        PlayerController.inMenu = false;
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public static void ToggleTopDownPerspective() => CameraManager.SwitchPerspective(CameraManager.Perspective.TopDown);
    public static void ToggleFollowPerpsective() => CameraManager.SwitchPerspective(CameraManager.Perspective.Follow);

    public static void SceneTransition(string sceneName){
        if (instance){
            instance.screenWipe.Run(sceneName);
        }
    }

    public static void LoadScene(string sceneName){
        currentScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }


    public static async void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public static void FreeDrive() => SceneTransition("FreeDrive");
    public static void Collection() => SceneTransition("Collection");

    public static void ResetLeaderboard()
    {
        CollectionGameMode.ResetLeaderboard();
    }
}
