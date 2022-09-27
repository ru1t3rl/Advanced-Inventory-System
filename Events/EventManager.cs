using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.Utilities;

namespace Ru1t3rl.Events
{
    public class EventManager : UnitySingleton<EventManager>
    {
        [SerializeField] private List<CustomEvent> events = new List<CustomEvent>();

        protected override void Awake()
        {
            base.Awake();

            // Check if I'm the first instance
            if (EventManager.Instance.GetHashCode() != this.GetHashCode())
            {
                Destroy(this);
            }
        }

        /// <summary>Adds a listenere to an event, if the event doesn't exist it will be created</summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="listener">The listener to add</param>
        public void AddListener(string eventName, System.Action listener)
        {
            if (!events.ContainsKey(eventName))
            {
                events.Add(new CustomEvent(eventName));
            }

            events.GetEvent(eventName).AddListener(listener);
        }

        /// <summary>Removes a listener from an event if the event exists</summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="listener">The listener to remove</param>
        public void RemoveListener(string eventName, System.Action listener)
        {
            if (events.ContainsKey(eventName))
            {
                events.GetEvent(eventName).RemoveListener(listener);
            }
        }

        /// <summary>Add an event, if the eventName already exists add it as a listener</summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="unityEvent">The unity event to add to the manager</param>
        public void AddEvent(string eventName, UnityEvent unityEvent)
        {
            if (!events.ContainsKey(eventName))
            {
                events.Add(new CustomEvent(eventName));
                events[events.Count - 1].unityEvent = unityEvent;
            }
            else
            {
                events.GetEvent(eventName).AddListener(unityEvent.Invoke);
            }
        }

        /// <summary>Add an event if it doesn't exist</summary>
        /// <param name="customEvent">The custom event to add to the manager</param>
        public void AddEvent(CustomEvent customEvent)
        {
            if (!events.Contains(customEvent))
            {
                events.Add(customEvent);
            }
        }

        /// <summary>Remove an event if it exists</summary>
        /// <param name="eventName">The name of the event</param>
        public void RemoveEvent(string eventName)
        {
            if (events.ContainsKey(eventName))
            {
                events.Remove(events.GetEvent(eventName));
            }
        }

        /// <summary>Remove an event if it exists</summary>
        /// <param name="customEvent">The custom event to remove from the manager</param>
        public void RemoveEvent(CustomEvent customEvent)
        {
            if (events.Contains(customEvent))
            {
                events.Remove(customEvent);
            }
        }

        /// <summary>Remove an event if it exists</summary> 
        /// <param name="unityEvent">The unity event to remove from the manager</param>
        public void RemoveEvent(UnityEvent unityEvent)
        {
            if (events.ContainsEvent(unityEvent))
            {
                events.Remove(events.GetEvent(unityEvent));
            }
        }

        /// <summary>Invoke the event with the given name if it exists</summary>
        /// <param name="eventName">The name of the event to invoke</param>
        public void Invoke(string eventName)
        {
            if (events.ContainsKey(eventName))
            {
                events.GetEvent(eventName).Invoke();
            }
        }
    }
}