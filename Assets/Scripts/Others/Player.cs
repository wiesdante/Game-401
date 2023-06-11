using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Movement related
    public float moveSpeed = 1f;
    public float collisionOffset = 0.005f;
    public ContactFilter2D movementFilter;
    private Vector2 _movementDirection;
    
    // Health related
    public HealthBar healthBar;
    public float maxHealth;
    private float _currentHealth;
    
    // Rigidbody related
    private Rigidbody2D _rigidbody2D;
    private readonly List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();
    
    // Weapon related
    private WeaponParent _currentWeaponParent;
    private Weapon _currentWeapon;
    public Weapon[] weapons;


    // Input related
    [SerializeField]
    private InputActionReference pointerPosition, fire;
    private Vector2 _mousePositionOnWorld; // On World Coordinates
    private Vector2 _mousePositionOnScreen; // On Screen Coordinates
    private Interactable _currentInteractable;

    // Animation related
    private Animator _animator;
    private string _currentDirection;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int LookRight = Animator.StringToHash("LookRight");
    private static readonly int LookLeft = Animator.StringToHash("LookLeft");
    private static readonly int LookUp = Animator.StringToHash("LookUp");
    private static readonly int LookDown = Animator.StringToHash("LookDown");

    private void Start()
    {
        _currentHealth = maxHealth;
        healthBar.InformHealthBar(_currentHealth,maxHealth);
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentWeaponParent = GetComponentInChildren<WeaponParent>();
        _currentWeapon = GetComponentInChildren<Weapon>();
        _animator = GetComponent<Animator>();
    }
    

    private void FixedUpdate()
    {
        #region Movement
        
        
        if (_movementDirection != Vector2.zero)
        {
            var success = TryToMove(_movementDirection);
            if (!success)
            {
                success = TryToMove(new Vector2(_movementDirection.x, 0));
                if (!success)
                {
                    TryToMove(new Vector2(0, _movementDirection.y));
                }
            }
        }

        #endregion
        
        #region Informing Weapon Parent

        _mousePositionOnWorld = GetMousePositionOnWorld();
        _currentWeaponParent.mousePosition = _mousePositionOnWorld;

        #endregion

        #region Informing Animator
        
        // Informing about "isMoving"
        if (Mathf.Abs(_movementDirection.x) + Mathf.Abs(_movementDirection.y) > 0)
        {
            _animator.SetBool(IsMoving,true);
        } 
        else
        {
            _animator.SetBool(IsMoving,false);
        }

        // Informing about looking direction
        _mousePositionOnScreen = GetMousePositionOnScreen();
        if (Mathf.Abs(_mousePositionOnScreen.x - 0.5f) > Mathf.Abs(_mousePositionOnScreen.y - 0.5f)) 
        {
            if (_mousePositionOnScreen.x > 0.5f && _currentDirection != "RIGHT")
            {
                _currentDirection = "RIGHT";
                _animator.SetTrigger(LookRight);
            }
            else if (_mousePositionOnScreen.x < 0.5f && _currentDirection != "LEFT")
            {
                _currentDirection = "LEFT";
                _animator.SetTrigger(LookLeft);
            }
        }
        else
        {
            if (_mousePositionOnScreen.y > 0.5f && _currentDirection != "UP")
            {
                _currentDirection = "UP";
                _animator.SetTrigger(LookUp);
            }
            else if (_mousePositionOnScreen.y < 0.5f && _currentDirection != "DOWN")
            {
                _currentDirection = "DOWN";
                _animator.SetTrigger(LookDown);
            }
        }

        #endregion
    }

    private void Update()
    {
        if (fire.action.WasPressedThisFrame())
        {
            _currentWeapon.StartFire();
        }
        else if (fire.action.WasReleasedThisFrame())
        {
            _currentWeapon.StopFire();
        }
        
        if (fire.action.IsPressed())
        {
            if (Time.timeScale == 0) return;
            _currentWeapon.Fire();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentWeapon.Reload();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            UIManager.Instance.ToggleMap();
        }
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Application.Quit();
        }
        else
        {
            healthBar.InformHealthBar(_currentHealth,maxHealth);
        }
    }

    private bool TryToMove(Vector2 direction)
    {
        var count = _rigidbody2D.Cast(
            direction,
            movementFilter,
            _castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count != 0) return false;
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (moveSpeed * Time.fixedDeltaTime));
        return true;

    }

    public void OnMove(InputValue movementValue)
    {
        _movementDirection = movementValue.Get<Vector2>();
    }
    

    public void OnInteract()
    {
        if (_currentInteractable == null) return;
        _currentInteractable.Interact();
    }

    public void OnChangeWeapon1()
    {
        weapons[0].gameObject.SetActive(true);
        weapons[1].gameObject.SetActive(false);;
        weapons[2].gameObject.SetActive(false);
        _currentWeapon = weapons[0];
    }
    
    public void OnChangeWeapon2()
    {
        weapons[0].gameObject.SetActive(false);
        weapons[1].gameObject.SetActive(true);;
        weapons[2].gameObject.SetActive(false);
        _currentWeapon = weapons[1];
    }
    
    public void OnChangeWeapon3()
    {
        weapons[0].gameObject.SetActive(false);
        weapons[1].gameObject.SetActive(false);;
        weapons[2].gameObject.SetActive(true);
        _currentWeapon = weapons[2];
    }

    public void OnToggleQuestWindow()
    {
        if (Math.Abs(QuestManager.Instance.questListBox.alpha - 1) < 0.05f)
        {
            QuestManager.Instance.QuestListBoxToggle(false);
        }
        else if(QuestManager.Instance.GetCurrentQuestName() != "none")
        {
            QuestManager.Instance.QuestListBoxToggle(true);
        }
    }

    private Vector2 GetMousePositionOnWorld()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        if (Camera.main is null) return Vector2.zero;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    
    private Vector2 GetMousePositionOnScreen()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        if (Camera.main is null) return Vector2.zero;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToViewportPoint(mousePos);
    }
    
    public void SetCurrentInteractableGameObject(Interactable obj)
    {
        _currentInteractable = obj;
        
    }
    
}
