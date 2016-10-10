using System;
using System.Threading.Tasks;

namespace KspThreadSafeQueueTest
{
    /// <summary>
    /// Класс, извлекающий из очереди
    /// </summary>
    public class Dequeuer : Queuer<int>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="queue">Потокобезопасная чередь</param>
        public Dequeuer(ThreadSafeQueue<int> queue)
            : base(queue)
        {

        }

        #endregion//Конструктор

        #region Открытые методы

        /// <summary>
        /// Извлечение из очереди 
        /// </summary>
        public override void Queue()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine($"Извлечено: {_queue.Pop()}");
                }
            });
        }

        #endregion//Открытые методы
    }
}
