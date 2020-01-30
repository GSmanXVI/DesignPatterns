using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    class Enemy
    {
        private static int count = 0;

        public Enemy()
        {
            Name = (++count).ToString();
        }

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    interface IObjectPool<T>
    {
        T Get();
        void Return(T obj);
    }

    class EnemyPool : IObjectPool<Enemy>
    {
        private Queue<Enemy> enemies = new Queue<Enemy>();
        private Random random = new Random();
        private readonly int maxEnemies = 10;

        public EnemyPool()
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                enemies.Enqueue(new Enemy());
            }
        }

        public Enemy Get()
        {
            if (enemies.Count > 0)
            {
                Enemy enemy = enemies.Dequeue();
                enemy.X = random.Next(0, 80);
                enemy.Y = random.Next(0, 20);
                return enemy;
            }
            else
            {
                return null;
            }
        }

        public void Return(Enemy obj)
        {
            enemies.Enqueue(obj);
        }
    }

    class Program
    {
        static void DrawEnemy(Enemy enemy)
        {
            Console.SetCursorPosition(enemy.X, enemy.Y);
            Console.Write(enemy.Name);
        }

        static void Main(string[] args)
        {
            
            var enemyPool = new EnemyPool();
            var enemyList = new List<Enemy>();
            var random = new Random();

            while (true)
            {
                foreach (var enemy in enemyList)
                {
                    enemyPool.Return(enemy);
                }
                Console.Clear();

                for (int i = 0; i < random.Next(3, 10); i++)
                {
                    enemyList.Add(enemyPool.Get());
                    DrawEnemy(enemyList[i]);
                }

                Console.ReadKey();
            }
        }
    }
}
