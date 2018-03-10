using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private SpriteRenderer render;

    public GameObject DropPrefab;

    public Tile MyTileData;

	// Use this for initialization
	void Start ()
    {
        UpdateSpriteImage();
	}

    public void UpdateSpriteImage()
    {
        render = this.gameObject.GetComponent<SpriteRenderer>();
        render.sprite = SpriteUpdater.GetSpriteByName(MyTileData.MyType.ToString());
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
        CreateDrop();
    }

    void CreateDrop()
    {
        GameObject drop = Instantiate<GameObject>(DropPrefab, transform.position, Quaternion.identity);
        string name = MyTileData.MyType + "_Drop";
        Debug.Log(name);
        drop.GetComponent<SpriteRenderer>().sprite = SpriteUpdater.GetSpriteByName(name);
    }   
}
