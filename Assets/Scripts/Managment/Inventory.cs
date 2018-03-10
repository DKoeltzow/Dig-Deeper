using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> inventory = new List<GameObject>();

    public delegate void OnInventoryChange();
    public static OnInventoryChange OnInventoryChanged;

    #region Singelton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public void Add(GameObject item)
    {
        inventory.Add(item);

        if (OnInventoryChanged != null)
            OnInventoryChanged();
    }

    public void Remove(GameObject item)
    {
        inventory.Remove(item);

        if (OnInventoryChanged != null)
            OnInventoryChanged();
    }
}
