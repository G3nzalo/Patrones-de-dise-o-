using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    [SerializeField] private ShipMediator _ship;
    [SerializeField] bool _useJoystick;
    [SerializeField] Joystick _joystick;
    [SerializeField] JoyButton _joyBtn;

    [SerializeField] private float _maxDistance;
    [SerializeField] private bool _useIA;

    private void Awake()
    {
        _ship.Configure(GetInputAdapter() , GetCheckLimitsStrategy());
    }

    private InputAdapter GetInputAdapter()
    {
        if (_useIA) return new AIInputAdapter(_ship);

        if(_useJoystick)  return new InputJoystick(_joystick , _joyBtn);

        Destroy(_joystick.gameObject);
        Destroy(_joyBtn.gameObject);

        return new InputDesktop();

    }

    private ICheckLimits GetCheckLimitsStrategy()
    {
        if (_useIA) return new InitialPositionCheckLimits(transform, _maxDistance);
        return new ViewportCheckLimits(Camera.main, _ship.transform);

    }

}
