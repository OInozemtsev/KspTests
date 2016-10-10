using System;
using KspPairTest.Services;

namespace KspPairTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Решение задания №2
            CreateCollectionService creator = new CreateCollectionService();
            AggregationService aggregator = new AggregationService();
            int paramCount = 2;
            var sumDictionary = aggregator.GetSumAggregations(creator.GetRandomCollection(), paramCount);
            foreach (var pair in sumDictionary)
            {
                string str = string.Empty;
                pair.Value.ForEach(x =>
                {
                    for (int i = 0; i < x.Count; i++)
                    {
                        str += i % paramCount == 0
                            ? $" ({x[i]} "
                            : $"{x[i]} ";
                        if (i == x.Count - 1)
                            str += ")";
                    }
                    str = str.Replace(" )", ")");
                    ;
                });
                Console.WriteLine($"Слагаемые для {pair.Key:###}: {str}");
            }
            Console.ReadKey();
        }
    }
}
