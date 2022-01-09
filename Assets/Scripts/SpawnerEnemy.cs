using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public static int countEnemy;

    Vector2[] spawnerPositions =
        {
        new Vector2(-24.7f,-3.2f),
        new Vector2(-16.5f,-3.2f),
        new Vector2(-5.6f,-3.2f),
        new Vector2(16.3f,-3.2f),
        new Vector2(24.2f,-3.2f),
        new Vector2(-21.6f,-0.2052606f),
        new Vector2(-11f,-0.2051462f),
        new Vector2(5.867497f,-0.2052538f),
        new Vector2(-3.275534f,1.794813f),
        new Vector2(16.24087f,1.79497f)
    };

    void Awake()
    {
        countEnemy = Random.Range(1, spawnerPositions.Length + 1);

        List<int> list = new List<int>(spawnerPositions.Length);

        int index;

        for (int i = 0; i < spawnerPositions.Length; i++)
        {
            list.Add(i);
        }

        for (int i = 0; i < countEnemy; i++)
        {
            index = list[Random.Range(0, list.Count)];
            list.Remove(index);
            Instantiate(enemyPrefab, spawnerPositions[index], Quaternion.identity);            
        }
    }
}