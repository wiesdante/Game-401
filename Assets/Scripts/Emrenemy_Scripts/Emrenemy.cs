using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

namespace Emrenemy_Scripts
{
    public class Emrenemy : MonoBehaviour
    {
        public float moveSpeed;
        private Rigidbody2D _rb;
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        public float deathAnimationTime;
    
        private Transform _targetToChase;
        private int _chaseMeter;

        public bool playerIsInAttackRange;
        public float fireRate;
        private float _lastFireTime;
        private bool _isAlive = true;
    
        public float maxHealth;
        public HealthBar healthBar;
        private float _currentHealth;

        private bool _lookingLeft = true;

        public GameObject bullet;
        public float bulletSpeed;
        public float bulletDamage;

        void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _animator = gameObject.GetComponent<Animator>();

            _currentHealth = maxHealth;
            healthBar.InformHealthBar(_currentHealth,maxHealth);
        
            _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = moveSpeed;
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        private void Update()
        { 
            if(!_isAlive) return;
            if (_chaseMeter > 0)
            {
                _navMeshAgent.SetDestination(_targetToChase.transform.position);
                _animator.SetFloat("Velocity",_navMeshAgent.velocity.magnitude);
           
                if (_targetToChase.position.x > transform.position.x && _lookingLeft)
                {
                    var transform1 = transform;
                    var transformLocalScale = transform1.localScale;
                    transformLocalScale.x *= -1;
                    transform1.localScale = transformLocalScale;
                
                    var healthBarTransform = healthBar.transform;
                    var healthBarTransformLocalScale = healthBarTransform.localScale;
                    healthBarTransformLocalScale.x *= -1;
                    healthBarTransform.localScale = healthBarTransformLocalScale;
                
                    _lookingLeft = false;
                }
                else if(_targetToChase.position.x < transform.position.x && !_lookingLeft)
                {
                    var transform1 = transform;
                    var transformLocalScale = transform1.localScale;
                    transformLocalScale.x *= -1;
                    transform1.localScale = transformLocalScale;
                
                    var healthBarTransform = healthBar.transform;
                    var healthBarTransformLocalScale = healthBarTransform.localScale;
                    healthBarTransformLocalScale.x *= -1;
                    healthBarTransform.localScale = healthBarTransformLocalScale;
                
                    _lookingLeft = true;
                }
            }

            if (_lastFireTime + fireRate < Time.time && playerIsInAttackRange)
            {
                var createdBullet = GameObject.Instantiate(bullet,transform.position,quaternion.identity).GetComponent<EmrenemyBullet>();
                createdBullet.SetupBullet(bulletSpeed,bulletDamage,_targetToChase.transform);
                _animator.SetTrigger("Shoot");
                _lastFireTime = Time.time;
            }
        }

        public void SetTarget(Transform target)
        {
            _targetToChase = target;
        }

        public void IncreaseChaseMeter(int amount)
        {
            _chaseMeter += amount;
        }

        public void SetSpeed(float speed)
        {
            _navMeshAgent.speed = speed;
        }
    
        public void TakeDamage(float amount)
        {
            if (!_isAlive) return;
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                _animator.SetTrigger("Death");
                _isAlive = false;
                _navMeshAgent.SetDestination(transform.position);
                healthBar.InformHealthBar(_currentHealth,maxHealth);
                StartCoroutine(SelfDestroy(deathAnimationTime));
            }
            else
            {
                healthBar.InformHealthBar(_currentHealth,maxHealth);
            }
        }

        IEnumerator SelfDestroy(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            Destroy(this.gameObject);
        }
    }
}
