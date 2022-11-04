using System;
using Code.Entities.Ships.Enemies;
using Code.Inputs;
using Code.Viewport;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Code.Entities.Ships.Common
{
    public class ShipBuilder
    {
        public enum InputMode
        {
            Unity,
            Joystick,
            Ai
        }

        public enum CheckLimitsTypes
        {
            InitialPosition,
            Viewport,
        }

        private ShipMediator _prefab;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private IInputAdapter _input;
        private ICheckLimits _checkLimits;
        private ShipSpawnConfiguration _shipConfiguration;
        private InputMode _inputMode;
        private CheckLimitsTypes _checklimitsTyoe;
        private Joystick _joystick;
        private JoyButton _joyButton;
        private TEAMS _team;

        public ShipBuilder FromPrefab (ShipMediator prefb)
        {
            _prefab = prefb;
            return this;
        }

        public ShipBuilder WithTeam(TEAMS team)
        {
            _team = team;
            return this;
        }

        public ShipBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public ShipBuilder WithRotation (Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public ShipBuilder WithInput(IInputAdapter input)
        {
            _input = input;
            return this;
        }

        public ShipBuilder WithCheckLimits(ICheckLimits type)
        {
            _checkLimits = type;
            return this;
        }

        public ShipBuilder WithConfiguration(ShipSpawnConfiguration configuration)
        {
            _shipConfiguration = configuration;
            return this;
        }

        public ShipBuilder WithInputMode(InputMode input)
        {
            _inputMode = input;
            return this;
        }

        public ShipBuilder WithCheckLimitsType(CheckLimitsTypes checklimitstype)
        {
            _checklimitsTyoe = checklimitstype;
            return this;
        }

        public ShipBuilder WithJoystick(Joystick joystick , JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton;
            return this;
        }

        private ICheckLimits GetCheckLimits(ShipMediator ship)
        {
            if (_checkLimits != null)
            {
                return _checkLimits;
            }

            switch (_checklimitsTyoe)
            {
                case CheckLimitsTypes.InitialPosition:
                        return new InitialPositionCheckLimits(ship.transform, 10);
                case CheckLimitsTypes.Viewport:
                        return new ViewportCheckLimits(Camera.main, ship.transform);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IInputAdapter GetInput(ShipMediator shipMediator)
        {
            if(_input != null)
            {
                return _input;
            }

            switch (_inputMode)
            {
                case InputMode.Unity:
                    return new InputDesktop();
                case InputMode.Joystick:
                    Assert.IsNotNull(_joystick);
                    Assert.IsNotNull(_joyButton);
                    return new InputJoystick(_joystick , _joyButton);
                case InputMode.Ai:
                    return new AIInputAdapter(shipMediator);
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        public ShipMediator Build()
        {
            var ship = Object.Instantiate(_prefab, _position, _rotation);

            var shipConfiguration = new ShipConfiguration(
                GetInput(ship),
                GetCheckLimits(ship),
                _shipConfiguration.Speed,
                _shipConfiguration.Health,
                _shipConfiguration.FireRate,
                _shipConfiguration.DefaultProjectileId,
                _team,
                _shipConfiguration.Score);

            ship.Configure(shipConfiguration);

            return ship;
        }
    }
}