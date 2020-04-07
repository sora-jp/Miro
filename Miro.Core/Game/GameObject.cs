using System;
using System.Collections.Generic;
using Miro.Core.Pooling;

namespace Miro.Core
{
    public class GameObject : Poolable
    {
        public string Name { get; set; } = "New GameObject";
        public Transform Transform => GetComponent<Transform>();
        readonly Dictionary<Type, Component> m_components = new Dictionary<Type, Component>();

        public T AddComponent<T>() where T : Component
        {
            if (m_components.ContainsKey(typeof(T))) 
                throw new InvalidOperationException($"Cannot add a component which already exists. Component -> {typeof(T)}");

            var component = Component.CreateComponent<T>(this);
            m_components.Add(typeof(T), component);
            return component;
        }

        public void RemoveComponent<T>() where T : Component
        {
            if (!m_components.Remove(typeof(T), out var component)) 
                throw new InvalidOperationException($"Cannot remove a component which does not exist. Component -> {typeof(T)}"); 

            Component.ReleaseComponent(component);
        }

        public T GetComponent<T>() where T:Component
        {
            if (!m_components.TryGetValue(typeof(T), out var component)) 
                throw new InvalidOperationException($"Component not found. Component -> {typeof(T)}");

            return (T)component;
        }

        public override void Reset()
        {
            // Release all components
            foreach (var pair in m_components) Component.ReleaseComponent(pair.Value);
            m_components.Clear();

            // Clear everything else
            base.Reset();
        }
    }
}
