using System.Collections.Generic;
using System.Threading;

namespace KspThreadSafeQueueTest
{
    public class ThreadSafeQueue<T>
    {
        /// <summary>
        /// Стандартная очередь
        /// </summary>
        private readonly Queue<T> _queue = new Queue<T>();

        /// <summary>
        /// Сигнал ожижающему
        /// </summary>
        private readonly AutoResetEvent _resetEventHandler = new AutoResetEvent(false);

        /// <summary>
        /// Добавление в очередь
        /// </summary>
        /// <param name="pushed">Добавляемы элемент</param>
        public void Push(T pushed)
        {
            _queue.Enqueue(pushed);
            _resetEventHandler.Set();
        }

        /// <summary>
        /// Извлечение из очереди
        /// </summary>
        /// <returns>Извлекаемый элемент</returns>
        public T Pop()
        {
            _resetEventHandler.WaitOne();
            return _queue.Dequeue();
        }
    }
}
