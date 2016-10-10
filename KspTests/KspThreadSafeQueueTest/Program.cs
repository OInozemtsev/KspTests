using System;

namespace KspThreadSafeQueueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Решенеи заданяи №1
            ThreadSafeQueue<int> queue = new ThreadSafeQueue<int>();
            Queuer<int> dequeuer = new Dequeuer(queue);
            dequeuer.Queue();
            Queuer<int> enqueuer = new Enqueuer(queue);
            enqueuer.Queue();
            Console.ReadKey();
        }
    }
}
