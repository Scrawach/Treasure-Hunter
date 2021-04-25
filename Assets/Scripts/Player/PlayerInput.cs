using System;
using CameraLogic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerRotator))]
    public class PlayerInput : MonoBehaviour
    {
        private const KeyCode ForwardMove = KeyCode.W;
        private const KeyCode BackMove = KeyCode.S;
        private const KeyCode LeftMove = KeyCode.A;
        private const KeyCode RightMove = KeyCode.D;

        [SerializeField] 
        private ChestAnimator _animator;
        
        [SerializeField] 
        private float _commandSavedTime = 1f;

        [SerializeField] 
        private Inventory _inventory;
        
        private PlayerMovement _playerMovement;
        private PlayerRotator _playerRotator;
        private PlayerAttack _playerAttack;
        private Weapon _weapon;

        private float _elapsedTime;
        private bool _nextDirectionExist;
        private Vector3 _nextDirection;
        private bool _hasAttack;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerRotator = GetComponent<PlayerRotator>();
            _playerAttack = GetComponentInChildren<PlayerAttack>();
            _weapon = GetComponent<Weapon>();
        }

        private void OnEnable() => 
            _playerMovement.Done += OnMoveDone;

        private void OnDisable() => 
            _playerMovement.Done -= OnMoveDone;

        private void OnMoveDone()
        {
            if (_nextDirectionExist == false)
                return;
            
            if (_hasAttack)
                Attack();
            else
                Move(_nextDirection);
            
            _nextDirectionExist = false;
            _hasAttack = false;
        }

        private void Update()
        {
            ReadInput();

            if (NextCommandExist())
                UpdateTimer();
            else
                EraseSavedCommand();
        }

        private void ReadInput()
        {
            if (Input.GetKeyDown(ForwardMove))
                Move(Vector3.forward);
            else if (Input.GetKeyDown(BackMove))
                Move(Vector3.back);
            else if (Input.GetKeyDown(LeftMove))
                Move(Vector3.left);
            else if (Input.GetKeyDown(RightMove))
                Move(Vector3.right);
            else if (Input.GetKeyDown(KeyCode.Space))
                Attack();
            else if (Input.GetKeyDown(KeyCode.Q))
                _weapon.TryFire();
            else if (Input.GetKeyDown(KeyCode.I))
                ShowInventory();
        }

        private void ShowInventory()
        {
            _inventory.Toggle();
        }

        private bool NextCommandExist() => 
            _commandSavedTime >= _elapsedTime;

        private void EraseSavedCommand()
        {
            _nextDirectionExist = false;
            _hasAttack = false;
        }

        private void UpdateTimer() => 
            _elapsedTime += Time.deltaTime;

        private void Move(Vector3 direction)
        {
            _inventory.Hide();
            
            if (_playerMovement.IsMoving == false)
            {
                _playerMovement.Move(direction);
                _playerRotator.Rotate(direction);
            }
            
            _nextDirection = direction;
            
            _nextDirectionExist = true;
            _elapsedTime = 0;
        }

        private void Attack()
        {
            if (_playerAttack.CanAttack() && _playerMovement.IsMoving == false)
            {
                _playerAttack.Attack();
                _playerMovement.Move(_nextDirection, false);
            }

            _hasAttack = true;
            _elapsedTime = 0;
        }
    }
}