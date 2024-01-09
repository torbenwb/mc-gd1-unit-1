using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard_Scene : MonoBehaviour
{
    public bool skipEnterName = false;
    public ControllerKeyboard controllerKeyboard;
    public CollectionLeaderboard leaderboard;
    public TextMeshProUGUI title;
    public GameObject navKeys;

    private void Awake()
    {
        controllerKeyboard = GetComponentInChildren<ControllerKeyboard>();
        leaderboard = GetComponentInChildren<CollectionLeaderboard>();

        controllerKeyboard.OnSubmit.AddListener(SubmitName);
        leaderboard.OnFinish.AddListener(LeaderboardFinish);

        if (skipEnterName)
        {
            controllerKeyboard.gameObject.SetActive(false);
            title.text = "HIGH SCORES";
            leaderboard.gameObject.SetActive(true);
            leaderboard.NewLeaderboard(CollectionGameMode.playerScores);
        }
        else
        {
            title.text = "Enter Name:";
            controllerKeyboard.gameObject.SetActive(true);
            leaderboard.gameObject.SetActive(false);
        }
    }

    void SubmitName()
    {
        string name = controllerKeyboard.output;
        int score = CollectionGameMode.score;

        CollectionGameMode.SubmitScore(name, score);
        leaderboard.gameObject.SetActive(true);
        controllerKeyboard.GetComponent<Animator>().SetBool("Open", false);
        controllerKeyboard.enabled = false;
        title.text = "HIGH SCORES";
        leaderboard.NewLeaderboard(CollectionGameMode.playerScores);
    }

    void LeaderboardFinish()
    {
        if (navKeys) navKeys.SetActive(true);
    }
}
