using System;
using System.Collections.Generic;

namespace SwapperV2.World
{
    public class Component
    {
        public Entity Parent;
        public bool Enabled = true;

        public virtual void Update(float delta) { }
        public virtual void Render() { }
        public virtual void Added() { }
        public virtual void Removed() { }

        public void RemoveSelf()
        {
            Parent.Remove(this);
        }

        public void Add(Component component)
        {
            Parent.Add(component);
        }
    }
}
