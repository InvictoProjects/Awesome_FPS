using Assets.Scripts.Player.Characteristics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammo;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        WeaponSwitcher switcher = player.GetComponentInChildren<WeaponSwitcher>();

        for (int i = 0; i < switcher.transform.childCount; i++)
        {
            Gun gun = switcher.transform.GetChild(i).GetComponent<Gun>();
            gun.OnAmmoChanged += Ammo_OnChanged;
        }
    }

    private void Ammo_OnChanged(int ammoCount)
    {
        ammo.text = ammoCount.ToString();
    }
}
