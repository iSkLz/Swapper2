using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace SwapperV2.World
{
    public class Scene
    {
        public List<Entity> Entities = new List<Entity>();
        public Color Background = Color.Black;

        public void Add(Entity entity)
        {
            entity.Scene = this;
            Entities.Add(entity);
        }

        public virtual void Update(float delta)
        {
            var toRemove = new List<Entity>();

            foreach (var entity in Entities)
            {
                if (entity.Update(delta)) toRemove.Add(entity);
            }

            foreach (var entity in toRemove)
            {
                Entities.Remove(entity);
            }
        }

        public virtual void Render()
        {
            foreach (var entity in Entities)
            {
                entity.Render();
            }
        }
    }
}
