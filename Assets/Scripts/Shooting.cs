using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 5f;

    float shootSpeed;

    float timerCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootSpeed = Random.Range(0.1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        timerCounter += Time.deltaTime;

        if (timerCounter >= shootSpeed)
        {
            Vector3 enemyPos = transform.position;
            Vector3 spawnBulletPos = enemyPos + transform.forward*1.1f;
            GameObject bullet = Instantiate(bulletPrefab, spawnBulletPos, Quaternion.identity);

            bullet.transform.GetComponent<Rigidbody>().AddForce(transform.forward* bulletForce, ForceMode.Impulse);
            timerCounter = 0;

            shootSpeed = Random.Range(0.1f, 10f);
        }
    }
}
