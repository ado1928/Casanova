using Casanova.core;
using Godot;
using Godot.Collections;

namespace Casanova.ui.fragments
{
	public class CardsContainer : MarginContainer
	{
		private HBoxContainer container;
		private Array<Panel> detectors = new Array<Panel>();
		public override void _Ready()
		{
			container = GetNode<HBoxContainer>("Container");
			
			for (int i = 0; i < container.GetChildCount(); i++)
			{
				Panel cardPanel = container.GetChildren()[i] as Panel;
				VBoxContainer infoBox = cardPanel.GetNode<Panel>("Info").GetNode<VBoxContainer>("VBoxContainer");
				
				// add 2 first children, which are usually Title & Description
				Interface.LabelGroup.Add(infoBox.GetChildren()[0] as Label);
				Interface.LabelGroup.Add(infoBox.GetChildren()[1] as Label);
				
				// add the animation player for this card panel
				Interface.CardsGroup.Add(cardPanel);

				var detector = cardPanel.GetNode<Panel>("Detector");
				detectors.Add(detector);
				
				detector.Connect("mouse_entered", this, "_on_Detector_mouse_entered", new Array {i});
				detector.Connect("mouse_exited", this, "_on_Detector_mouse_exited", new Array {i});
				detector.Connect("gui_input", this, "_on_Detector_gui_input", new Array {i});
				
			}
		}

		public void _cardHover(Array args)
		{
			Panel cardPanel = args[0] as Panel;
			
			// find the animation for this card panel
			AnimationPlayer animation = null;
			for (var i = 0; i < Interface.CardsGroup.Count; i++)
			{
				AnimationPlayer anim = Interface.CardsGroup[i].GetNode<AnimationPlayer>("AnimationPlayer");
				if (anim.GetParent() == cardPanel)
				{
					animation = anim;
				}
			}
			
			animation.Play("hover");
		}

		private void _on_Detector_mouse_entered(int index)
		{
			AnimationPlayer animation = Interface.CardsGroup[index].GetNode<AnimationPlayer>("AnimationPlayer");
			animation.Stop();
			animation.Play("hover");
		}
		
		private void _on_Detector_mouse_exited(int index)
		{
			AnimationPlayer animation = Interface.CardsGroup[index].GetNode<AnimationPlayer>("AnimationPlayer");
			animation.Stop();
			animation.Play("unhover");
		}

		private void _on_Detector_gui_input(InputEvent @event, int index)
		{
			if (@event is InputEventMouseButton)
			{
				var e = (InputEventMouseButton) @event;
				if (@event.IsPressed())
				{
					Interface.Cards.IndexBindings[index].DynamicInvoke();
				}
			}
		}
	}
}
