using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeOfAttack : MonoBehaviour
{
    Enemy enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (enemy)
        {
            enemy.canAttack = true;
            enemy.ani.SetBool("Attack-A", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        enemy.canAttack = false;
        enemy.ani.SetBool("Attack-A", false);
    }
}
