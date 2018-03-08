using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private int width;

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    private int height;

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public Tile[,] fullMap;

    public Map(int width,int height)
    {
        this.width = width;
        this.height = height;
        fullMap = new Tile[width, height];
        FillMap();
    }

    private void FillMap()
    {
        int rnd;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                rnd = UnityEngine.Random.Range(1, 3);
                if (y == 0)
                    rnd = 0;
                Tile.TileType newType = GetType(rnd);
                Tile newTile = new Tile(new Vector2(x, -y), newType);
                fullMap[x, y] = newTile;
            }
        }
    }

    private Tile.TileType GetType(int nbr)
    {
        switch (nbr)
        {
            case 0:
                return Tile.TileType.Grass;
            case 1:
                return Tile.TileType.Dirt;
            case 2:
                return Tile.TileType.Stone;                
            default:
                throw new Exception("No TileType Found For Nbr");
        }
    }
}
