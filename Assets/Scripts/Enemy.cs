using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject dieFX;
    [SerializeField] private int hp = 3;
    private Transform target;

    private void OnEnable()
    {
        target = FindAnyObjectByType<Base>().transform;
    }

    private void Update()
    {
         Vector3 to = target.position - transform.position;
        transform.forward = to;
        transform.position += transform.forward * Time.deltaTime;
    }

    public void ReceiveDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameObject fx = Instantiate(dieFX, transform.position, Quaternion.identity);
            Destroy(fx, 3f);
            FindAnyObjectByType<MoneyManager>().AddMoney(1);
            Destroy(gameObject);
        }
    }
}
