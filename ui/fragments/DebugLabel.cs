using Godot;
using System;
using System.Threading.Tasks;

public class DebugLabel : Label
{
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
			if (eventKey.Pressed)
			{
				if (eventKey.Scancode == (int) KeyList.F3)
					Visible = !Visible;
				if (eventKey.Scancode == (int) KeyList.F11)
					OS.WindowFullscreen = !OS.WindowFullscreen;
			}
	}
	public override void _Ready()
	{
		new System.Threading.Thread(() =>
		{
			while (true)
			{
				Text = Engine.GetFramesPerSecond() + " fps\n" + Engine.TargetFps + " cap\n" + Engine.IterationsPerSecond + " ips";
			}
		}).Start();
	}
	
}
