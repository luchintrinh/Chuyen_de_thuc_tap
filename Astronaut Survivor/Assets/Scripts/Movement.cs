using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Vector2 moveDir;
    public Vector2 mousePos;
    Rigidbody2D rb;
    public GameObject weapon;

    public float moveSpeed = 6f;

    [Header("# Dash")]
    public float dashSpeed = 10f;
    public bool isReadyDash;
    public float timeToDash = 0.5f;
    float timer;
    public float timeDelay = 2f;

    [Header("# Ghost Effect")]
    public GameObject Ghost_player;
    private Coroutine cor;
    public float delay_ghost = 0.01f;

    [Header("# Fire")]
    public bool isFire;
    float timeDelayFire = 1f;
    float timerFire;

    private void Awake()
    {
        isReadyDash = true;

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameManager.instance.haveWeapon)
        {
            weapon = transform.Find("Weapon").gameObject;
        }
    }

    //Move 
    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
    //Dash
    void OnFire(InputValue value)
    {
        if (isFire)
        {
            StartCoroutine(FireAnimation());
        }
    }
    IEnumerator FireAnimation()
    {
        //animation attack
        if (GameManager.instance.weapon && isFire)
        {
            isFire = false;
            GameManager.instance.weapon.AnimatorSystem(GameManager.instance.weapon.weapon.playerAnimator, GameManager.instance.weapon.weapon.weaponAnimator, GameManager.instance.weapon.weapon.overlayAnimator, GameManager.instance.weapon.weapon.particalAnimator, GameManager.instance.weapon.weapon.weaponSprite, GameManager.instance.weapon.weapon.weaponPref, GameManager.instance.weapon.weapon.particalAnimation, GameManager.instance.weapon.weapon.haveOverLay);
            yield return new WaitForSeconds(1f);
            GameManager.instance.weapon.AnimatorSystem(GameManager.instance.weapon.weapon.idleAnimator, null, null, GameManager.instance.weapon.weapon.particalAnimator, GameManager.instance.weapon.weapon.weaponSprite, GameManager.instance.weapon.weapon.weaponPref, false, GameManager.instance.weapon.weapon.haveOverLay);
        }
    }
    void OnDash(InputValue value)
    {
        if (value.isPressed&&isReadyDash==true) Dash();
    }

    void Dash()
    {
        moveSpeed += dashSpeed;
        StartDash();
        isReadyDash = false;
        Invoke("EndDash", timeToDash);
    }

    void StopDash()
    {
        if (cor != null) StopCoroutine(cor);
    }
    void StartDash()
    {
        if (cor != null) StopCoroutine(cor);
        cor=StartCoroutine(Ghost_Effect_Dash());
    }
    IEnumerator Ghost_Effect_Dash()
    {
        while (true)
        {
            GameObject ghost= Instantiate(Ghost_player, transform.position, transform.rotation);
            ghost.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            ghost.transform.localScale = transform.localScale;
            Destroy(ghost, 1f);
            yield return new WaitForSeconds(delay_ghost);
        }
    }

    void EndDash()
    {
        if(!isReadyDash)
        {
            StopDash();
            moveSpeed -= dashSpeed;
        }
    }
    private void Update()
    {
        // check ability to dash
        if (isReadyDash == false)
        {
            timer += Time.deltaTime;
            if (timer >= timeDelay + timeToDash)
            {
                timer = 0;
                isReadyDash = true;
            }
        }
        //check ability to Fire;

        if (isFire == false)
        {
            timerFire += Time.deltaTime;
            if (timerFire >= timeDelayFire)
            {
                timer = 0;
                isFire = true;
            }
        }
        

    }

    void OnMousePosition(InputValue value)
    {
        mousePos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (Vector3)moveDir * moveSpeed * Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {
        WeaponDir();
    }
    public void WeaponDir()
    {
        Vector3 dir = transform.localScale;
        dir.x = transform.position.x < mousePos.x ? -1 : 1; 
        transform.localScale = dir;
        Vector2 gunDir = mousePos - (Vector2)weapon.transform.position ;
        float angle = Mathf.Atan2(gunDir.y, gunDir.x) * Mathf.Rad2Deg;
        if (weapon)
        {
            if (dir.x == -1)
            {
                weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                
                weapon.transform.rotation = Quaternion.Euler(0, 0, angle+180);
            }
        }
    }
}
