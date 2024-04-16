using Corsinvest.ProxmoxVE.Api.Shared.Models.Node;
using MediatR;
using TCP.ProxmoxInteractor.Repositories.Interfaces;

namespace TCP.Application.Queries;

public record ListLxcMachinesInNode(string Node) : IRequest<IEnumerable<NodeVmLxc>>;

public class ListLxcMachinesInNodeHandler : IRequestHandler<ListLxcMachinesInNode, IEnumerable<NodeVmLxc>>
{
    private readonly IVirtualMachineRepository _virtualMachineRepository;

    public ListLxcMachinesInNodeHandler(IVirtualMachineRepository virtualMachineRepository)
    {
        _virtualMachineRepository = virtualMachineRepository;
    }

    public async Task<IEnumerable<NodeVmLxc>> Handle(ListLxcMachinesInNode request, CancellationToken cancellationToken)
    {
        var allLxcInNode = await _virtualMachineRepository.ListLxcMachines(request.Node);

        return allLxcInNode;
    }
}