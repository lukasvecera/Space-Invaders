using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireRate = 3f;
    private float fireTimer;

    void Update()
    {


        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            Fire();
            fireTimer = Random.Range(fireRate - 1f, fireRate + 1f);
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * 5f;
        Destroy(bullet, 3f);
    }
    
    public void CancelFireImmediately()
{
    fireTimer = float.MaxValue;
}
}

