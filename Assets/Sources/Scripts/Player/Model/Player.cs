using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(UniversalInputSystem))]
[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    private IMovable _movable;
    private ICanJump _jumper;
    private IInputSystem _input;

    private void Awake()
    {
        _input = GetComponent<IInputSystem>();

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        Movement movement = GetComponent<Movement>();
        _movable = movement;
        _jumper = playerMovement;
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
