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
    [SerializeField] GameObject recordText;
    [SerializeField] Slider feverGauge;
    [SerializeField] Animator animator;

    [Space]
    [SerializeField] int curScore;
    [SerializeField] int score;
    [SerializeField, Range(0, 0.5f)] float getFeverGauge;
    [SerializeField] bool fever;

    private StringBuilder sb = new StringBuilder();
    private int highScore;

    private void Awake()
    {
        Init();
        score = GameManager.SCORE;
        highScore = GameManager.Instance.HighScore;
    }

    private void OnDisable()
    {
        if (recordText.activeSelf)
            GameManager.Instance.HighScore = curScore;
    }

    private void LateUpdate()
    {
        TextBuilder(curScore.ToString(), curScoreText);
        FeverGaugeDown();

        if(highScore < curScore)
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
        feverGauge.value = 0;
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
}
