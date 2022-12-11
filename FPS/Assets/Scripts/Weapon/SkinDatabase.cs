using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkinDatabase : ScriptableObject
{
    [SerializeField] private GameObject[] skins;

    public GameObject GetSkin(int index)
    {
        return skins[index];
    }
}
