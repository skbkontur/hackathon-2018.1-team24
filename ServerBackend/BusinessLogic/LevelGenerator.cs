﻿using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Units;
using GameCoreLibrary;

namespace BusinessLogic
{
    public class LevelGenerator
    {
        public GameLevel[] GetStaticLevels()
        {
            //TODO много уровней
            return new[] {GenerateLevel((int) LevelFloor.Entrance)};
        }

        public GameLevel[] GenerateLevels()
        {
            //TODO много уровней
            return new[] {GenerateLevel((int) LevelFloor.Entrance)};
        }

        public GameLevel GenerateLevel(int levelNumber)
        {
            return new GameLevel(StaticLevels.levels[levelNumber]);
        }
    }

    public static class StaticLevels
    {
        public static Dictionary<int, Level> levels = new Dictionary<int, Level>
        {
            {
                1, new Level
                {
                    GameObjects = GetLevel1()
                }
            }
        };

        private static IGameObject[] GetLevel1()
        {
            return new IGameObject[]
            {
                new StaticObject
                {
                    ObjectType = ObjectType.Platform,
                    HitPoints = 20,
                    HealthPoints = 30,
                    IsAlive = true,
                    Pos = new Pos(20, 20)
                },
                UnitsFactory.NewGuard(),
                UnitsFactory.NewClawn(),
                new StaticObject
                {
                    ObjectType = ObjectType.Platform,
                    HitPoints = 20,
                    HealthPoints = 30,
                    IsAlive = true,
                    Pos = new Pos(200, 20)
                },
            }.Concat(UnitsFactory.NewBugsLevel1()).ToArray();
        }
    }
}