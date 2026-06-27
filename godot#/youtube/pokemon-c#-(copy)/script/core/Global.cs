using Godot;
using System;
namespace Game.Core
{
	public partial class Global : Node
	{
		public static Global Instance {get; private set;}
		
		[ExportCategory("Gameplay")]
		[Export] public int GRIDE_SIZE = 16;
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			Instance =this;
			Logger.Info("Loading Global ...");
			
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}