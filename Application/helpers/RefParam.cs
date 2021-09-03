using System;
using System.Collections.Generic;
using System.Text;

namespace Application.helpers
{
    public class RefParam<T>
    {
        public T value { get; set; }

        public RefParam()
        {

        }
        public RefParam(T value)
        {
            this.value = value;
        }

        public override string ToString() => value == null ? string.Empty : value.ToString();


        public static implicit operator T(RefParam<T> r) { return r.value; }
        public static implicit operator RefParam<T>(T value) { return new RefParam<T>(value); }

    }
}
