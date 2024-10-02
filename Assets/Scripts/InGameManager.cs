using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class InGameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI curScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] GameObject recordText;

    [SerializeField, Space] int curScore;

    private StringBuilder sb = new StringBuilder();

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        TextBuilder(curScore.ToString(), curScoreText);
        recordText.SetActive(false);
    }

    private void TextBuilder(string msg, TextMeshProUGUI text)
    {
        sb.Clear();
        sb.Append(msg);
        text.SetText(sb);
    }

    public void GetScore()
    {
        curScore += GameManager.SCORE;
    }

    private void LateUpdate()
    {
        TextBuilder(curScore.ToString(), curScoreText);
    }
}
