using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral
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
    public Spot[,] fullMineral;

    public Mineral(int width, int height)
    {
        this.width = width;
        this.height = height;
        fullMineral = new Spot[width, height];
        FillMineral();
    }

    private void FillMineral()
    {
        int rnd;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                rnd = UnityEngine.Random.Range(0, 5);
                Spot.SpotDegree newDegree = GetDegree(rnd);
                Spot newSpot = new Spot(new Vector2(x, -y), newDegree);
                fullMineral[x, y] = newSpot;
            }
        }
    }
    private Spot.SpotDegree GetDegree(int nbr)
    {
        switch (nbr)
        {
            case 0:
                return Spot.SpotDegree.empty;
            case 1:
                return Spot.SpotDegree.one;
            case 2:
                return Spot.SpotDegree.two;
            case 3:
                return Spot.SpotDegree.three;
            case 4:
                return Spot.SpotDegree.four;
            default:
                throw new Exception("No TileType Found For Nbr");
        }
    }

}
