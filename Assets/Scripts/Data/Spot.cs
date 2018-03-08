using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot
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


    private SpotDegree mySpot;

    public SpotDegree MySpot
    {
        get
        {
            return mySpot;
        }

        set
        {
            mySpot = value;
        }
    }

    public enum SpotDegree { empty,one,two,three,four};

    public Spot(Vector2 pos, SpotDegree degree)
    {
        this.pos = pos;
        this.mySpot = degree;
    }
}
