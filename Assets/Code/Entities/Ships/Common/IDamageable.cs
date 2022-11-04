namespace Code.Entities.Ships.Common
{
    public interface IDamageable
    {
        public void ApplyDamage(int amount);
        TEAMS Team { get;  set; }
    }
}