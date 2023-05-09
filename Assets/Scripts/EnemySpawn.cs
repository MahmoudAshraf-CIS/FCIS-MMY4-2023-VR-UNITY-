using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject _enemyPrefab;
    public List<Transform> _spawiningPoints;
    public float rate = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnInRandomPosition", 1f, rate);
    }

    

    void SpawnInRandomPosition()
    {
        Debug.Log("spawning");
        GameObject enemy = Instantiate(_enemyPrefab);
        int index = Random.Range(0, _spawiningPoints.Count);
        enemy.transform.position = _spawiningPoints[index].position;
        enemy.transform.rotation = _spawiningPoints[index].rotation;


        enemy.transform.parent = _spawiningPoints[index];
        
    }
}
