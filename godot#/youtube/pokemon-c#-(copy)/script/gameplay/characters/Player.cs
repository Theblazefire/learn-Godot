using Game.Utilities;
using Godot;
using System;
using System.Runtime.CompilerServices;
using Utilities;

public partial class Player : CharacterBody2D
{
	[Export] public StaticMachin staticMachin;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		staticMachin.changeState(staticMachin.GetNode<State>("Roam"));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
