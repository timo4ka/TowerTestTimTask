using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float generateInterval = 3;
    [SerializeField] private float accelerationGeneration = 1.02f;
    [SerializeField] private GameObject enemy;
    private float timer = 0;
    private bool active = false;
    private void OnEnable()
    {
        EventManager.Subscribe(eEventType.LevelStart, (e) => SetActive(true));
        EventManager.Subscribe(eEventType.LevelComplete, (e) => SetActive(false));
        EventManager.Subscribe(eEventType.LevelLost, (e) => SetActive(false));
    }
    public void SetActive(bool value)
    {
        active = value;

    }

    private void Update()
    {
        if (!active)
            return;

        timer += Time.deltaTime;
        if (timer > generateInterval)
        {
            timer = 0;

            Instantiate(enemy, RandomPointInAnnulus(transform.position, 6), Quaternion.identity);

            if (generateInterval < 0.1f)
                return;

            generateInterval /= accelerationGeneration;
        }
    }

    public Vector3 RandomPointInAnnulus(Vector3 origin, float Radius)
    {
        var randomDirection = (new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f))).normalized;

        var point = origin + randomDirection * Radius;

        return point;
    }
}
