using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int BestScore {get => PlayerPrefs.GetInt("Score", 0); private set => PlayerPrefs.SetInt("Score", value); }
    [SerializeField] private PigControl _pig;

    [SerializeField]private TextMeshProUGUI _scoreText;
    [SerializeField]private TextMeshProUGUI _bestScoreText;
    private void Awake()
    {
        _pig.HeightChanged += AddScore;
        _bestScoreText.text = BestScore.ToString();
    }
    public void AddScore()
    {
        int score;
        score = _pig.MaxHeight;

        if(score > BestScore)
            BestScore = score;

        _scoreText.text = _pig.MaxHeight.ToString();
        _bestScoreText.text = BestScore.ToString();
    }
}
