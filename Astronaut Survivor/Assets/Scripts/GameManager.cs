using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public WeaponType[] listWeapon;
    public bool haveWeapon=true;

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
}
