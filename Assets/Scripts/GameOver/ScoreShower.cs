using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShower : MonoBehaviour
{
    [SerializeField]
    private Text _ScoreText;
    [SerializeField]
    private Text _MaxScoreText;
    void Start()
    {
        int score = GlobalCache.Inst.Score;
        _ScoreText.text = "Your Score : " + score.ToString();
        GlobalCache.Inst.MaxScore = Mathf.Max(score, GlobalCache.Inst.MaxScore);
        _MaxScoreText.text = "Your MaxScore : " + GlobalCache.Inst.MaxScore.ToString();
    }
}
