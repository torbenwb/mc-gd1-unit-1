using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore : IEquatable<PlayerScore>, IComparable<PlayerScore>
{
    public string name;
    public int score;

    public PlayerScore(string name, int score){
        this.name = name;
        this.score = score;
    }

    public int CompareTo(PlayerScore other){
        if (other == null) return 1;
        else return this.score.CompareTo(other.score);
    }

    public bool Equals(PlayerScore other){
        if (other == null) return false;
        return this.score == other.score;
    }

    public override string ToString()
    {
        return name + " " + score.ToString();
    }
}

public class CollectionGameMode : MonoBehaviour
{

    public static List<PlayerScore> playerScores { get; private set; } = new List<PlayerScore>();

    [Tooltip("How much time on round timer at start of round.")]
    [SerializeField] float startTime = 30f;
    // Player's score this round.
    public static int score { get; private set; } = 0;
    // Current time left in round.
    private static float time = 0f;
    public static float timeRemaining => time;
    public AudioSource clockTicking;

    private void Start()
    {
        StartRound();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0f) return;
        time -= Time.deltaTime;

        if (!clockTicking.isPlaying && time <= 5f)
        {
            clockTicking.Play();
        }
        if (clockTicking.isPlaying && time <= 0f)
        {
            clockTicking.Stop();
        }

        if (time <= 0f) EndRound();
    }

    public void AddScore(int amount){
        if (time <= 0f) return;
        score+=amount;
    }

    public void AddTime(float amount){
        time += amount;
    }

    public static void ResetLeaderboard()
    {
        playerScores = new List<PlayerScore>();
    }

    public static int SubmitScore(string playerName, int playerScore)
    {
        for(int i = 0; i < playerScores.Count; i++)
        {
            if (playerScore > playerScores[i].score)
            {
                playerScores.Insert(i, new PlayerScore(playerName, playerScore));
                return i;
            }
        }
        playerScores.Add(new PlayerScore(playerName, playerScore));
        return playerScores.Count - 1;
    }

    void StartRound()
    {
        score = 0;
        time = GameSettings.roundTimer;
    }

    void EndRound()
    {
        GameManager.SceneTransition("CollectionLeaderboard");
    }

}
