using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Jumper))]
public class PlayerMovement : MonoBehaviour
{
    private IMovable _movable;
    private ICanJump _jumper;
    private IInputSystem _inputSystem;

    private void Awake()
    {
        _movable = GetComponent<Movement>();
        _jumper = GetComponent<Jumper>();
    }

    private void OnDisable()
    {
        _inputSystem.Moving -= OnMoving;
        _inputSystem.Jumping -= OnJumping;
    }

    public void SetInput(IInputSystem input)
    {
        _inputSystem = input ?? throw new System.ArgumentNullException(nameof(input));

        _inputSystem.Moving += OnMoving;
        _inputSystem.Jumping += OnJumping;
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