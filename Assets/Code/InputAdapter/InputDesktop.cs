using UnityEngine;

namespace Code.Inputs
{
    public class InputDesktop : IInputAdapter
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
}
