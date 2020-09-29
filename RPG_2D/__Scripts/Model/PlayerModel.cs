

public class PlayerModel
{
    public string Name { get; set; }  // Имя игрока
    public int MaxHealth { get; set; } = 100; // Максимальное здоровье
    public int MaxExperience { get; set; } = 200; // Максимальный уровен опыта
    public int Level { get; set; } = 1; // уровень
    public int Strenght { get; set; } = 1; // Сила
    public int Dexterity { get; set; } = 1; // Ловкость
    public float Speed { get; set; } = 5f; // Скорость игрока
    public float AttackDuration { get; set; } = 0.25f; // Продолжительность атаки в секундах
    public float AttackDelay { get; set; } = 0.5f; // Задержка между атаками
}
