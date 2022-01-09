using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Text timePastFromStartText;
    int _timeWhenKillAllEnemy;
    public Text countEnemyText;
    public GameObject playerWinPanel;

    float timePastFromStart;
    int CountEnemy { get; set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Instantiate();
    }

    void Update()
    {
        timePastFromStart += Time.deltaTime;
    }

    public void Instantiate()
    {
        CountEnemy = SpawnerEnemy.countEnemy;
        countEnemyText.text = CountEnemy.ToString();
    }

    public void EnemyDead()
    {
        countEnemyText.text = (--CountEnemy).ToString();
        if (CountEnemy == 0)
        {
            _timeWhenKillAllEnemy = (int)timePastFromStart;
            Invoke("PlayerWin", 1f);
        }
    }

    void PlayerWin()
    {
        GameObject.FindWithTag("Player").SetActive(false);

        playerWinPanel.SetActive(true);

        if (_timeWhenKillAllEnemy % 60 <= 9)
            timePastFromStartText.text = _timeWhenKillAllEnemy / 60 + ":0" + _timeWhenKillAllEnemy % 60;
        else
            timePastFromStartText.text = _timeWhenKillAllEnemy / 60 + ":" + _timeWhenKillAllEnemy % 60;
    }   
}