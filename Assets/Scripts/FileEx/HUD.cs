using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Fields
    [SerializeField]
    TextMeshProUGUI scoreText;
    float score;
    const string ScorePrefix = "Score: ";

    #endregion
    private void Start()
    {
        scoreText.text = ScorePrefix + score.ToString();
    }
    public void AddPoints(float points)
    {
        score += points / 2f;
        scoreText.text = ScorePrefix + score.ToString();
    }
    public float GetPoints()
    {
        return score;
    }
}
