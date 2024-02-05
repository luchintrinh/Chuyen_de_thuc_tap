using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    Movement movement;
    private void Awake()
    {
        if (GameManager.instance.weapon)
        {
            damage = GameManager.instance.weapon.weapon.damage;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        Destroy(gameObject, 0.01f);
    }
}
