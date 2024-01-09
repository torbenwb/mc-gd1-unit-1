using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI tmpro;

    private void Awake()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
    }

    public void LoadScore(PlayerScore score, int index)
    {
        tmpro.text = $"{index}.  {score.name}     {score.score}";
    }
}
