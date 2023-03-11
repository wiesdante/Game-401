using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;
    private NavMeshAgent _navMeshAgent;

    private Transform _targetToChase;
    private int _chaseMeter;

    private Vector2 _moveDirection;

    public float maxHealth;
    public HealthBar healthBar;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
        healthBar.InformHealthBar(_currentHealth,maxHealth);
        
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        if (_chaseMeter > 0)
        {
            _navMeshAgent.SetDestination(_targetToChase.transform.position);
        }
    }

    public void SetTarget(Transform target)
    {
        _targetToChase = target;
    }
    
    public void StartChase()
    {
        _chaseMeter++;
    }

    public void StopChase()
    {
        _chaseMeter--;
    }
    
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            SelfDestroy();
        }
        else
        {
            healthBar.InformHealthBar(_currentHealth,maxHealth);
        }
    }
}
