using System;
using System.Collections.Generic;
using System.Linq;

namespace IdFunctorTest
{
    public class IdHolder
    {
        public IdHolder(int id, object @object)
        {
            Id = id;
            Objects[0] = @object;
        }

        public IdHolder(int id, object[] objects)
        {
            Id = id;
            Objects = objects;
        }

        public int Id { get; }
        private object[] Objects { get; } = new object[1];

        public IdHolder CombineWith(IdHolder idHolder)
        {
            if (idHolder.Id != Id)
            {
                return this;
            }

            return UpdateObjects(idHolder);
        }

        public IdHolder CombineWithFirstMatching(
            IEnumerable<IdHolder> idHolders)
        {
            var idHolder = idHolders
                .FirstOrDefault(h => h.Id == Id);

            if (idHolder == null)
            {
                return this;
            }

            return CombineWith(idHolder);
        }

        public (string Error, R) TryConstructWith<T1, T2, R>(Func<T1, T2, R> func)
            where T1 : class
            where T2 : class
        {
            var t1 = Objects.FirstOrDefault(o => o is T1);
            if (t1 == null)
            {
                return ("No T1!", default);
            }

            var t2 = Objects.FirstOrDefault(o => o is T2);
            if (t2 == null)
            {
                return ("No T2!", default);
            }

            return (string.Empty, func((T1)t1, (T2)t2));
        }

        private IdHolder UpdateObjects(IdHolder idHolder)
        {
            var newObs = new object[Objects.Length + idHolder.Objects.Length];

            Objects.CopyTo(newObs, 0);

            idHolder.Objects.CopyTo(newObs, Objects.Length);

            return new IdHolder(Id, newObs);
        }
    }
}
