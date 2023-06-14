using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private const string Score = "Score";

    public int score { set; get; } = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            score++;
            Debug.Log(score);
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoints(score);
            Destroy(gameObject);
        }
    }
    //private void OnColliderEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Circle"))
    //    {
    //        score += 1;
    //        PlayerPrefs.SetInt(Score, score);
    //        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    //        hud.AddPoints(score);
    //        Destroy(gameObject);
    //    }
    //}
}
