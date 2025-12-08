using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UniversalInputSystem : MonoBehaviour, IInputSystem
{
    private GameInput _gameInput;
    private Vector2 _currentMove;

    public event Action<float> Moving;
    public event Action Jumping;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Player.Move.performed += OnMovePerformed;
        _gameInput.Player.Move.canceled += OnMoveCanceled;
        _gameInput.Player.Jump.performed += OnJump;
    }

    private void FixedUpdate()
    {
        Moving?.Invoke(_currentMove.x);
    }

    private void OnEnable()
    {
        _gameInput.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    private void OnDestroy()
    {
        _gameInput.Player.Move.performed -= OnMovePerformed;
        _gameInput.Player.Move.canceled -= OnMoveCanceled;
        _gameInput.Player.Jump.performed -= OnJump;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _currentMove = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _currentMove = Vector2.zero;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jumping?.Invoke();
    }
}