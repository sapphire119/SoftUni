public interface IDummy
{
    int Health { get; }

    int GiveExperience();
    bool IsDead();
    void TakeAttack(int attackPoints);
}