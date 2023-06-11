using System;
using Emrenemy_Scripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    private Camera _mainCamera;
    
    public WeaponType weaponType;
    [Header("Settings for all weapon types")]
    public float fireRate;
    public float weaponDamage;
    public GameObject weaponTip;
    public bool hasAnimator;
    private AudioSource _audioSource;

    [Header("If weapon type is DefaultGun")]
    public GameObject bulletPrefab;
    public int currentBulletAmountOnMagazine;
    public int magazineCapacity;
    public AudioClip shootSfx;
    public AudioClip reloadSfx;


    [Header("If weapon type is BeamGun")]
    public float maxLaserLenght;
    public GameObject laser;
    public LineRenderer lineRenderer;
    public float currentHeat;
    public float heatCapacity;
    private bool _overHeated;
    private bool _shootingLaser;
    
    private static readonly int Fire1 = Animator.StringToHash("Fire");
    private float _lastFireTime;

    private bool _laserIsActive;

    public enum WeaponType
    {
        DefaultGun,
        BeamGun
    }


    private void Start()
    {
        _mainCamera = Camera.main;
        if(hasAnimator) _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        currentBulletAmountOnMagazine = magazineCapacity;
        
        if (weaponType == WeaponType.BeamGun)
        {
            laser.SetActive(false);
        }
    }

    private void Update()
    {
        if (!_shootingLaser && currentHeat > 0)
        {
            currentHeat -= 20 * Time.deltaTime;
            if (currentHeat <= 0) _overHeated = false;
        }

        if (weaponType == WeaponType.DefaultGun)
        {
            UIManager.Instance.SetWeaponText("Bullets:\n" + currentBulletAmountOnMagazine + "/" + magazineCapacity);
        }
        else if (weaponType == WeaponType.BeamGun)
        {
            UIManager.Instance.SetWeaponText("Heat:\n" + Mathf.Round(currentHeat) + "/" + heatCapacity);
        }
    }

    public void StartFire()
    {
        if (weaponType == WeaponType.BeamGun && !_overHeated)
        {
            laser.SetActive(true);
            _audioSource.Play();
        }
    }

    public void Fire()
    {
        if (weaponType == WeaponType.DefaultGun)
        {
            if (_lastFireTime + fireRate < Time.time && currentBulletAmountOnMagazine > 0)
            {
                if(hasAnimator) _animator.SetTrigger(Fire1);
                var bullet = Instantiate(bulletPrefab, weaponTip.transform.position,quaternion.identity);
                bullet.transform.right = transform.right;
                bullet.GetComponent<Bullet>().SetBulletDamage(weaponDamage);
                currentBulletAmountOnMagazine--;
                _audioSource.PlayOneShot(shootSfx);
                _lastFireTime = Time.time;
            }
        }
        else if (weaponType == WeaponType.BeamGun && !_overHeated)
        {
            _shootingLaser = true;
            currentHeat += 20 * Time.deltaTime;
            if (currentHeat >= heatCapacity)
            {
                _overHeated = true;
                laser.SetActive(false);
                StopFire();
                return;
            }
            laser.SetActive(true);
            var weaponTipPosition = weaponTip.transform.position;
            Transform transform1;
            
            lineRenderer.SetPosition(0,weaponTipPosition);
            
            lineRenderer.SetPosition(1,(Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition));
            
            var direction = (Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)(transform1 = transform).position;
            var hit = Physics2D.Raycast(transform1.position, direction.normalized, direction.magnitude);
            if (hit)
            {
                lineRenderer.SetPosition(1,(Vector2)hit.point);
                if(hit.transform.CompareTag("EmrenemyHitbox"))
                {
                    if (_lastFireTime + fireRate < Time.time)
                    {
                        hit.transform.gameObject.GetComponent<EmrenemyHitbox>().TakeDamage(weaponDamage);
                        _lastFireTime = Time.time;
                    }
                }
            }
        }
    }

    public void StopFire()
    {
        if (weaponType == WeaponType.BeamGun)
        {
            laser.SetActive(false);
            _shootingLaser = false;
            _audioSource.Stop();
        }
    }

    public void Reload()
    {
        if (weaponType == WeaponType.DefaultGun)
        {
            currentBulletAmountOnMagazine = magazineCapacity;
            _audioSource.PlayOneShot(reloadSfx);
        }
        
    }
}
