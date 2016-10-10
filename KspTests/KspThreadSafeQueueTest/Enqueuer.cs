using System;
using System.Threading;
using System.Threading.Tasks;

namespace KspThreadSafeQueueTest
{
    /// <summary>
    /// Класс, добавляющий в очередь
    /// </summary>
    public class Enqueuer : Queuer<int>
    {
        /// <summary>
        /// Генератор чисел для добавления в очередь
        /// </summary>
        private readonly Random _rnd = new Random(DateTime.Now.Millisecond);

        #region Конструктор

        public Enqueuer(ThreadSafeQueue<int> queue)
            : base(queue)
        {

        }

        #endregion//Конструктор

        #region Открытые методы

        /// <summary>
        /// Добавление в очередь
        /// </summary>
        public override void Queue()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(_rnd.Next(1, 7)));
                    int count = _rnd.Next(0, 100);
                    _queue.Push(count);
                    Console.WriteLine($"Добавлено: {count}");
                }
            });
        }

        #endregion//Открытые методы
        
    }
}
