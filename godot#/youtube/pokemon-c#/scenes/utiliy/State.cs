using Godot;
using Game.Core;
namespace Game.Utilities
{
    public abstract partial class State : Node
    {
        [Export] public Node StateOwner;
        public virtual void EnterState()
        {
            Game.Core.Logger.Info($"Entering {GetType().Name} state ..");
        }

        public virtual void ExitState()
        {
            Game.Core.Logger.Info($"Exting {GetType().Name} state ..");
        }
    }
}