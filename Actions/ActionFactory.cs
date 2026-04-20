using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagementSystem.Actions;

public class ActionFactory : IActionFactory
{
    private readonly IServiceProvider _serviceProvider;
    
    public ActionFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
    public T Create<T>() where T : class, IAction => _serviceProvider.GetRequiredService<T>();
}
