using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _damage = 20;
    [SerializeField] private float _range = 100;

    [SerializeField] private float _maxAmmo;
    [SerializeField] private float _currentAmmo;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] private bool _isReloading;

    private float _nextTimeToFire;

    private Transform cam;
    private ParticleSystem _muzzleFlash;

    private void Start()
    {
        cam = Camera.main.transform;

        _currentAmmo = _maxAmmo;
    }

    public void HandleShooting()
    {
        if (_isReloading)
        {
            return;
        }

        if (_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();
        }
    }

    private IEnumerator Reload()
    {
        _isReloading = true;

        yield return new WaitForSeconds(_reloadTime);

        _currentAmmo = _maxAmmo;
        _isReloading = false;
    }

    private void Shoot()
    {
        _currentAmmo -= 1;

        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, _range))
        {
            if (hit.transform.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(_damage);
            }
        }
    }
}
