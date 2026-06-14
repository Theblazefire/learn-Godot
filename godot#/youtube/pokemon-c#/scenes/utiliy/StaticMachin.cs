using Game.Utilities;
using Godot;
using System;
namespace Utilities
{
	public partial class StaticMachin : Node
	{
		[ExportCategory("State Machine vars")]
		[Export] public Node customer;
		[Export] public State currentState;
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			foreach(Node child in GetChildren())
			{
				if (child is State state)
				{
					state.StateOwner= customer;
					state.SetProcess(false);
				}
			}
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public string GetCurrentState()
		{
			return currentState.Name.ToString();
		}

		public void changeState(State newState)
		{
			currentState?.ExitState();
			currentState= newState;
			currentState?.EnterState();

			foreach(Node child in GetChildren())
			{
				if (child is State state)
				{
					state.SetProcess(child==currentState);
				}
			}
		}
	}
}

