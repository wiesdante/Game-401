using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    
    public float fireRate;
    public float weaponDamage;
    private float _lastFireTime;

    public bool hasAnimator;
    public GameObject bulletPrefab;
    public GameObject weaponTip;
    private static readonly int Fire1 = Animator.StringToHash("Fire");


    private void Start()
    {
        if(hasAnimator) _animator = GetComponent<Animator>();
    }

    public void Fire()
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
}
