using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActable : MonoBehaviour {

    #region Singelton

    public static InterActable instance;

    void Awake()
    {
        instance = this;
    }
#endregion

    public List<Collider2D> interact = new List<Collider2D>();


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!interact.Contains(other))
        {
            interact.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interact.Contains(other))
        {
            interact.Remove(other);
        }
    }

    public bool IsInterActable(GameObject obj)
    {
        foreach (var coll in interact)
        {
            if (coll.gameObject == obj)
                return true;
        }
        return false;
    }
}
