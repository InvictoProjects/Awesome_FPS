using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _damage = 20;
    [SerializeField] private float _range = 100;

    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] private bool _isReloading;
    public event Action<int> OnAmmoChanged;

    private float _nextTimeToFire;

    private Transform _cam;
    private Animator _animator;
    [SerializeField] private ParticleSystem _muzzleFlash;

    public int MaxAmmo { get => _maxAmmo; set => _maxAmmo = value; }

    private void Awake()
    {
        _cam = Camera.main.transform;
        _animator = GetComponentInParent<Animator>();

        _currentAmmo = _maxAmmo;
    }

    private void OnEnable()
    {
        _isReloading = false;
        OnAmmoChanged?.Invoke(_currentAmmo);

        _animator.SetBool("isReloading", false);
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
        _animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(_reloadTime - 0.25f);
        _animator.SetBool("isReloading", false);
        yield return new WaitForSeconds(0.25f);

        _currentAmmo = _maxAmmo;
        OnAmmoChanged?.Invoke(_currentAmmo);
        _isReloading = false;
    }

    private void Shoot()
    {
        _currentAmmo -= 1;
        OnAmmoChanged?.Invoke(_currentAmmo);

        _muzzleFlash.Play();

        if (Physics.Raycast(_cam.position, _cam.forward, out RaycastHit hit, _range))
        {
            if (hit.transform.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(_damage);
            }
        }
    }
}
