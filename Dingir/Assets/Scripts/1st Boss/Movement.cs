using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public  GameObject[] spawnPoints;
    public GameObject currentPoint;
    int index;

    void Start()
    {
        this.transform.position = new Vector3(-10.54f, 1.81f, 1.69f);
    }

    public void posRandomizer()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
    }

    public void posSpawn(Transform pos)
    {
        pos.position = currentPoint.transform.position;
    }
}
