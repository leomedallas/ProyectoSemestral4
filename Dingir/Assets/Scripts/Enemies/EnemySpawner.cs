using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public GameObject[] walls;
    public GameObject[] enemies;
    public GameObject go;

    public int killCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        killCount = 0;
        StartCoroutine(InitEnemy(enemies[0]));
        StartCoroutine(InitEnemy(enemies[1]));
    }

    private void Update()
    {
        Debug.Log("Kill count: " + killCount);

        if(killCount >= 2)
        {
            walls[0].SetActive(false);
            StartCoroutine(Go(0.2f));
        }
    }

    IEnumerator InitEnemy(GameObject _enemy)
    {
        yield return new WaitForSeconds(15);
        GameObject newEnemy = Instantiate(_enemy, new Vector3(Random.Range(-23, -13), 0.5f, Random.Range(-10, 0)), Quaternion.identity);
    }

    IEnumerator Go(float _delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(_delay);
        go.SetActive(false);
        yield return new WaitForSeconds(_delay);
        go.SetActive(true);
        yield return new WaitForSeconds(_delay);
        go.SetActive(false);
        yield return new WaitForSeconds(_delay);
        go.SetActive(true);
        yield return new WaitForSeconds(_delay);
        go.SetActive(false);
    }
}
