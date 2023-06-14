using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public float minForce = 2f;
    public float maxForce = 7f;
    Timer timer;
    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1f;
        timer.Run();
        SpawnE(spawnPoint1);
        SpawnE(spawnPoint2);
    }
    private void Update()
    {
        if (timer.Finished)
        {
            SpawnE(spawnPoint1);
            SpawnE(spawnPoint2);
            timer.Duration = 1f;
            timer.Run();
        }
    }
    private void SpawnE(Transform spawnPoint)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Tạo một lực ngẫu nhiên
        Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        float forceMagnitude = Random.Range(minForce, maxForce);
        Vector2 force = forceDirection * forceMagnitude;

        // Thêm lực vào quái vật
        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
        enemyRigidbody.AddForce(force, ForceMode2D.Impulse);
    }
}
