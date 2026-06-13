using Game.Core;
using Godot;

namespace Game.Gameplay
{
	public partial class PlayerInput : CharacterInput
	{
		[ExportCategory("player Input")]
		//la soglia di attesa indica quanto tempo bisogna premere il pulsante
		[Export] public double sogliaDiAtesa= 0.1f; 
		[Export] public double sogliaDiTempo= 0.0f; 
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			Game.Core.Logger.Info("loading player input component ...");
		}


	}
}

