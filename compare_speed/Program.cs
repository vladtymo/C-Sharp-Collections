using System.Collections;
using System.Diagnostics;
using static System.Console;

namespace compare_speed
{
    /// <summary>
    /// Допоміжний клас для профілювання блоку коду
    /// виконує вимірювання часу виконання
    /// і обрахунок кількості збірок сміття
    /// </summary>
    internal sealed class OperationTimer : IDisposable
    {
        long _startTime;
        string _text;
        int _collectionCount;
        public OperationTimer(string text)
        {
            PrepareForOperation();
            _text = text;
            // зберігається к-сть збірок сміття на даний момент
            _collectionCount = GC.CollectionCount(0);
            // зберігається поточний час
            _startTime = Stopwatch.GetTimestamp();
        }
        /// <summary>
        /// Викликається при знищенні об'єкта
        /// Відображає:
        /// значення часу, пройденого з моменту
        /// створення об'єкту до моменту його видалення,
        /// кількість виконаних збірок сміття,
        /// виконаних за цей час
        /// </summary>
        public void Dispose()
        {
            WriteLine($"{_text}\t" +
                $"{(Stopwatch.GetTimestamp() - _startTime) / (double)Stopwatch.Frequency:0.00} " +
                $"seconds (garbage collections {GC.CollectionCount(0) - _collectionCount})");
        }
        /// <summary>
        /// Метод видалення всіх невикористаних об'єктів
        /// Це потрібно для "чистоти експерименту"
        /// тобто, щоб збірка сміття проходила лише для об'єктів,
        /// які будуть створюватися в профілюючому блоці коду
        ///</summary>
        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    class Program
    {
        /// <summary>
        /// метод тестування продуктивності
        /// generic та non-generic колекції
        /// </summary>
        private static void ValueTypePerfTest()
        {
            const int COUNT = 100_000_000;
           
            using (new OperationTimer("ArrayList")) // start
            {
                // використання non-generic колекції
                ArrayList array = new ArrayList();
                for (int n = 0; n < COUNT; n++)
                {
                    array.Add(n);           // boxing
                    int x = (int)array[n];  // unboxing
                }
                array = null; // для гаратнованого виконання збірки сміття

            } // Dispose invokation...              // stop

            using (new OperationTimer("List"))
            {
                // використання generic колекції
                List<int> list = new List<int>();
                for (int n = 0; n < COUNT; n++)
                {
                    list.Add(n);
                    int x = list[n];
                }
                list = null; // для гаратнованого виконання збірки сміття
            }
        }
        static void Main(string[] args)
        {
            ValueTypePerfTest();
        }
    }
}