using System;

namespace CharacIoC.src.Exceptions
{
    public class RequiresZeroParamterConstructorException : Exception
    {
        public RequiresZeroParamterConstructorException(Type t) : base($"{nameof(t)} requires a parameterless constructor") { }
    }
}
