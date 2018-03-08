using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private Vector2 pos;
    public Vector2 Pos
    {
        get
        {
            return pos;
        }

        set
        {
            pos = value;
        }
    }


    private TileType myType;

    public TileType MyType
    {
        get
        {
            return myType;
        }

        set
        {
            myType = value;
        }
    }

    public enum TileType { Grass,Dirt,Stone};

    public Tile( Vector2 pos,TileType type)
    {
        this.pos = pos;
        this.myType = type;
    }

    
}


