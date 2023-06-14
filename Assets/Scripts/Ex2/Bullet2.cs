using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform rotationCenter;
    public float rotationSpeed = 10f;
    public float rotationRadius = 0.5f;

    public float Impulse = 10f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        //bullet_timer = gameObject.AddComponent<Timer>();
        //bullet_timer.Duration = 6;
        //bullet_timer.Run();
    }

    private void Update()
    {
        RotateAroundCenter();
        //if (transform.position.y > 5 || transform.position.y < -5
        //    || transform.position.x > 15 || transform.position.x < -12)
        //{
        //    gameObject.SetActive(false);
        //    ShootUsingPool.instance.ReturnBullet(gameObject);

        //}
    }

    private void RotateAroundCenter()
    {
        float angle = Time.time * rotationSpeed;
        Vector3 offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * rotationRadius;
        transform.position = rotationCenter.position + offset;
    }
    //public void ApplyForce(Vector2 forceDirection)
    //{
    //    const float forceMagnitude = 10f;
    //    GetComponent<Rigidbody2D>().AddForce(
    //        forceMagnitude * forceDirection,
    //        ForceMode2D.Impulse);
    //}
}
