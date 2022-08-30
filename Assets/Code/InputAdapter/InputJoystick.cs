using UnityEngine;

class InputJoystick : InputAdapter
{

    Joystick _joystick;

    public InputJoystick (Joystick joystick)
    {
        _joystick = joystick;
    }
    public Vector2 GetDirection()
    {
        return new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }
    
}