using UnityEngine;

public class MultipleBulletWithPool : MonoBehaviour
{
    //public GameObject straightBulletPrefab;
    //public GameObject rotatingBulletPrefab;
    //public Transform spawnPoint;
    //public float bulletSpeed = 10f;
    //public int maxTotalBullets = 5;

    //private ObjectPool<GameObject> straightBulletPool;
    //private ObjectPool<GameObject> rotatingBulletPool;
    //private int straightBulletCount = 0;
    //private int rotatingBulletCount = 0;

    //private void Start()
    //{
    //    straightBulletPool = new ObjectPool<GameObject>(straightBulletPrefab, maxTotalBullets);
    //    rotatingBulletPool = new ObjectPool<GameObject>(rotatingBulletPrefab, maxTotalBullets);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        SpawnStraightBullet();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        SpawnRotatingBullet();
    //    }
    //}

    //private void SpawnStraightBullet()
    //{
    //    if (straightBulletCount + rotatingBulletCount >= maxTotalBullets)
    //        return;

    //    GameObject bulletObject = straightBulletPool.GetPooledObject();
    //    bulletObject.transform.position = spawnPoint.position;
    //    bulletObject.transform.rotation = spawnPoint.rotation;
    //    bulletObject.SetActive(true);
    //    bulletObject.GetComponent<Rigidbody>().velocity = bulletSpeed * spawnPoint.forward;

    //    straightBulletCount++;
    //}

    //private void SpawnRotatingBullet()
    //{
    //    if (straightBulletCount + rotatingBulletCount >= maxTotalBullets)
    //        return;

    //    GameObject bulletObject = rotatingBulletPool.GetPooledObject();
    //    bulletObject.transform.position = spawnPoint.position;
    //    bulletObject.transform.rotation = spawnPoint.rotation;
    //    bulletObject.SetActive(true);

    //    rotatingBulletCount++;
    //}
}
