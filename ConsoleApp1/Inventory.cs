using System.Collections.Generic;

namespace ConsoleApp1 {
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
}