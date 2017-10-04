using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public int tileSize;
	public int mapDimension;
	[Range(0.1f,0.9f)]
	public float tilePercent;

	public GameObject tilePrefab;
	public GameObject floorPrefab;

	Transform[,] tiles;

	void Awake () {
		
	}
	

	public void GenerateMap () {

		string holderName = "Map";
		if (transform.Find (holderName)) {
			DestroyImmediate (transform.Find (holderName).gameObject);
		}

		Transform mapHolder = new GameObject (holderName).transform;
		mapHolder.parent = transform;

		Transform floor = (Instantiate(floorPrefab,Vector3.zero,Quaternion.Euler(Vector3.zero))).transform;
		floor.localScale = (new Vector3 (1f, 0, 1f) * tileSize * mapDimension) + (new Vector3 (0, 1, 0));
		floor.parent = mapHolder;

		tiles = new Transform[mapDimension,mapDimension];
		for (int x = 0; x < mapDimension; x ++) {
			for (int y = 0; y < mapDimension; y ++) {
				float coordX = (mapDimension/2 - (x+0.5f)) * tileSize;
				float coordY = (mapDimension/2 - (y+0.5f)) * tileSize;
				Vector3 tilePosition = new Vector3 (coordX, 0.05f, coordY);
				Transform newTile = (Instantiate (tilePrefab, tilePosition, Quaternion.Euler (Vector3.zero))).transform;
				newTile.localScale = (new Vector3 (1f, 0, 1f) * (1 - tilePercent) * tileSize) + (new Vector3 (0, 1, 0));
				newTile.parent = mapHolder;
				tiles[x,y] = newTile;
			}
		}
	}
}
