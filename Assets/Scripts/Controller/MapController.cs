using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    public Map MyMap;
    public GameObject TilePrefab;
    public GameObject PlayerPrefab;
    [SerializeField]
    public int Width;
    public int Height;

	// Use this for initialization
	void Start ()
    {
        MyMap = new Map(Width, Height);
        CreateGo();
        SpawnPlayer();
	}

    private void CreateGo()
    {
        foreach (var TileData in MyMap.fullMap)
        {
            Tile tileData = TileData;
            GameObject Tile_Go = Instantiate(TilePrefab, TileData.Pos, Quaternion.identity);
            Tile_Go.transform.SetParent(this.transform);
            Tile_Go.GetComponent<TileController>().MyTileData = tileData;
        }

    }
    private void SpawnPlayer()
    {
        GameObject player_Go = Instantiate(PlayerPrefab, new Vector2(Width / 2, 2), Quaternion.identity);
    }
}
