using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public void EnemyDead()
    {
        LevelManager.instance.EnemyDead();
        Destroy(gameObject);
    }
}