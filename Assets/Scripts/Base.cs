using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]
public class Base : MonoBehaviour
{
    [SerializeField] private Image radiusUI;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform gunPoint;
    private bool active;
    private int radius;
    private float shotSpeed;
    private int damage;

    private float shotTimer = 0;

    private UpgradeManager upgradeManager;
    private SphereCollider sphereCollider;

    private List<Enemy> enemies = new List<Enemy>();
    private void OnEnable()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;

        EventManager.Subscribe(eEventType.LevelStart, (e) => SetActive(true));
        EventManager.Subscribe(eEventType.LevelComplete, (e) => SetActive(false));
        EventManager.Subscribe(eEventType.LevelLost, (e) => SetActive(false));
        EventManager.Subscribe(eEventType.UpdateParameter, (e) => updateAllShotParameters());

        upgradeManager = FindAnyObjectByType<UpgradeManager>();
    }

    private void Update()
    {
        if (!active)
            return;

        shotTimer += Time.deltaTime;


        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }

        if (enemies.Count <= 0)
            return;

        if (shotTimer < shotSpeed)
            return;


        float angle = Mathf.Atan2(enemies[0].transform.position.x - transform.position.x, enemies[0].transform.position.z - transform.position.x) * Mathf.Rad2Deg;
        Vector3 newVec = new Vector3(0f, 0f, 0f);
        newVec.y = angle;
        transform.eulerAngles = newVec;

        shotTimer = 0;
        Instantiate(bullet, gunPoint.position, gunPoint.rotation, null).Init(enemies[0].transform, damage);

    }
    public void SetActive(bool value)
    {
        active = value;

        if (active)
        {
            updateAllShotParameters();
        }
        else
        {

        }
    }

    private void updateAllShotParameters()
    {
        damage = upgradeManager.Damage;
        shotSpeed = upgradeManager.ShotSpeed;
        radius = upgradeManager.Radius;
        radiusUI.transform.localScale = Vector3.one * radius;
        sphereCollider.radius = radius;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (!enemies.Contains(enemy))
                enemies.Add(enemy);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            EventManager.OnEvent(eEventType.LevelLost);
        }
    }
}
