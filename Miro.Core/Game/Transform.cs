// If this code works, it was written by Sora
// Otherwise, I don't know who wrote it

// ReSharper disable FieldCanBeMadeReadOnly.Local
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Miro.Core
{
    public class Transform : Component
    {
        Transform m_parent;

        public Transform Parent
        {
            get => m_parent;
            set => SetParent(value);
        }

        List<Transform> m_children = new List<Transform>();

        public IReadOnlyList<Transform> Children => m_children;

        public void SetParent(Transform value)
        {
            m_parent?.RemoveChild(this);
            m_parent = value;
            m_parent?.AddChild(this);
        }

        public void AddChild(Transform transform)
        {
            m_children.Add(transform);
        }

        public void RemoveChild(Transform transform)
        {
            m_children.Remove(transform);
        }
    }
}