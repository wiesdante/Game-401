using Emrenemy_Scripts;
using Unity.Mathematics;
using UnityEngine;

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
    
    [Header("If weapon type is DefaultGun")]
    public GameObject bulletPrefab;

    [Header("If weapon type is BeamGun")]
    public float maxLaserLenght;
    public GameObject laser;
    public LineRenderer lineRenderer;
    
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
        
        if (weaponType == WeaponType.BeamGun)
        {
            laser.SetActive(false);
        }
    }

    public void StartFire()
    {
        if (weaponType == WeaponType.BeamGun)
        {
            laser.SetActive(true);
        }
    }

    public void Fire()
    {
        if (weaponType == WeaponType.DefaultGun)
        {
            if (_lastFireTime + fireRate < Time.time)
            {
                if(hasAnimator) _animator.SetTrigger(Fire1);
                var bullet = Instantiate(bulletPrefab, weaponTip.transform.position,quaternion.identity);
                bullet.transform.right = transform.right;
                bullet.GetComponent<Bullet>().SetBulletDamage(weaponDamage);
                _lastFireTime = Time.time;
            }
        }
        else if (weaponType == WeaponType.BeamGun)
        {
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
        }
    }
}
