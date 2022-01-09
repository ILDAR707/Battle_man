using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack : MonoBehaviour
{
    PlayerInput _input;
    AudioSource hitAudioSource;

    public LayerMask enemyLayerMask;
    public Transform pointSword;

    float timeBetweenFire1 = 0.4f;
    float timeBetweenFire2 = 0.6f;
    float pastTimeBetweenFire1;
    float pastTimeBetweenFire2;
    float timeHitSword = 0.24f;

    Animator _animation;

    public GameObject bulletPrefab;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Fire1.performed += context => Fire1();
        _input.Player.Fire2.performed += context => Fire2();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    void Start()
    {
        hitAudioSource = GetComponent<AudioSource>();
        _animation = GetComponent<Animator>();
    }

    void Update()
    {
        pastTimeBetweenFire1 += Time.deltaTime;
        pastTimeBetweenFire2 += Time.deltaTime;
    }

    void Fire1()
    {
        if (pastTimeBetweenFire1 < timeBetweenFire1)
            return;

        pastTimeBetweenFire1 = 0f;
        _animation.SetBool("sword", true);
        hitAudioSource.Play();
        StartCoroutine(HitSword());
    }
    void Fire2()
    {
        if (pastTimeBetweenFire2 < timeBetweenFire2)
            return;

        pastTimeBetweenFire2 = 0f;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    void SetSwordFalse()
    {
        _animation.SetBool("sword", false);
    }

    IEnumerator HitSword()
    {
        float _timeHitSword = timeHitSword;
        while(_timeHitSword > 0f)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(pointSword.position, 0.78f, enemyLayerMask);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].gameObject.GetComponent<Enemy>().EnemyDead();
            }
            _timeHitSword -= Time.deltaTime;
            yield return null;
        }
        _animation.SetBool("sword", false);
    }
}