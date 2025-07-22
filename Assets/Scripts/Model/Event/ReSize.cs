using Core.Events.Interfaces;
using Definitions;

namespace Model.Event
{
    public sealed class ReSize : IEventType
    {
        // todo : 缺乏总线事件实现
        public EventType eventType => EventType.ReSize;
    }
}