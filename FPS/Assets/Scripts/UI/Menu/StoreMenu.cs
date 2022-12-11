using UnityEngine;

public class StoreMenu : MonoBehaviour
{
    public void SelectSkin(int index)
    {
        PlayerPrefs.SetInt("Skin", index);
    }
}
