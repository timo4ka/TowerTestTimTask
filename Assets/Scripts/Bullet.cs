using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private int damage;
    public void Init(Transform targetNew, int newDamage)
    {
        damage=newDamage;
        target = targetNew;
        Destroy(transform.gameObject, 10f);
    }
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * 5f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }
}
