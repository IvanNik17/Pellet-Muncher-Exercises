using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemyPrefab;
    public float spawnSpeed = 3f;

    float timerCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerCounter += Time.deltaTime;

        if (timerCounter >= spawnSpeed)
        {
            SpawnEnemyNow(enemyPrefab);
            timerCounter = 0;
        }
    }

    void SpawnEnemyNow(GameObject enemyPrefab)
    {
        Quaternion randRot = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Instantiate(enemyPrefab, new Vector3(Random.Range(-20, 20), 1.5f, Random.Range(-20, 20)), randRot);
    }
}
