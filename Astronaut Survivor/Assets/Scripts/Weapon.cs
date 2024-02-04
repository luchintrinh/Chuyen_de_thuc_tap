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
        movement = player.GetComponent<Movement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        GameManager.instance.weapon = this;
        Debug.Log(GameManager.instance.weapon);
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
                gameObject.SetActive(false);
                break;
            case Type.Sword:
                changeWeapon(weapon);
                gameObject.SetActive(false);
                break;
            case Type.Hammer:
                changeWeapon(weapon);
                gameObject.SetActive(false);
                break;
            case Type.Rifle:
                changeWeapon(weapon);
                gameObject.SetActive(false);
                break;
            case Type.Scythe:
                changeWeapon(weapon);
                gameObject.SetActive(false);
                break;
            case Type.Bow:
                changeWeapon(weapon);
                gameObject.SetActive(false);
                break;
        }
    }
    public void AnimatorSystem(RuntimeAnimatorController playerAni, RuntimeAnimatorController weaponAni, RuntimeAnimatorController overlayAni, RuntimeAnimatorController particalAni,Sprite weaponSprite, bool hasWeapon, bool hasPartical, bool hasOverlay)
    {
        player.GetComponent<Animator>().runtimeAnimatorController = playerAni ? playerAni : null ;
        // active the weapon
        GameObject weaponObject = player.transform.GetChild(0).gameObject;
        weaponObject.SetActive(hasWeapon);

        //active the fire animation
        fireAni = player.transform.GetChild(0).transform.GetChild(0).gameObject;

        fireAni.SetActive(hasPartical);

        //add animator for weapon 
        weaponObject.GetComponent<Animator>().runtimeAnimatorController = weaponAni ? weaponAni : null ;

        //add sprite for weapon 
        weaponObject.GetComponent<SpriteRenderer>().sprite = weaponSprite ? weaponSprite:null;


        //setActive for the arms
        player.transform.GetChild(1).gameObject.SetActive(hasOverlay);
        player.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = overlayAni ? overlayAni : null ;

        fireAni.GetComponent<Animator>().runtimeAnimatorController = particalAni?particalAni:null;

    }
    void changeWeapon(WeaponType weapon)
    {
        if (weapon.nearlyAttack)
        {
            AnimatorSystem(weapon.walkNotNearlyAttack, null, weapon.overlayAnimator, weapon.particalAnimator, weapon.weaponSprite, weapon.weaponPref, weapon.particalAnimation, weapon.haveOverLay);
        }
        else
        {
            AnimatorSystem(weapon.playerAnimator, weapon.weaponAnimator, weapon.overlayAnimator, weapon.particalAnimator, weapon.weaponSprite, weapon.weaponPref, false, weapon.haveOverLay);
        }

    }

}
