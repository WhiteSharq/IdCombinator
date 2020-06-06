using System;

namespace IdFunctorTest
{
    public class IdHolder<T1, T2>
        where T1 : class
        where T2 : class
    {
        public IdHolder(
            IdHolder<T1> idHolder,
            IdHolder<T2> idHolder2)
        {
            IdHolderT1 = idHolder;
            IdHolderT2 = idHolder2;
        }

        public IdHolder<T1> IdHolderT1 { get; }
        public IdHolder<T2> IdHolderT2 { get; }

        public R Construct<R>(Func<T1, T2, R> func)
        {
            return func(IdHolderT1.Object, IdHolderT2.Object);
        }
    }
}