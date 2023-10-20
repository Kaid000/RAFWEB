using RAFWEB.Data.Models;

namespace RAFWEB.Domain.Services.Interfaces
{
    public interface IEventService
    {
        public Task GetEvents(string EventName);

        public Task DeleteEvent(string EventName);

        public Task CreateEvent(Holiday holiday);
    }
}
