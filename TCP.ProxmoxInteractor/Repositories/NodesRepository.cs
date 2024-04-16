using Corsinvest.ProxmoxVE.Api;
using Corsinvest.ProxmoxVE.Api.Extension;
using Corsinvest.ProxmoxVE.Api.Shared.Models.Node;
using Microsoft.Extensions.Configuration;
using TCP.ProxmoxInteractor.Factories;
using TCP.ProxmoxInteractor.Repositories.Interfaces;

namespace TCP.ProxmoxInteractor.Repositories;

public class NodesRepository(IProxmoxClientFactory proxmoxClientFactory)
    : BaseProxmoxRepository(proxmoxClientFactory), INodesRepository
{
    public async Task<IEnumerable<NodeItem>> ListNodes()
    {
        var client = _proxmoxClientFactory.Create();
        var nodes = await client.Nodes.Get();

        return nodes;
    }
}