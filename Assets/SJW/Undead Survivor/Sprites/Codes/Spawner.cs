using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    int tmp;
    float timer;

    void Awake()
    {
       spawnPoint = GetComponentsInChildren<Transform>();
        tmp = 0;

    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.Instance.gameTime / 10f);

        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        tmp++;
        GameObject enemy=GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }

}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;

}
