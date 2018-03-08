using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

    [SerializeField]

    private List<Sprite> TileSprites;

	// Use this for initialization
	void Start ()
    {
        foreach (var sprite in TileSprites)
        {
            SpriteUpdater.AddSprite(sprite.name, sprite);
        }
	}
}

public static class SpriteUpdater
{
    private static Dictionary<string, Sprite> SpriteLib = new Dictionary<string, Sprite>();

    public static Sprite GetSpriteByName(string name)
    {
        Sprite temp = SpriteLib[name];
        return temp;
    }

    public static void AddSprite(string key, Sprite value)
    {
        SpriteLib.Add(key, value);
    }
}
