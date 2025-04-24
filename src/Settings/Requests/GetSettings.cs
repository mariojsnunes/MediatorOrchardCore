namespace Settings.Requests;

using System.Threading;
using System.Threading.Tasks;
using Mediator;
using OrchardCore.Environment.Shell;

public class GetSettings : IRequest<string> { }

public class GetSettingsHandler(ShellSettings shellSettings) : IRequestHandler<GetSettings, string>
{
    public ValueTask<string> Handle(GetSettings request, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(shellSettings.Name);
    }
}
