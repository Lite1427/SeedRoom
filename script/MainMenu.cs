using Godot;
using System;

public partial class MainMenu : Node2D
{
	private Button str_btn;
	private LineEdit seed_box;
	public override void _Ready()
	{
		
		str_btn = GetNode<Button>("MainMenu/str_btn");
		seed_box = GetNode<LineEdit>("seed_box");

		str_btn.Connect("pressed", new Callable(this, nameof(_on_str_btn_pressed)));
	}

	
	private bool IsOnlyZeros(string text)
{
    foreach (char c in text)
    {
        if (c != '0') return false;
    }
    return true;
}

	private void _on_str_btn_pressed()
	{
		if(seed_box.Text != "" && seed_box.Text != "0")
		{
			GlobalVariables.seed = long.Parse(seed_box.Text);
		} else if(string.IsNullOrWhiteSpace(seed_box.Text) | seed_box.Text == "0")
		{
			var random = new RandomNumberGenerator();
			random.Randomize();
			int generatedSeed = random.RandiRange(1, 999999999);
			random.Seed = (ulong)generatedSeed;
			GlobalVariables.seed = generatedSeed;
			GD.Seed((ulong)generatedSeed);
			GD.Print("Done!");
		}
		seed_box.Editable = false;
		GetNode<BaseButton>("str_btn").Disabled = true;
		GD.Print(GlobalVariables.seed);
		
		if (!IsOnlyZeros(GlobalVariables.seed.ToString()))
		{
			GD.Seed((ulong)GlobalVariables.seed);
			GetTree().ChangeSceneToFile("res://room/game_room.tscn");
		} else {
			//Error
			GD.Print("ERROR!");
		}
	}
}
