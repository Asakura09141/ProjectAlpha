using System;

public interface IInputSystem
{
    event Action<float> Moving;
    event Action Jumping;
}
