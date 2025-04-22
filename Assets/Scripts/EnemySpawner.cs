using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;
    private float timeUntilSpawn;
    private float randPosY;

    private void Awake() 
    {
        SetTimeUntilSpawn();
        SetRandomYPos();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, randPosY, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            randPosY = 0;
            SetTimeUntilSpawn();
            SetRandomYPos();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void SetRandomYPos()
    {
        randPosY = Random.Range(-1, 4);
    }
}
