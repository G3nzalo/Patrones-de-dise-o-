using UnityEngine;

public class InputDesktop : InputAdapter
{
    public Vector2 GetDirection()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public bool IsFireActionPressed()
    {
        return Input.GetButton("Fire");
    }
}
