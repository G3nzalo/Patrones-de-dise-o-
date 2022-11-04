namespace Code.Entities.Ships
{
    public interface IShip
    {
        string Id { get; }

        void OnDamageReceived(bool isDead);
    }
}