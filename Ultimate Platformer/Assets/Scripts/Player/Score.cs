using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score i;
    public float score;
    public float score_highest;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI score_highest_Text;

    void Awake()
    {
        //debug
        if (i != null)
        {
            Debug.LogError("More than one ScoreManager in scene");
            return;
        }
        i = this;
    }
    private void Start()
    {
        score = 0;
        score_highest_Text.text = "Highest score: " + PlayerPrefs.GetFloat("score_highest", 0);
    }
    void Update()
    {
        if(score > PlayerPrefs.GetFloat("score_highest", 0))
        {
            PlayerPrefs.SetFloat("score_highest", score);
            score_highest_Text.text = "Highest score: " + PlayerPrefs.GetFloat("score_highest", score_highest);
        }
        scoreText.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.M))
        {
            //ForceReset();
        }
    }

    public void ForceReset()
    {
        score_highest_Text.text = "Highest score: " + PlayerPrefs.GetFloat("score_highest", 0);
        PlayerPrefs.SetFloat("score_highest", 0);
    }
}
