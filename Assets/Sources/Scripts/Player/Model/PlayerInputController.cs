using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(UniversalInputSystem))]
public class PlayerInputController : MonoBehaviour
{
    private IMovable _movable;
    private ICanJump _jumper;
    private IInputSystem _input;

    private void Awake()
    {
        _input = GetComponent<IInputSystem>();

        PlayerMovement movement = GetComponent<PlayerMovement>();
        _movable = movement;
        _jumper = movement;
    }

    private void OnEnable()
    {
        _input.Moving += OnMoving;
        _input.Jumping += OnJumping;
    }

    private void OnDisable()
    {
        _input.Moving -= OnMoving;
        _input.Jumping -= OnJumping;
    }

    private void OnJumping()
    {
        _jumper.Jump();
    }

    private void OnMoving(float direction)
    {
        _movable.Move(direction);
    }
}
