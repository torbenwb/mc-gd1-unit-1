using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CollectionLeaderboard : MonoBehaviour
{
    public GameObject playerScorePrefab;

    public List<PlayerScore> playerScores = new List<PlayerScore>();

    public int displayCount = 10;

    public float startDelay = 0.2f;
    public float endDelay = 0.2f;
    [Tooltip("Time between displaying each score card")]
    public float displayRate = 0.1f;

    public UnityEvent OnFinish = new UnityEvent();

    public void NewLeaderboard(List<PlayerScore> playerScores)
    {
        this.playerScores = playerScores;

        StartCoroutine(DisplayScores());
    }

    IEnumerator DisplayScores()
    {
        yield return new WaitForSeconds(startDelay);
        for(int i = 0; i < Mathf.Min(playerScores.Count, displayCount); i++)
        {
            GameObject newScoreDisplay = Instantiate(playerScorePrefab);
            newScoreDisplay.transform.SetParent(transform);
            
            if (newScoreDisplay.TryGetComponent<PlayerScoreDisplay>(out var playerScoreDisplay))
            {
                playerScoreDisplay.LoadScore(playerScores[i], i + 1);
            }

            yield return new WaitForSeconds(displayRate);
        }
        yield return new WaitForSeconds(endDelay);
        OnFinish.Invoke();
    }
}
