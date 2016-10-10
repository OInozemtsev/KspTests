using System.Collections.Generic;
using System.Linq;

namespace KspPairTest.Services
{
    /// <summary>
    /// Аггрегационный сервис, выполняющий поиск среди множества
    /// </summary>
    public class AggregationService
    {
        /// <summary>
        /// Получение пар чисел, для каждого элемента исходной коллекции
        /// </summary>
        /// <param name="source">Исходная коллекция</param>
        /// <param name="paramCount">Число слагаемых</param>
        /// <returns></returns>
        public Dictionary<int, List<List<int>>> GetSumAggregations(IEnumerable<int> source, int? paramCount = null)
        {
            Dictionary<int, List<List<int>>> dict = new Dictionary<int, List<List<int>>>();
            List<int> sourceList = source as List<int> ?? source.ToList();
            sourceList.ForEach(x =>
            {
                if (dict.ContainsKey(x)) return;
                //Полный набор комбинаций слагаемых
                var uncutCollection = GetRange(sourceList.Except(new[] { x }), x);
                //Набор слагаемых, являющийся уникальным и с указанным количеством элементов 
                List<List<int>> cutCollection = uncutCollection.Aggregate(new List<List<int>>(), (prev, next) =>
                {
                    if (paramCount.HasValue && next.Count != paramCount.Value)
                        return prev;
                    if (!prev.Any(z => z.All(next.Contains)))
                        prev.Add(next);
                    return prev;
                });
                dict.Add(x, cutCollection);
            });
            return dict;
        }

        /// <summary>
        /// Получение слагаемых для всей ветки выбранного элемента
        /// </summary>
        /// <param name="cutCollection">Коллекция элементов без выбранного слагаемого</param>
        /// <param name="equalsTo">Целевая сумма слагаемых</param>
        /// <returns></returns>
        private List<List<int>> GetRange(IEnumerable<int> cutCollection, int equalsTo)
        {
            List<int> cutCollectionList = cutCollection as List<int> ?? cutCollection.ToList();
            if (cutCollectionList.Count == 1)
            {
                return new List<List<int>> { cutCollectionList.Where(x => x == equalsTo).ToList() };
            }

            List<List<int>> result = new List<List<int>>();
            cutCollectionList.ForEach(x =>
            {
                if (equalsTo - x < 0) return;

                List<List<int>> resultSets = equalsTo - x == 0
                ? new List<List<int>> { new List<int>() }
                : GetRange(cutCollectionList.Except(new[] { x }), equalsTo - x);

                resultSets.ForEach(y => y.Insert(0, x));
                result.AddRange(resultSets);
            });
            return result;
        }
    }
}
