using Godot;
using System;

public partial class Node2d : Node2D
{
	private int _healt=6;
	
	[Export]
	public int MaxHelt {get;set;}=10;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("vita "+ _healt);
		if (_healt<MaxHelt)
		{
			_healt=heal(3);
			GD.Print("Vita curata: "+ _healt);
		}
	}
	public int heal(int amount)
	{
		return _healt+amount;
	}
}
