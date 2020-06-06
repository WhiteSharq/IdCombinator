using System;
using System.Linq;

namespace IdFunctorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Func<int, IdHolder<Component1>> generateC1 = i =>
                new IdHolder<Component1>(
                    random.Next(0, 6),
                    new Component1(i));

            var intHolders = Enumerable.Range(0, 2)
                .Select(generateC1)
                .ToList();
            
            Console.WriteLine("Components of type T1:");

            intHolders.ForEach(ih =>
            {
                Console.WriteLine($"Id {ih.Id}; Value:{ih.Object.D}");
            });

            Console.WriteLine();

            Func<int, IdHolder<Component2>> generateC2 = i =>
                new IdHolder<Component2>(
                    random.Next(0, 6),
                    new Component2(i.ToString()));

            var strHolders = Enumerable.Range(0, 5)
                .Select(generateC2)
                .ToList();

            Console.WriteLine("Components of type T2:");

            strHolders.ForEach(sh =>
            {
                Console.WriteLine($"Id {sh.Id}; Value:{sh.Object.S}");
            });

            var aggAndIds = intHolders
                .Select(c => c.TryCombineWithAny(strHolders))
                .Where(r => r.Success != null)
                .Select(t => new
                {
                    Id = t.Success.IdHolderT1.Id,
                    Aggregate = t.Success.Construct(Aggregate.Create) 
                })
                .ToList();

            Console.WriteLine();

            Console.WriteLine("Components matched by Id (aggregates):");

            aggAndIds.ForEach(anon =>
            {
                Console.WriteLine($"Id: {anon.Id}; Int {anon.Aggregate.C1.D}; String \"{anon.Aggregate.C2.S}\"");
            });
        }
    }
}
