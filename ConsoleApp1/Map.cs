using System.Collections.Generic;

namespace ConsoleApp1 {
	/// <summary>
	/// Should be made Procedural, with a good saving system over several files, preload files & add noise biomes with different events
	/// </summary>
	public class Map {
		private Tile[] _tiles;
	}

	public class Tile : Map {
		public bool HasEvent;
		public MapEvents MapEvent = MapEvents.None;
		public Vector2 position;
		public int[] connectedElement;
	}

	public class City {
		public float Popultion;
		public NPC[] npcs;
	}

	public class Item {
		public string name;
		public string description;
		public string level;
	}
	public class NPC {
		public int level, str, agi, mag;
		public string name;
		public string Gender;
		public Inventory Inventory;
	}

	public class Inventory {
		/// <summary>
		/// Quantitiy, Item
		/// </summary>
		public System.Collections.Generic.Dictionary<int, Item> items;

		public int MaxInventorySize = 24;

		public int SelectedWeapon, SelectedArmor, SelectedAccessoir;
		public Inventory() {
			items = new Dictionary<int, Item>(MaxInventorySize);
		}
	}
	public enum MapEvents {
		None,
		EnemyEncounter,
		City,
		FriendlyEncounter,
		SpecialScene
	}
}