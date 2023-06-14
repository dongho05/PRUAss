using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("StraightBullet") || collision.gameObject.CompareTag("TurnAroundBullet"))
        {

            Destroy(gameObject);
        }

    }
}
