using System;
using System.Collections.Generic;

namespace Utils
{
    /// <summary>
    /// 事件调度器
    /// </summary>
    public sealed class EventDispatcher
    {
        private readonly Dictionary<EEventType, List<Action<IEventType>>> _handlers = new();

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <param name="callback">事件 call back</param>
        public void Subscribe(EEventType type, Action<IEventType> callback)
        {
            if (!_handlers.TryGetValue(type, out var list))
            {
                list = new List<Action<IEventType>>();
                _handlers[type] = list;
            }

            list.Add(callback);
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <param name="callback">事件 call back</param>
        public void Unsubscribe(EEventType type, Action<IEventType> callback)
        {
            if (_handlers.TryGetValue(type, out var list))
            {
                list.Remove(callback);
            }
        }

        /// <summary>
        /// 分发
        /// </summary>
        /// <param name="evt">事件类型</param>
        public void Dispatch(IEventType evt)
        {
            if (!_handlers.TryGetValue(evt.eventType, out var list)) return;
            foreach (var cb in list)
                cb.Invoke(evt);
        }
    }
}