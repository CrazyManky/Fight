using UnityEngine;

namespace _Project.Scripts.Skills
{
    public struct Buffs
    {
        public static int Speed;
        public static int LevelSpeed;
        public static int Damage;
        public static int LevelDamage;

        public static void Load()
        {
            Speed = PlayerPrefs.GetInt("Speed", 0);
            LevelSpeed = PlayerPrefs.GetInt("LevelSpeed", 0);
            Damage = PlayerPrefs.GetInt("Damage", 0);
            LevelDamage = PlayerPrefs.GetInt("LevelDamage", 0);
        }

        public static void UpdateSpeed()
        {
            Speed += 1;
            PlayerPrefs.SetInt("Speed", Speed);
            LevelSpeed++;
            PlayerPrefs.SetInt("LevelSpeed", LevelSpeed);
        }

        public static void UpdateDamage()
        {
            Damage += 10;
            PlayerPrefs.SetInt("Damage", Speed);
            LevelDamage++;
            PlayerPrefs.SetInt("LevelDamage", LevelDamage);
        }
    }
}