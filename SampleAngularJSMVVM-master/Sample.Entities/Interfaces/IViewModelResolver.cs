namespace Sample.Entities.Interfaces
{
    public interface IViewModelResolver
    {
        object Resolve(string viewModelName);
    }
}
