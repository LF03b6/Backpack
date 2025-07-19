using Core.Events.Interfaces;
using Definitions;

namespace Model.Event
{
    public sealed class ReSize : IEventType
    {
        public EventType eventType => EventType.ReSize;
    }
}