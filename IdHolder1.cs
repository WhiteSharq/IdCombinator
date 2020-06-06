using System.Collections.Generic;
using System.Linq;

namespace IdFunctorTest
{
    public class IdHolder<T1>
        where T1 : class
    {
        public IdHolder(int id, T1 @object)
        {
            Id = id;
            Object = @object;
        }

        public int Id { get; }
        public T1 Object { get; }

        public (string Failure, IdHolder<T1, T2>)
            TryCombine<T2>(IdHolder<T2> idHolder2)
            where T2 : class
        {
            return idHolder2.Id != Id ?
                ("No matching T2", default) :
                (string.Empty, new IdHolder<T1, T2>(this, idHolder2));
        }

        public (string Failure, IdHolder<T1, T2> Success)
            TryCombineWithAny<T2>(
            IEnumerable<IdHolder<T2>> idHolders)
            where T2 : class
        {
            var idHolder2 = idHolders
                .FirstOrDefault(h => h.Id == Id);

            return idHolder2 == null ?
                ("No matching T2", default) :
                TryCombine(idHolder2);
        }
    }
}
