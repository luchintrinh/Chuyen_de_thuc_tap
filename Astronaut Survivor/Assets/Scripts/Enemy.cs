using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1.5f;
    public Animator ani;
    public bool canAttack;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = transform.GetChild(0).GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (canAttack) return;
        Vector3 dir = GameManager.instance.player.transform.position-transform.position;
        dir = dir.normalized;
        rb.MovePosition(transform.position +dir*moveSpeed*Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {
        Vector3 dir = transform.GetChild(0).transform.localScale;
        dir.x= GameManager.instance.player.transform.position.x <= transform.position.x?-1:1;
        transform.GetChild(0).transform.localScale = dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return;
        ani.SetTrigger("Hit");
    }
}
