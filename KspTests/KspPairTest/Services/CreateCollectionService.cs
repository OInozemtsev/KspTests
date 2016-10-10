using System;
using System.Collections.Generic;

namespace KspPairTest.Services
{
    public class CreateCollectionService
    {
        private Random _rnd = new Random(DateTime.Now.Millisecond);

        public IEnumerable<int> GetRandomCollection()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < _rnd.Next(20, 50); i++)
            {
                result.Add(_rnd.Next(1, 100));
            }
            return result;
            //return Enumerable.Range(1, 10);
        }
    }
}
