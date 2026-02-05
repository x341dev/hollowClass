using classes01.Enums;
using itbXLib.Colors;

namespace classes01.Model;



public class Weapon
{
    public string Name { get; set; }
    public int BaseDamage { get; set; }
    public WeaponType Type { get; }

    public Weapon(string name, int baseDamage, WeaponType type)
    {
        Name = name;
        Type = type;
        BaseDamage = CalculateBaseDamage(baseDamage);
    }
    private int CalculateBaseDamage(int baseDamage) => baseDamage * (int)Type;

    public void GetInfo()
    {
        Console.WriteLine($"{Colors.RgbToAnsi("#ffff00")}Weapon Name: {Colors.RgbToAnsi("#ffffff")}{Name}\n{Colors.RgbToAnsi("#ffff00")}Base Damage: {Colors.RgbToAnsi("#ffffff")}{BaseDamage}\n{Colors.RgbToAnsi("#ffff00")}Type: {Colors.RgbToAnsi("#ffffff")}{Type}");
    }
}
