namespace CharaIoC.UnitTest.IoC.Dummies
{
    internal interface IDummy
    {
    }

    internal class DummyClass : IDummy
    {
    }

    internal class NonEmptyConstructorDummy : IDummy
    {
        private int _x;
        internal NonEmptyConstructorDummy(int x)
        {
            _x = x;
        }
    }
}
