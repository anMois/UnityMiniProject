using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI curScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] GameObject recordText;
    [SerializeField] GameObject combo;
    [SerializeField] Slider feverGauge;
    [SerializeField] Animator animator;

    [Space, Header("State")]
    [SerializeField] int curScore;
    [SerializeField] int score;
    [SerializeField] int comboCount;
    [SerializeField, Range(0, 0.5f)] float getFeverGauge;
    [SerializeField, Range(0, 5)] int getComboCount;
    [SerializeField] bool fever;

    private StringBuilder sb = new StringBuilder();
    private int highScore;

    public int ComboCount { get { return comboCount; } set { comboCount = value; } }

    private void Awake()
    {
        Init();
        score = GameManager.SCORE;
        highScore = GameManager.Instance.HighScore;
    }

    private void LateUpdate()
    {
        TextBuilder(curScore.ToString(), curScoreText);
        FeverGaugeDown();
        ShowComboCount();

        if (highScore < curScore)
        {
            recordText.SetActive(true);
            TextBuilder(curScore.ToString(), highScoreText);
        }
    }

    private void Init()
    {
        TextBuilder(curScore.ToString(), curScoreText);
        TextBuilder(highScore.ToString(), highScoreText);
        recordText.SetActive(false);
        combo.SetActive(false);
        feverGauge.value = comboCount = 0;
    }

    private void TextBuilder(string msg, TextMeshProUGUI text)
    {
        sb.Clear();
        sb.Append(msg);
        text.SetText(sb);
    }

    public void GetScore()
    {
        curScore += score;
        FeverGaugeUp();
        TextBuilder(score.ToString(), scoreText);
        animator.SetTrigger("Get");
    }

    private void FeverGaugeUp()
    {
        if (fever) return;

        if (feverGauge.value == feverGauge.maxValue)
        {
            fever = true;
            score *= 2;
        }
        else
        {
            feverGauge.value += getFeverGauge;
        }
    }

    private void FeverGaugeDown()
    {
        if (fever)
        {
            if (feverGauge.value == feverGauge.minValue)
            {
                fever = false;
                score = GameManager.SCORE;
            }
            else
            {
                feverGauge.value -= getFeverGauge * Time.deltaTime;
            }
        }
    }

    private void ShowComboCount()
    {
        if (comboCount >= getComboCount)
        {
            combo.SetActive(true);
        }
        else
        {
            combo.SetActive(false);
        }
        TextBuilder(comboCount.ToString(), comboText);
    }
}
