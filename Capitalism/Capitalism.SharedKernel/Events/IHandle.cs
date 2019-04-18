namespace Capitalism.SharedKernel.Events
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
