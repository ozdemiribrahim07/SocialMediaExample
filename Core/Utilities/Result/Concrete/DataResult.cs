﻿using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Utilities.Result.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data ,bool isSuccess, string message) : base(isSuccess, message)
        {
            Data = data;
        }


        public DataResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }


        public T Data { get; }


    }
}
