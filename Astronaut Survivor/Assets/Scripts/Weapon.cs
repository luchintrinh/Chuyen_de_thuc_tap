using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { none, Gun, Sword, Bow, Hammer, Rifle, Scythe }
    public Type weaponType;
    public WeaponType weapon;
    public GameObject player;

    GameObject fireAni;
    Movement movement;
    private void Awake()
    {
        movement = FindObjectOfType<Movement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CollectWeapon(weaponType, weapon);
    }
    public void CollectWeapon(Type weaponType, WeaponType weapon)
    {
        switch (weaponType)
        {
            case Type.none:
                break;
            case Type.Gun:
                changeWeapon(weapon);
                break;
            case Type.Sword:
                changeWeapon(weapon);
                break;
            case Type.Hammer:
                changeWeapon(weapon);
                break;
            case Type.Rifle:
                changeWeapon(weapon);
                break;
            case Type.Scythe:
                changeWeapon(weapon);
                break;
            case Type.Bow:
                changeWeapon(weapon);
                break;
        }
        Destroy(gameObject, 0.01f);
    }
    void changeWeapon(WeaponType weapon)
    {
        if (weapon.nearlyAttack)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = weapon.nearlyAttack?weapon.walkNotNearlyAttack : weapon.playerAnimator;
            // active the weapon
            GameObject weaponObject = player.transform.GetChild(0).gameObject;
            weaponObject.SetActive(weapon.weaponPref);

            //active the fire animation
            fireAni = player.transform.GetChild(0).transform.GetChild(0).gameObject;

            fireAni.SetActive(weapon.particalAnimation);

            //add animator for weapon 
            
            weaponObject.GetComponent<Animator>().runtimeAnimatorController = weapon.nearlyAttack ?null: weapon.weaponAnimator;

            //add sprite for weapon 
            weaponObject.GetComponent<SpriteRenderer>().sprite = weapon.weaponSprite ? weapon.weaponSprite : null;


            //setActive for the arms
            player.transform.GetChild(1).gameObject.SetActive(weapon.haveOverLay);
            player.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = weapon.nearlyAttack ?weapon.overlayNotAttack :weapon.overlayAnimator;

            fireAni.GetComponent<Animator>().runtimeAnimatorController = weapon.particalAnimation ? weapon.particalAnimator : null;

        }
        else
        {
            player.GetComponent<Animator>().runtimeAnimatorController = weapon.playerAnimator;
            // active the weapon
            GameObject weaponObject = player.transform.GetChild(0).gameObject;
            weaponObject.SetActive(weapon.weaponPref);

            //active the fire animation
            fireAni = player.transform.GetChild(0).transform.GetChild(0).gameObject;

            fireAni.SetActive(weapon.particalAnimation);

            //add animator for weapon 
            weaponObject.GetComponent<Animator>().runtimeAnimatorController = weapon.weaponAnimator ? weapon.weaponAnimator : null;

            //add sprite for weapon 
            weaponObject.GetComponent<SpriteRenderer>().sprite = weapon.weaponSprite ? weapon.weaponSprite : null;


            //setActive for the arms
            player.transform.GetChild(1).gameObject.SetActive(weapon.haveOverLay);
            player.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = weapon.overlayAnimator ? weapon.overlayAnimator : null;

            fireAni.GetComponent<Animator>().runtimeAnimatorController = weapon.particalAnimation ? weapon.particalAnimator : null;
        }

    }

}
