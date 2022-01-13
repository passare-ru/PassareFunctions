using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Term2
{
    public class EnumBag : EnumBag_internal<Enum>
    {
        public EnumBag() { }
        public EnumBag(params Enum[] elements) : base(elements) { }
    }

    public class EnumBag_internal<TClass> : HashSet<TClass> where TClass : IConvertible
    {
        public EnumBag_internal() { }
        public EnumBag_internal(params TClass[] elements) { this.UnionWith(elements); }

        public T[] OfType<T>() where T : TClass
        {
            Type t = typeof(T);
            List<T> result = new List<T>();
            foreach (var i in this)
            { 
                if (i.GetType() == t)
                {
                    result.Add((T)i);
                }
            }
            return result.ToArray();
        }
        public TClass[] OfType(Type t)
        {
            List<TClass> result = new List<TClass>();
            foreach (var i in this)
            {
                if (i.GetType() == t)
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }

        public T FirstOfType<T>(T def = default(T)) where T : TClass
        {
            var f = OfType<T>();
            if (f.Length > 0)
            {
                return f[0];
            }
            else
            {
                return def;
            }
        }
        public TClass FirstOfType(Type t, TClass def = default(TClass)) 
        {
            var f = OfType(t);
            if (f.Length > 0)
            {
                return f[0];
            }
            else
            {
                return def;
            }
        }

        public static EnumBag_internal<TClass> operator +(EnumBag_internal<TClass> a, EnumBag_internal<TClass> b)
        {
            var e = new EnumBag_internal<TClass>();
            e.UnionWith(a);
            e.UnionWith(b);
            return e;
        }
        public static EnumBag_internal<TClass> operator -(EnumBag_internal<TClass> a, EnumBag_internal<TClass> b)
        {
            var e = new EnumBag_internal<TClass>();
            e.UnionWith(a);
            e.ExceptWith(b);
            return e;
        }
        public static EnumBag_internal<TClass> operator *(EnumBag_internal<TClass> a, EnumBag_internal<TClass> b)
        {
            var e = new EnumBag_internal<TClass>();
            e.UnionWith(a);
            e.IntersectWith(b);
            return e;
        }
    }
}
