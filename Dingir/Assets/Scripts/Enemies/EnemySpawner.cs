using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public GameObject[] walls;
    public GameObject[] enemies;
    public GameObject go;
    Player player;

    public int killCount;
    int enemyCount;
    bool isCreated;
    bool isCreated2;
    bool isCreated3;
    bool isCreated4;
    bool stage1;
    bool stage2;
    bool stage3;
    bool stage4;
    bool stage5;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = Player.Instance;
        killCount = 0;
        StartCoroutine(InitEnemy(enemies[0]));
        StartCoroutine(InitEnemy(enemies[0]));

        isCreated = false;
        isCreated2 = false;
        isCreated3 = false;
        isCreated4 = false;
        stage1 = false;
        stage2 = false;
        stage3 = false;
        stage4 = false;
        stage5 = false;
    }

    private void Update()
    {
        Debug.Log("Kill count: " + killCount);

        if(killCount >= 2)
        {
            walls[0].SetActive(false);
            stage1 = true;
        }

        if(stage1 && !isCreated)
        {
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(-10, 20), 0.5f, Random.Range(-6, 0))));
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(-10, 20), 0.5f, Random.Range(-6, 0))));
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(-10, 20), 0.5f, Random.Range(-6, 0))));
            isCreated = true;
        }

        if(killCount >= 5 && stage1)
        {
            walls[1].SetActive(false);
            stage2 = true;
        }

        if (stage2 && !isCreated2)
        {
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(29, 55), 0.5f, Random.Range(-6, 0))));
            isCreated2 = true;
        }

        if (killCount >= 6 && stage2)
        {
            walls[2].SetActive(false);
            stage3 = true;
        }

        if (stage3 && !isCreated3)
        {
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(63, 89), 0.5f, Random.Range(-6, 0))));
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(63, 89), 0.5f, Random.Range(-6, 0))));
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(63, 89), 0.5f, Random.Range(-6, 0))));
            isCreated3 = true;
        }

        if (killCount >= 9 && stage3)
        {
            walls[3].SetActive(false);
            stage4 = true;
        }

        if (stage4 && !isCreated4)
        {
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(98, 125), 0.5f, Random.Range(-6, 0))));
            StartCoroutine(SpawnEnemy(enemies[0], new Vector3(Random.Range(98, 125), 0.5f, Random.Range(-6, 0))));
            isCreated4 = true;
        }

        if (killCount >= 11 && stage4)
        {
            walls[4].SetActive(false);
            stage5 = true;
        }
    }

    IEnumerator InitEnemy(GameObject _enemy)
    {
        yield return new WaitForSeconds(15);
        GameObject newEnemy = Instantiate(_enemy, new Vector3(Random.Range(-23, -13), 0.5f, Random.Range(-6, 0)), Quaternion.identity);
    }

    IEnumerator SpawnEnemy(GameObject _enemy, Vector3 _pos)
    {
        yield return new WaitForSeconds(2);
        GameObject newEnemy = Instantiate(_enemy, _pos, Quaternion.identity);
    }

    IEnumerator TurnOffGo()
    {
        go.SetActive(true);
        yield return new WaitForSeconds(2);
        go.SetActive(false);
    }
}
