using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random=UnityEngine.Random; 
using System.Linq;

public class GridManager : MonoBehaviour {
    [SerializeField] public int width, height;
    private int _width, _height;
    [SerializeField] private Tile grassTile, desertTile, mountainTile, oceanTile, snowTile;
    [SerializeField] private Transform cam;

    public static GridManager Instance;
    private Dictionary<Vector2, Tile> tiles;

    void Awake() {
        Instance = this;
    }
 
    public void GenerateGrid() {

        //Initialise Tile Dictionary
        tiles = new Dictionary<Vector2, Tile>();

        //Grass tile spawn (Top left)
         for (int x = 0; x < width / 2; x++) {
            for (int y = 5; y < height; y++) {

                var spawnedGrassTiles = Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);
                spawnedGrassTiles.name = $"GrassTile {x} {y}";
                spawnedGrassTiles.Init(x, y);
                tiles[new Vector2(x, y)] = spawnedGrassTiles;
             }
        }

        //Desert tile spawn (Top right)
        for (int x = 8; x < width; x++) {
            for (int y = 5; y < height; y++) {

                var spawnedDesertTiles = Instantiate(desertTile, new Vector3(x, y), Quaternion.identity);
                spawnedDesertTiles.name = $"DesertTile {x} {y}";
                spawnedDesertTiles.Init(x, y);
                tiles[new Vector2(x, y)] = spawnedDesertTiles;
             }
        }

        //Mountain tile spawn (Bottom left)
        for (int x = 0; x < width / 2; x++) {
            for (int y = 0; y < height / 2; y++) {
                var spawnedMountainTiles = Instantiate(mountainTile, new Vector3(x, y), Quaternion.identity);
                spawnedMountainTiles.name = $"MountainTile {x} {y}";
                spawnedMountainTiles.Init(x, y);
                tiles[new Vector2(x, y)] = spawnedMountainTiles;
             }
        }

        //Ocean tile spawn (Bottom right)
        for (int x = 8; x < width; x++) {
            for (int y = 0; y < height / 2; y++) {
                var spawnedOceanTiles = Instantiate(oceanTile, new Vector3(x, y), Quaternion.identity);
                spawnedOceanTiles.name = $"OceanTile {x} {y}";
                spawnedOceanTiles.Init(x, y);
                tiles[new Vector2(x, y)] = spawnedOceanTiles;
             }
        }

                //Snow tile spawn (Middle)
        for (int x = 5; x < (width / 2 + 3); x++) {
            for (int y = 3; y < (height / 2 + 2) ; y++) {
                var spawnedSnowTiles = Instantiate(snowTile, new Vector3(x, y), Quaternion.identity);
                spawnedSnowTiles.name = $"SnowTile {x} {y}";
                spawnedSnowTiles.Init(x, y);
                tiles[new Vector2(x, y)] = spawnedSnowTiles;
                //Need to find a way to delete the Tiles under the snow Tiles
             }
        }

        //Camera setup
        cam.transform.position = new Vector3((float) width / 2 - 0.5f, (float) height / 2 - 0.5f, -10);

        //Switch to next game state
        GameManager.Instance.ChangeState(GameState.HumanSpawn);
    }

    //Get random spawn tile that is empty
    public Tile GetSpawnTile() {
        return tiles.Where(t => t.Key.x <= width && t.Value.Empty).OrderBy(tiles => Random.value).First().Value;
    }

}