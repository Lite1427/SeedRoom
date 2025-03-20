using Godot;
using System;

public static class GlobalVariables
{
	public static long seed = 0;
	public static int room_max = 20;
	public static int room_min = 7;
	public static int rooms_created = 0;
	public static int rooms_to_create = -1;
	public static bool player_movement_allowed = false;
	public static bool forbid_room_creation = false;
}
