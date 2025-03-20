using Godot;
using System;

public partial class seed_box_numericOnly : LineEdit
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect("text_changed", new Callable(this, nameof(OnTextChanged)));
	}
	
	private void OnTextChanged(string newText)
	{
		string filteredText = "";
		//bool hasDash = false;
		
		int caretPosition = CaretColumn;
		
		foreach (char c in newText)
		{
			if (Char.IsDigit(c))
			{
				filteredText += c;
			}
			/*else if (c == '-' && hasDash == false && filteredText.Length == 0)
			{
				if (c != '-') {break;}
				if (filteredText.Length > 0) {break;}
				filteredText += c;
				hasDash = true;
			}*/
		}
		Text = filteredText; 
		
		CaretColumn = caretPosition > Text.Length ? Text.Length : caretPosition;
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
