using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreText : MonoBehaviour
{
    public TMP_Text ScoreText;
    private void Update()
    {
        ScoreText.text = "Score: " + ScoreSystem.Instance.score;
    }
}
