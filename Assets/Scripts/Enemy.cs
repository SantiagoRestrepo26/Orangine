using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private GameObject effectDead;

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Dead();
        }
    }

    public void Dead() 
    {
        Instantiate(effectDead, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
