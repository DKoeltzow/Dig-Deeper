using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour {

    public bool OnGround = false;

    public bool InAir = false;

    private List<Collider2D> open = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!open.Contains(other))
        {
            open.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (open.Contains(other))
        {
            open.Remove(other);
        }
    }

    private void FixedUpdate()
    {
        if(open.Count == 0)
        {
            OnGround = false;
        }
        else
        {
            OnGround = true;
        }
    }
}
