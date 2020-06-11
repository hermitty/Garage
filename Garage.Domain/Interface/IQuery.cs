using MediatR;

namespace Garage.Domain.Interface
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
