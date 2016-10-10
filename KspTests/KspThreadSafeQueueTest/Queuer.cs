namespace KspThreadSafeQueueTest
{
    public abstract class Queuer<T>
    {
        #region Поля

        /// <summary>
        /// Очередь
        /// </summary>
        protected readonly ThreadSafeQueue<T> _queue;

        #endregion//Поля

        #region Конструктор

        protected Queuer(ThreadSafeQueue<T> queue)
        {
            _queue = queue;
        }

        #endregion//Конструктор

        #region Открытые методы

        /// <summary>
        /// Работа с очередью
        /// </summary>
        public abstract void Queue();

        #endregion//Открытые методы
    }
}
