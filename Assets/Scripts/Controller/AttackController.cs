﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private BoxCollider2D trigger;
    private List<Collider2D> inTrigger;

    private void Awake()
    {
        trigger = GetComponent<BoxCollider2D>();
        inTrigger = new List<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!inTrigger.Contains(collision))
        {
            inTrigger.Add(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(inTrigger.Contains(collision))
        {
            inTrigger.Remove(collision);
        }
    }

    public void Attack()
    {        

        //TODO not destroy while in foreach loop

        foreach (var collider in inTrigger.ToArray())
        {
            if(collider.gameObject.layer == 8)
            {
                //Call Destroy function
                collider.gameObject.GetComponent<TileController>().DestroyMe();
            }            
        }
    }

}
