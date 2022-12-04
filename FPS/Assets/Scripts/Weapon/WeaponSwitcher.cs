using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int _selectedItem;
    
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();

        SelectItem();
    }

    private void Update()
    {
        int previouslySelectedItem = _selectedItem;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_selectedItem >= transform.childCount - 1)
            {
                _selectedItem = 0;
            }
            else
            {
                _selectedItem++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_selectedItem <= 0)
            {
                _selectedItem = transform.childCount - 1;
            }
            else
            {
                _selectedItem--;
            }
        }

        if (previouslySelectedItem != _selectedItem)
        {
            SelectItem();
        }
    }

    private void SelectItem()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform item = transform.GetChild(i);

            if (i == _selectedItem)
            {
                _playerController.Gun = item.gameObject.GetComponent<Gun>();
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
