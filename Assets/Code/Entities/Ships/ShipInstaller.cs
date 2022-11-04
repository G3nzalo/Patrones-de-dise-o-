using Code.Entities.Ships.Configurations;
using Code.Entities.Ships.Enemies;
using Code.Inputs;
using Code.Viewport;
using UnityEngine;
using Code.Entities.Ships.Common;

namespace Code.Entities.Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useIA;
        [SerializeField] bool _useJoystick;
        [SerializeField] Joystick _joystick;
        [SerializeField] JoyButton _joyBtn;

        [SerializeField] private ShipSpawnConfiguration _shipSpawnConfiguration;
        [SerializeField] private FactoryShipConfiguration _shipConfiguration;

        private ShipBuilder _shipBuilder;
        private ShipMediator _ship;

        private void Awake()
        {
           var shipFactory =  new ShipFactory(Instantiate(_shipConfiguration));

            _shipBuilder = shipFactory
                .Create(_shipSpawnConfiguration.ShipId.Value)
                .WithConfiguration(_shipSpawnConfiguration)
                .WithTeam(TEAMS.ALLY);

            SetInputAdapter(_shipBuilder);
            SetCheckLimitsStrategy(_shipBuilder);
        }

        public void CreateMenu()
        {
            _ship =  _shipBuilder.Build();
        }

        public void QuitGame()
        {
            if (_ship.gameObject.Equals(null)) return;
            Destroy(_ship.gameObject);
        }



        private void SetInputAdapter(ShipBuilder shipBuilder)
        {
            if (_useIA)
            {
                shipBuilder.WithInputMode(ShipBuilder.InputMode.Ai);
                return;
            }

            if (_useJoystick)
            {
                shipBuilder
                    .WithInputMode(ShipBuilder.InputMode.Joystick)
                    .WithJoystick(_joystick, _joyBtn);
                return;

            }
            shipBuilder.WithInputMode(ShipBuilder.InputMode.Unity);

            Destroy(_joystick.gameObject);
            Destroy(_joyBtn.gameObject);
        }

        private void SetCheckLimitsStrategy(ShipBuilder shipBuilder)
        {
            if (_useIA)
            {
                shipBuilder.WithCheckLimitsType(ShipBuilder.CheckLimitsTypes.InitialPosition);
                return;

            }
            shipBuilder.WithCheckLimitsType(ShipBuilder.CheckLimitsTypes.Viewport);

        }

    }
}