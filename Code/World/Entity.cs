using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace SwapperV2.World
{
    public class Entity
    {

        public Scene Scene;
        public Vector2 Position;

        public List<Component> Components = new List<Component>();
        public List<Component> ToRemove = new List<Component>();

        public void Add(Component component)
        {
            component.Parent = this;
            Components.Add(component);
            component.Added();
        }

        public void Remove(Component component)
        {
            ToRemove.Add(component);
            component.Removed();
        }

        public void RemoveSelf()
        {
            Scene.Remove(this);
        }

        public virtual void Update(float delta)
        {
            foreach (var comp in Components)
            {
                if (comp.Enabled) comp.Update(delta);
            }

            foreach (var comp in ToRemove)
            {
                // TODO: Multiple removals check
                Components.Remove(comp);
            }

            ToRemove.Clear();
        }

        public virtual void Render()
        {
            foreach (var comp in Components)
            {
                if (comp.Enabled) comp.Render();
            }
        }

        public virtual void Added() { }
        public virtual void Removed() { }
    }
}
