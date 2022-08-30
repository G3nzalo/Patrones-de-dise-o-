using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] bool _useJoystick;
    [SerializeField] Joystick _joystick;

    private void Awake()
    {
        _ship.SetConfigureInput(GetInput());
    }

    private InputAdapter GetInput()
    {
        if(_useJoystick)  return new InputJoystick(_joystick); 

        else return new InputDesktop();

    }

}
