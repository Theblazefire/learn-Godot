using Game.Core;
using Game.Gameplay;
using Godot;
using System;
using System.Diagnostics;

public partial class CharacterMovement : Node
{
	[Signal] public delegate void AnimationEventHandler();
	[ExportCategory("Nodes")]
	[Export] public Node2D Character;
	[Export] public CharacterInput characterInput;

	[ExportCategory("Movement")]
	[Export] public Vector2 TarghetPosition = Vector2.Zero;
	[Export] public bool IsWalking=false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Game.Core.Logger.Info("Loading movement component ...");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public bool IsMoving()
	{
		return IsWalking;
	}
	public void StartWalking()
	{
		if (!IsMoving())
		{
			// Wolking animation
			TarghetPosition= Character.Position + characterInput.Direction * Global.Instance.GRIDE_SIZE;
			Game.Core.Logger.Info($"Moving from {Character.Position} to {TarghetPosition}");
			IsWalking= true;
		}
		else
		{
			//idle position
		}
	}

	public void Walk(double delta)
	{
		if (IsWalking)
		{
			Character.Position = Character.Position.MoveToward(TarghetPosition, (float)delta * Global.Instance.GRIDE_SIZE * 4);
			if(Character.Position.DistanceTo(TarghetPosition)< 1f)
			{
				StopWalking();
			}
		}
		else
		{
			// idle animation
		}
	}
	public void StopWalking()
	{
		IsWalking=false;
		SnapPositionToGrid();
	}
	
	public void SnapPositionToGrid()
	{
		Character.Position= new Vector2(
			Mathf.Round(Character.Position.X/ Global.Instance.GRIDE_SIZE) * Global.Instance.GRIDE_SIZE,
			Mathf.Round(Character.Position.Y/ Global.Instance.GRIDE_SIZE) * Global.Instance.GRIDE_SIZE
		);
	}
}
