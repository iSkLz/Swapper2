using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace SwapperV2.World
{
    public class Entity
    {
        public Scene Scene;
        public List<Component> Components = new List<Component>();
        public Vector2 Position;

        public void Add(Component component)
        {
            component.Parent = this;
            Components.Add(component);
        }

        public virtual bool Update(float delta)
        {
            var toRemove = new List<Component>();

            foreach (var comp in Components)
            {
                if (comp.Update(delta)) toRemove.Add(comp);
            }

            foreach (var comp in toRemove)
            {
                Components.Remove(comp);
            }

            return false;
        }

        public virtual void Render()
        {
            foreach (var comp in Components)
            {
                comp.Render();
            }
        }
    }
}
