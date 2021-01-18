using System;
using System.IO;

namespace ConsoleApp1 {
	public class Tile : Map {
		public bool HasEvent;
		public MapEvents MapEvent = MapEvents.None;
		public Vector2 position;
		public City city = null;
		public int[] connectedElement;

		public static double Distance(double X, double Y) {
			var x = 0 - X;
			var y = 0 - Y;
			return Math.Sqrt(x * x + y * y);
		}
		public static Tile[] GetSurroundingTiles(long dim, long floor, long x, long y) {
			return new[] {
				GetTile(dim, floor, x - 1, y - 1),
				GetTile(dim, floor, x, y - 1),
				GetTile(dim, floor, x + 1, y - 1),

				GetTile(dim, floor, x - 1, y),
				GetTile(dim, floor, x, y),
				GetTile(dim, floor, x + 1, y),

				GetTile(dim, floor, x - 1, y + 1),
				GetTile(dim, floor, x, y + 1),
				GetTile(dim, floor, x + 1, y + 1),
			};

		}
		
		public static Tile GetTile(long dim, long floor, long x, long y) {
			string path = $"maps/dim{dim}/f{floor}/tile/{x / 10000}/{x}/{y / 10000}/{y}";
			
			if (Directory.Exists(path) && File.Exists($"{path}/map.fd")) {
				return new Tile();
			}

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
			FileStream fileStream = new FileStream($"{path}/map.fd", FileMode.CreateNew);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			binaryWriter.Write("FD FORMAT 1.0");
			Random rand = new Random();
				
			Tile tile = new Tile();
				
			var next = rand.Next(100);
			if (next < 10) {
				Console.WriteLine("event");
				tile.HasEvent = true;
				tile.MapEvent = (MapEvents) rand.Next(1, 4);
				binaryWriter.Write(true);
				binaryWriter.Write((byte)tile.MapEvent);
				if (tile.MapEvent == MapEvents.City) {
					tile.city = new City {Popultion = rand.Next(2000)};
					binaryWriter.Write(tile.city.Popultion);
					for (int i = 0; i < tile.city.Popultion; i++) {
						Npc currentNPC = new Npc();
						int lv = (int) (Math.Ceiling(Distance(x, y) + 1) * rand.NextDouble() / 10);
						lv = lv >= 1 ? lv : 1;
						currentNPC.level = lv;
						binaryWriter.Write(lv);
						tile.city.npcs[i] = currentNPC;
					}
				}
			}
			else {
				Console.WriteLine("No Event");
				binaryWriter.Write(false);
				binaryWriter.Write((int)MapEvents.None);
			}
			binaryWriter.Dispose();
			fileStream.Dispose();
			return tile;
		}
	}
}