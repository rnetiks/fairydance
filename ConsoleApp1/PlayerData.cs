using System;

namespace ConsoleApp1 {
	public class PlayerData
	{
		public string Name = 					String.Empty;
		public int Level = 						1;
		public long XP = 						0;
		public int Strength = 					10;
		public int Intelligence = 				10;
		public int Agility = 					10;
		public byte Statpoints = 				0;
		public float Money = 					0;
		public Vector2 Position = 				new Vector2(0, 0);
		/// <summary>
		/// Higher Floor = Higher Difficulty, each 5 Floors a Boss to get to the next Floor
		/// </summary>
		public byte Floor = 1;
	}
}