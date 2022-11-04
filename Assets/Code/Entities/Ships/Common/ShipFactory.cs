using Code.Entities.Ships.Configurations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Entities.Ships.Common
{
    public class ShipFactory
    {
        private FactoryShipConfiguration _factoryShipConfiguration;


        public ShipFactory(FactoryShipConfiguration factoryShipConfiguration)
        {
            _factoryShipConfiguration = factoryShipConfiguration;
        }

        public ShipBuilder Create(string id)
        {
            var prefab = _factoryShipConfiguration.GetShipId(id);

            return new ShipBuilder()
                .FromPrefab(prefab);
        }
    }

}