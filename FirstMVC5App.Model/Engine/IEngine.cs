using System;
using System.Runtime.InteropServices.ComTypes;

namespace FirstMVC5App.Model.Engine
{
    public interface IEngine : IDisposable
    {
        T Get<T>();
    }
}