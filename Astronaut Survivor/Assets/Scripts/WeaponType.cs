using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new Weapon", menuName ="Weapon")]
public class WeaponType : ScriptableObject
{

    [Header ("# GameObject need create")]
    public bool weaponPref;
    public bool particalAnimation;
    public bool haveOverLay;
    public bool nearlyAttack;


    [Header("# Sprites")]
    public Sprite weaponSprite;

    [Header("# Animator attack")]
    public RuntimeAnimatorController playerAnimator;
    public RuntimeAnimatorController weaponAnimator;
    public RuntimeAnimatorController overlayAnimator;
    public RuntimeAnimatorController particalAnimator;
    [Header("# Animator Not Attack")]
    public RuntimeAnimatorController idleAnimator;
    public RuntimeAnimatorController walkNotNearlyAttack;
    public RuntimeAnimatorController overlayNotAttack;


    [Header("# Properties")]
    public float damage;
    public float bonusSpeed;
    public float timeDelayAttack;
}
