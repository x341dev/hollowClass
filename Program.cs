using System.IO.Pipes;
using classes01.Model;
using classes01.Model.Entities;
using itbXLib.Inputs;
using itbXLib.ConsoleUtils;
using itbXLib.Colors;

namespace classes01;

public class Program
{
    private static List<Weapon> Weapons = new List<Weapon>();
    
    public static void Main()
    {
        int menuSelection;
        
        // Temporary DEV player
        Player player = new Player("Hero", 100);
        // Temporary DEV weapons
        Weapons.Add(new Weapon("Sword", 20, Enums.WeaponType.Normal));
        player.EquipWeapon(Weapons[0]);
        
        do
        {
            ShowMenu();
            menuSelection = IntInput.AskForNumber("Select option: ");
            switch (menuSelection)
            {
                case 1:
                    CreateFight(player, CreateNewRandomEnemy());
                    break;
                case 2:
                    foreach (Weapon weapon in Weapons)
                    {
                        weapon.GetInfo();
                    }
                    break;
                default:
                    ConsoleHelper.ColorWriteLine("Selection not valid", ConsoleColor.Red);
                    break;
            }
        } while (menuSelection != 0);
    }

    private static Enemy CreateNewRandomEnemy()
    {
        Random random = new Random();
        string[] names = {"Goblin", "Orc", "Troll"};
        string name = names[random.Next(names.Length)];
        int hp = random.Next(50, 150);
        return new Enemy(name, hp, random.Next(5, 20), random.Next(10, 50));
    }
    
    private static void CreateFight(Player player, Enemy enemy)
    {
        ConsoleHelper.ColorWriteLine($"Fight between {player.Name} and {enemy.Name} begins!", ConsoleColor.Yellow);
        while (player.Hp > 0 && enemy.Hp > 0)
        {
            // Player attacks
            player.DamageEnemy(player.CurrentWeapon, enemy);
            float damageDealt = player.CurrentWeapon.BaseDamage * player.DmgMultiplier;
            ConsoleHelper.ColorWrite($"{player.Name} ", ConsoleColor.Cyan);
            ConsoleHelper.ColorWrite("attacks ", ConsoleColor.White);
            ConsoleHelper.ColorWrite($"{enemy.Name} ", ConsoleColor.Red);
            ConsoleHelper.ColorWrite("for ", ConsoleColor.White);
            ConsoleHelper.ColorWrite($"{damageDealt} ", ConsoleColor.Green);
            ConsoleHelper.ColorWrite("damage. ", ConsoleColor.White);
            ConsoleHelper.ColorWrite($"{enemy.Name} ", ConsoleColor.Red);
            ConsoleHelper.ColorWriteLine($"has {(int)enemy.Hp} HP left.", ConsoleColor.Magenta);
            
            if (enemy.IsDefeated())
            {
                ConsoleHelper.ColorWriteLine($"{player.Name} wins the fight!", ConsoleColor.Green);
                break;
            }
            
            // Enemy attacks
            player.TakeDamage(enemy.Damage, enemy);
            ConsoleHelper.ColorWrite($"{enemy.Name} ", ConsoleColor.Red);
            ConsoleHelper.ColorWrite("attacks ", ConsoleColor.White);
            ConsoleHelper.ColorWrite($"{player.Name} ", ConsoleColor.Cyan);
            ConsoleHelper.ColorWrite("for ", ConsoleColor.White);
            ConsoleHelper.ColorWrite($"{enemy.Damage} ", ConsoleColor.Yellow);
            ConsoleHelper.ColorWrite("damage. ", ConsoleColor.White);
            ConsoleHelper.ColorWrite($"{player.Name} ", ConsoleColor.Cyan);
            ConsoleHelper.ColorWriteLine($"has {(int)player.Hp} HP left.", ConsoleColor.Magenta);
            
            if (player.IsDefeated())
            {
                ConsoleHelper.ColorWriteLine($"{enemy.Name} wins the fight!", ConsoleColor.Red);
                break;
            }
        }
    }
    

    private static void ShowMenu()
    {
        ConsoleHelper.ColorWriteLine("1. Fight", ConsoleColor.Red);
        ConsoleHelper.ColorWriteLine("2. Show weapons", ConsoleColor.DarkBlue);
        Console.WriteLine("0. Exit");
    }
    
}
