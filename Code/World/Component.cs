using System;
using System.Collections.Generic;

namespace SwapperV2.World
{
    public class Component
    {
        public Entity Parent;

        public virtual bool Update(float delta) => false;
        public virtual void Render() { }
    }
}
