using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using CharacIoC.Interfaces;
using CharacIoC.src.Exceptions;

namespace CharacIoC
{
    public class CharaIoCContainer : ICharaIoCContainer
    {
        private readonly IDictionary<Type, object> _iocDict;

        public CharaIoCContainer()
        {
            _iocDict = new ConcurrentDictionary<Type, object>();
        }

        public void RegisterInstance<T>(T instance)
        {
            _iocDict[typeof(T)] = instance;
        }

        public void RegisterType<T, TChild>() 
            where T : class 
            where TChild : T
        {
            var instance = Activator.CreateInstance<TChild>();
            var type = typeof(T);
            _iocDict[type] = instance;
        }

        public T Resolve<T>() where T : class
        {
            var type = typeof(T);
            if (_iocDict.ContainsKey(type))
            {
                return _iocDict[type] as T;
            }
            throw new TypeNotFoundException();
        }
    }
}
