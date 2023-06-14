using System.Collections.Generic;
using UnityEngine;

public class ShootUsingPool : MonoBehaviour
{
    public static ShootUsingPool instance;
    [SerializeField]
    public GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField]
    public GameObject bullet2Prefab; // Prefab for the bullet
    //private GameObject currentBullet; // Prefab for the bullet
    public int maxBullets = 10; // Maximum number of bullets on screen
    public List<GameObject> bulletPool = new List<GameObject>(); // List of active bullets



    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        // Initialize the bullet pool with a capacity of maxBullets
        for (int i = 0; i < 5; i++)
        {

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
        for (int i = 0; i < 5; i++)
        {

            GameObject bullet = Instantiate(bullet2Prefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }

    }
    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool[0];
            //bulletPool.Remove(bullet);
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            return null;
        }
    }
    public GameObject GetBulletTurnAround()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool[5];
            //bulletPool.Remove(bullet);
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            return null;
        }
    }
    public void ReturnBullet(GameObject bullet)
    {
        //bulletPool.Add(bullet);
        bullet.SetActive(false);
    }
    public void ReturnBulletTurnAround(GameObject bullet)
    {
        //bulletPool.Add(bullet);
        bullet.SetActive(false);
    }
}
