namespace CharacIoC.Interfaces
{
    public interface ICharaIoCContainer
    {
        void RegisterInstance<T>(T instance);

        void RegisterType<T, TChild>()
            where TChild : T
            where T : class;

        T Resolve<T>() where T : class;
    }
}
