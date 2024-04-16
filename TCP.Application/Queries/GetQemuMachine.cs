using Corsinvest.ProxmoxVE.Api.Shared.Models.Node;
using Corsinvest.ProxmoxVE.Api.Shared.Models.Vm;
using MediatR;
using TCP.ProxmoxInteractor.Repositories.Interfaces;

namespace TCP.Application.Queries;

public record GetQemuMachine(string Node, int VmId) : IRequest<VmConfigQemu>;

public class GetQemuMachineHandler : IRequestHandler<GetQemuMachine, VmConfigQemu>
{
    private readonly IVirtualMachineRepository _virtualMachineRepository;

    public GetQemuMachineHandler(IVirtualMachineRepository virtualMachineRepository)
    {
        _virtualMachineRepository = virtualMachineRepository;
    }

    public async Task<VmConfigQemu> Handle(GetQemuMachine request, CancellationToken cancellationToken)
    {
        try
        {
            var machine = await _virtualMachineRepository.GetQemuMachine(request.Node, request.VmId);
            return machine;
        }
        catch (Exception)
        {
            return null;
        }

    }
}