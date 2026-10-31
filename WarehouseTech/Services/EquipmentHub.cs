using Microsoft.AspNetCore.SignalR;

namespace WarehouseTech.Services;

public class EquipmentHub : Hub
{
    public async Task NotifyChange() => await Clients.Others.SendAsync("EquipmentChanged", "update");
}