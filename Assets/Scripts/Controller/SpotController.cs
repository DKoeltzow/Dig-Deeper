using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour {

    private SpriteRenderer render;

    public Spot MySpotData;

    // Use this for initialization
    void Start()
    {
        UpdateSpriteImage();
    }

    private Color GetColor()
    {
        switch (MySpotData.MySpot)
        {
            case Spot.SpotDegree.empty:
                return Color.white;
            case Spot.SpotDegree.one:
                return Color.yellow;
            case Spot.SpotDegree.two:
                return Color.green;
            case Spot.SpotDegree.three:
                return Color.blue;
            case Spot.SpotDegree.four:
                return Color.red;
            default:
                throw new Exception("MySpot has no Data");
        }
    }

    public void UpdateSpriteImage()
    {
        render = this.gameObject.GetComponent<SpriteRenderer>();
        render.color = GetColor();
    }
}
