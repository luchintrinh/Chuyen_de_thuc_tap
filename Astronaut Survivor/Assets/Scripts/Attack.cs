using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("# Laser Prefab")]
    public GameObject bulletPrefab;
    public GameObject SwordLaserPrefab;
    public GameObject hammerLaserPrefab;
    public GameObject arrowPrefab;
    public GameObject rifleLaserPrefab;
    public GameObject scytheLaserPrefab;

    public Transform firePoint;
    public Transform attackPoint;
    public GameObject player;
    Movement movement;
    public float nearlySpeed = 4f;
    public float notNearlySpeed = 5f;

    private void Awake()
    {
        movement=player.GetComponent<Movement>();
    }
    public void InitLaser(GameObject prefab, float moveSpeed)
    {
        GameObject bullet=Instantiate(prefab, GameManager.instance.weapon.weapon.nearlyAttack?attackPoint.position:firePoint.position, Quaternion.identity, transform);
        Vector3 dir = (Vector3)movement.mousePos - bullet.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg);
        dir = dir.normalized;
        bullet.GetComponent<Rigidbody2D>().velocity=dir*moveSpeed;
        Destroy(bullet, 1f);
    }
    public void CreateBullet()
    {
        if (!GameManager.instance.weapon) return;
        switch (GameManager.instance.weapon.weaponType)
        {
            case Weapon.Type.Gun:
                InitLaser(bulletPrefab, notNearlySpeed);
                break;
            case Weapon.Type.Sword:
                InitLaser(SwordLaserPrefab, nearlySpeed);
                break;
            case Weapon.Type.Hammer:
                InitLaser(hammerLaserPrefab, nearlySpeed);
                break;
            case Weapon.Type.Rifle:
                InitLaser(rifleLaserPrefab, notNearlySpeed);
                break;
            case Weapon.Type.Scythe:
                InitLaser(scytheLaserPrefab, nearlySpeed);
                break;
            case Weapon.Type.Bow:
                InitLaser(arrowPrefab, notNearlySpeed);
                break;
        }
    }
}
