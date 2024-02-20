using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public enum Type { Player, Enemy}
    public Type type;
    public int health;
    public int maxHealth;

    public void WasAttacked(int heal)
    {
        health -= heal;
        if (health <= 0)
        {
            Dead();
        }
    }
    public void WasHealth(int heal)
    {
        health += heal;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }
    void Dead()
    {
        switch (type)
        {
            case Type.Player:
                break;
            case Type.Enemy:
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Dead");
                gameObject.SetActive(false);
                break;
        }
    }

    public void EnemyDead()
    {
        gameObject.SetActive(false);
    }
}
