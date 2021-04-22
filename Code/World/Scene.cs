using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace SwapperV2.World
{
    public class Scene
    {
        public Color Background = Color.Black;

        public float GlobalZoom = 1f;
        public Vector2 GlobalOffset = Vector2.Zero;

        public List<Entity> Entities = new List<Entity>();
        public List<Entity> ToRemove = new List<Entity>();

        public void Add(Entity entity)
        {
            entity.Scene = this;
            Entities.Add(entity);
            entity.Added();
        }

        public void Remove(Entity entity)
        {
            ToRemove.Add(entity);
            entity.Removed();
        }

        public virtual void Update(float delta)
        {
            ToRemove.Clear();

            foreach (var entity in Entities)
            {
                entity.Update(delta);
            }

            foreach (var entity in ToRemove)
            {
                // TODO: Multiple removals check
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
