using UnityEngine;

public class GunController : MonoBehaviour
{
    // shooting support
    //[SerializeField]
    //GameObject prefabBullet;
    const float RotateDegreesPerSecond = 180;
    Vector2 thrustDirection = new Vector2(1, 0);
    public Transform firePoint;
    Timer timer;
    public float fireDelay = 0.2f; // Delay between each bullet fired
    int activeBulletCount = 0;
    private ShootUsingPool shooting;
    // Start is called before the first frame update
    void Start()
    {
        //timer = gameObject.AddComponent<Timer>();
        //timer.Duration = fireDelay;
        //timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
        // shoot as appropriate

        //if (timer.Finished)
        //{
        //    Fire();
        //    timer.Duration = fireDelay;
        //    timer.Run();
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            FireBulletTurnAround();
        }
    }
    private void Fire()
    {

        // Get a bullet object from the pool and set its position and rotation
        for (int i = 0; i < 5; i++)
        {
            if (ShootUsingPool.instance.bulletPool[i].active == false && ShootUsingPool.instance.bulletPool[i].tag.Equals("StraightBullet"))
            {
                GameObject bullet = ShootUsingPool.instance.bulletPool[i];
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                Bullet script = bullet.GetComponent<Bullet>();
                script.ApplyForce(thrustDirection);
                return;
            }
        }

        // Add the bullet to the list of active bullets and activate it
        //}
    }
    private void FireBulletTurnAround()
    {
        for (int i = 5; i < 10; i++)
        {
            if (ShootUsingPool.instance.bulletPool[i].active == false && ShootUsingPool.instance.bulletPool[i].tag.Equals("TurnAroundBullet"))
            {
                GameObject bullet = ShootUsingPool.instance.bulletPool[i];
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                Bullet2Controller script = bullet.GetComponent<Bullet2Controller>();
                script.ApplyForce(thrustDirection);
                return;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            Destroy(gameObject);
        }
    }
}
