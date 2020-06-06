/*
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdFunctorTest
{
    public class Cons<T1, T2, R>
    {
        private readonly Func<T1, T2, R> _factoryFuncOfT1T2;
        private readonly Func<T1, R> _factoryFuncOfT1;
        private readonly Func<T2, R> _factoryFuncOfT2;
        private readonly Func<R> _factoryFunc;

        private int _id;

        public Cons(Func<T1, T2, R> factoryFunc)
        {
            _factoryFuncOfT1T2 = factoryFunc;
        }

        private Cons(Func<T1, R> factoryFunc)
        {
            _factoryFuncOfT1 = factoryFunc;
        }

        private Cons(Func<T2, R> factoryFunc)
        {
            _factoryFuncOfT2 = factoryFunc;
        }

        public Cons(Func<R> factoryFunc)
        {
            _factoryFunc = factoryFunc;
        }


        public Cons<T2, R>[] Apply(IEnumerable<IdHolder> idHolder)
        {
            if (_id == default)
            {
                _id = idHolder.First().Id;
            }

            var arg = idHolder.FirstOrDefault(h => h.Id == _id);

            if (arg == null)
            {
                return new Cons<T2, R>[0];
            }

            return new Cons<T2, R>[]
            {
                new Cons<T2, R>((t2) => _factoryFuncOfT1T2(arg.Object, t2))
            };

            ////if (_factoryFuncOfT1T2 != null)
            ////{
            ////    if (typeof(TArg) == typeof(T1))
            ////    {
            ////        Func<T2, R> funcOfT2 = t2 => _factoryFuncOfT1T2(idHolder.Object, t2);

            ////        return new Cons<T1, T2, R>(funcOfT2);
            ////    }
            ////    else
            ////    {
            ////        Func<T1, R> funcOfT1 = t1 => _factoryFuncOfT1T2(t1, idHolder.Object);

            ////        return new Cons<T1, T2, R>(funcOfT1);
            ////    }
            ////}
            ////else
            ////{
            ////    if (_factoryFuncOfT1 != null)
            ////    {
            ////        if (typeof(TArg) == typeof(T1))
            ////        {
            ////            Func<R> func = () => _factoryFuncOfT1(idHolder.Object);

            ////            return new Cons<T1, T2, R>(func);
            ////        }
            ////        else
            ////        {
            ////            return this;
            ////        }
            ////    }
            ////    else
            ////    {
            ////        if (typeof(TArg) == typeof(T2))
            ////        {
            ////            Func<R> func = () => _factoryFuncOfT2(idHolder.Object);

            ////            return new Cons<T1, T2, R>(func);
            ////        }
            ////        else
            ////        {
            ////            return this;
            ////        }
            ////    }
            ////}
        }

        public Func<R> Create { get; }
    }

    public class Cons<T1, R>
    {
        private int _id;
        private readonly Func<T1, R> _factoryFuncOfT1;

        public Cons(Func<T1, R> p)
        {
            _factoryFuncOfT1 = p;
        }

        public Func<R>[] Apply(IEnumerable<IdHolder<T1>> idHolder)
        {
            if (_id == default)
            {
                _id = idHolder.First().Id;
            }

            var arg = idHolder.FirstOrDefault(h => h.Id == _id);

            if (arg == null)
            {
                return new Func<R>[0];
            }

            return new Func<R>[]
            {
                new Func<R>(() => _factoryFuncOfT1(arg.Object))
            };
        }
    }
}
*/