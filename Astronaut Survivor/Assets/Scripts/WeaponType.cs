using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new Weapon", menuName ="Weapon")]
public class WeaponType : ScriptableObject
{

    [Header ("# GameObject need create")]
    public bool weaponPref;
    public bool particalAnimation;

    [Header("# Sprites")]
    public Sprite weaponSprite;

    [Header("# Animator")]
    public RuntimeAnimatorController playerAnimator;
    public RuntimeAnimatorController weaponAnimator;
    public RuntimeAnimatorController overlayAnimator;
    public RuntimeAnimatorController particalAnimator;
    public RuntimeAnimatorController idleAnimator;

    [Header("# Properties")]
    public float damage;
    public float bonusSpeed;
    public float timeDelayAttack;
}
