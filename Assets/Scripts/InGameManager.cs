using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI curScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] GameObject recordText;
    [SerializeField] Slider feverGauge;

    [Space]
    [SerializeField] int curScore;
    [SerializeField, Range(0, 0.5f)] float getFeverGauge;

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

    private void LateUpdate()
    {
        TextBuilder(curScore.ToString(), curScoreText);
    }

    public void GetScore()
    {
        curScore += GameManager.SCORE;
        FeverGauge();
    }

    private void FeverGauge()
    {
        if (feverGauge.value == feverGauge.maxValue)
        {
            feverGauge.value = feverGauge.minValue;
        }
        else
        {
            feverGauge.value += getFeverGauge;
        }

    }
}
