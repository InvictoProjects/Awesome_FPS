using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private SkinDatabase _skinDatabase;

    private void Awake()
    {
        int selectedSkin = PlayerPrefs.GetInt("Skin", 0);
        var skin = _skinDatabase.GetSkin(selectedSkin);
        Instantiate(skin, transform);
    }
}
