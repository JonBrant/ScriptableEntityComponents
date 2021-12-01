using System;

namespace TheLiquidFire.AspectContainer {
    public interface IAspect {
        IContainer container { get; set; }
    }

    [Serializable]
    public class Aspect : IAspect {
        
        public IContainer container { get; set; }
    }
}