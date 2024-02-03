using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public WeaponType[] listWeapon;
    public bool haveWeapon=true;
    public Weapon weapon;
    public WeaponType weaponType;

    private void Awake()
    {
        if (instance != null)
        {
            instance = FindObjectOfType<GameManager>();
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
    private void Start()
    {
        weapon = FindObjectOfType<Weapon>();
        weapon.CollectWeapon(Weapon.Type.none, weaponType);
    }
}
