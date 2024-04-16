using Corsinvest.ProxmoxVE.Api.Shared.Models.Node;
using MediatR;
using TCP.ProxmoxInteractor.Repositories.Interfaces;

namespace TCP.Application.Queries;

public record ListQemuMachinesInNode(string Node) : IRequest<IEnumerable<NodeVmQemu>>;

public class ListQemuMachinesInNodeHandler : IRequestHandler<ListQemuMachinesInNode, IEnumerable<NodeVmQemu>>
{
    private readonly IVirtualMachineRepository _virtualMachineRepository;

    public ListQemuMachinesInNodeHandler(IVirtualMachineRepository virtualMachineRepository)
    {
        _virtualMachineRepository = virtualMachineRepository;
    }

    public async Task<IEnumerable<NodeVmQemu>> Handle(ListQemuMachinesInNode request, CancellationToken cancellationToken)
    {
        var allQemuInNode = await _virtualMachineRepository.ListQemuMachines(request.Node);

        return allQemuInNode;
    }
}