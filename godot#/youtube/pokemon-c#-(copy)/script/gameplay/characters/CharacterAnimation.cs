using Game.Core;
using Godot;
using System;

namespace Game.Gameplay
{
    public partial class CharacterAnimation : AnimatedSprite2D
    {
        [ExportCategory("Nodes")]
        [Export] public CharacterInput characterInput;
        [Export] public CharacterMovement characterMovement;
        
        [ExportCategory("Animation vars")] 
        [Export] public ECharacterAnimation CurrentAnimation = ECharacterAnimation.idle_down;
        
        public override void _Ready()
        {
            characterMovement.Animation += PlayAnimation;
            Game.Core.Logger.Info("Le animazioni sono pronte!");
        }

        public void PlayAnimation(string AnimationType)
        {
            ECharacterAnimation previousAnimation = CurrentAnimation;
            
            if (characterMovement.IsMoving()) return;

            // Il tocco magico: ToLower() forza tutto in minuscolo
            switch (AnimationType.ToLower()) 
            {
                case "walk":
                    if (characterInput.Direction == Vector2.Up) CurrentAnimation = ECharacterAnimation.Walking_up;
                    else if (characterInput.Direction == Vector2.Down) CurrentAnimation = ECharacterAnimation.Walking_down;
                    else if (characterInput.Direction == Vector2.Left) CurrentAnimation = ECharacterAnimation.Walking_left;
                    else if (characterInput.Direction == Vector2.Right) CurrentAnimation = ECharacterAnimation.Walking_right;
                    break;

                case "idle":
                    if (characterInput.Direction == Vector2.Up) CurrentAnimation = ECharacterAnimation.idle_up;
                    else if (characterInput.Direction == Vector2.Down) CurrentAnimation = ECharacterAnimation.idle_down;
                    else if (characterInput.Direction == Vector2.Left) CurrentAnimation = ECharacterAnimation.idle_left;
                    else if (characterInput.Direction == Vector2.Right) CurrentAnimation = ECharacterAnimation.idle_right;
                    break;

                case "turn":
                    if (characterInput.Direction == Vector2.Up) CurrentAnimation = ECharacterAnimation.Turn_up;
                    else if (characterInput.Direction == Vector2.Down) CurrentAnimation = ECharacterAnimation.Turn_down;
                    else if (characterInput.Direction == Vector2.Left) CurrentAnimation = ECharacterAnimation.Turn_left;
                    else if (characterInput.Direction == Vector2.Right) CurrentAnimation = ECharacterAnimation.Turn_right;
                    break;
            }

            if (previousAnimation != CurrentAnimation|| AnimationType.ToLower() == "walk")
            {
                // Ora stamperà il nome vero dell'animazione!
                Game.Core.Logger.Info($"Playing animation: {CurrentAnimation}");
                Play(CurrentAnimation.ToString());
            }
        }
    }
}