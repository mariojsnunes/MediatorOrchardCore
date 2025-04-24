namespace Weather.Requests;

using System.Threading;
using System.Threading.Tasks;
using Mediator;

public class GetWeather : IRequest<int> { }

public class GetWeatherHandler : IRequestHandler<GetWeather, int>
{
    public ValueTask<int> Handle(GetWeather request, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(10);
    }
}
