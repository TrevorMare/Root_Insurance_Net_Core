using RootInsurance.SDK.RootModules;

namespace RootInsurance.SDK.Interfaces
{
    public interface IApiManager
    {
        PolicyHolder PolicyHolder { get; }
        Quote Quote { get; }
    }
}