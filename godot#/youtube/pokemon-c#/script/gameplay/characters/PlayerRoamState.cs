using Game.Core;
using Godot;
using System;

namespace Game.Gameplay
{
	public partial class PlayerRoamState : Game.Utilities.State
	{
		[ExportCategory("State vers")]
		[Export] public PlayerInput playerInput;
		// Called when the node enters the scene tree for the first time.

        public override void _Process(double delta)
        {
            GetInputDirection();
			GetInput(delta);
        }

		public void GetInputDirection()
		{
			if (Input.IsActionJustPressed("ui_up"))
			{
				playerInput.Direction = Vector2.Up;
				playerInput.TarghetPosition= new Vector2(0,-Global.Instance.GRIDE_SIZE);
			}
			else
			{
				if (Input.IsActionJustPressed("ui_down"))
				{
					playerInput.Direction = Vector2.Down;
					playerInput.TarghetPosition= new Vector2(0,Global.Instance.GRIDE_SIZE);
				}
				else
				{
					if (Input.IsActionJustPressed("ui_left"))
					{
						playerInput.Direction = Vector2.Left;
						playerInput.TarghetPosition= new Vector2(-Global.Instance.GRIDE_SIZE, 0);
					}
					else
					{
						if (Input.IsActionJustPressed("ui_right"))
						{
							playerInput.Direction = Vector2.Right;
							playerInput.TarghetPosition= new Vector2(Global.Instance.GRIDE_SIZE, 0);
						}
					}
				}
			}
		}//                          |-tempo trascaorso dall'ultimo frame
		public void GetInput(double delta)
		{
			if (Modules.IsActionJustReleased())
			{
				if( playerInput.sogliaDiTempo > playerInput.sogliaDiAtesa )
				{
					playerInput.EmitSignal(CharacterInput.SignalName.Walk);
				}
				else
				{
					playerInput.EmitSignal(CharacterInput.SignalName.Turn);
				}
				playerInput.sogliaDiTempo = 0.0f;
			}
			if (Modules.IsActionPressed())
			{
				playerInput.sogliaDiTempo += delta;
				if( playerInput.sogliaDiTempo > playerInput.sogliaDiAtesa)
				{
					playerInput.EmitSignal(CharacterInput.SignalName.Walk);
				}
			}
		}
	}

}
