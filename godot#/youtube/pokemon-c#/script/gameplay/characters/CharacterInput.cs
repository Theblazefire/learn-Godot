using Game.Core;
using Godot;

namespace Game.Gameplay
{
	public abstract partial class CharacterInput : Node
	{
		[Signal] public delegate void WalkEventHandler();
		[Signal] public delegate void TurnEventHandler();
		[ExportCategory("commun input")]
		[Export] public Vector2 Direction = Vector2.Zero;
		[Export] public Vector2 TarghetPosition = Vector2.Zero;
	}

}

