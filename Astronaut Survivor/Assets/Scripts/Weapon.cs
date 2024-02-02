using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { none, Gun, Sword, Bow, Hammer, Rifle, Scythe }
    public Type weaponType;
    public WeaponType weapon;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CollectWeapon();
    }
    void CollectWeapon()
    {
        switch (weaponType)
        {
            case Type.none:
                break;
            case Type.Gun:
                changeWeapon();
                break;
            case Type.Sword:
                changeWeapon();
                break;
        }
        Destroy(gameObject, 0.01f);
    }
    void changeWeapon()
    {
        player.GetComponent<Animator>().runtimeAnimatorController = weapon.playerAnimator;
        // active the weapon
        GameObject weaponObject = player.transform.GetChild(0).gameObject;
        weaponObject.SetActive(weapon.weaponPref);

        //active the fire animation
        GameObject fireAni = player.transform.GetChild(0).transform.GetChild(0).gameObject;
        fireAni.SetActive(weapon.particalAnimation);


        //add animator for weapon 
        weaponObject.GetComponent<Animator>().runtimeAnimatorController = weapon.weaponAnimator ? weapon.weaponAnimator : null;

        //add sprite for weapon 
        weaponObject.GetComponent<SpriteRenderer>().sprite = weapon.weaponSprite? weapon.weaponSprite:null;


        //setActive for the arms
        player.transform.GetChild(1).gameObject.SetActive(weapon.haveOverLay);
        player.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = weapon.overlayAnimator?weapon.overlayAnimator:null;

        fireAni.GetComponent<Animator>().runtimeAnimatorController = weapon.particalAnimation? weapon.particalAnimator:null;
    }
}
