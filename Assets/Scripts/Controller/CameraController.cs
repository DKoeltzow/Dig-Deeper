using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float CameraMode; //0 = Player; 1 = Mapmode

    GameObject Player;
	
	// Update is called once per frame
	void Update () {

        if(CameraMode ==0)
        {
            playerMode();
        }
        else if(CameraMode == 1)
        {
            mapMode();
        }		
	}

    void playerMode()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Vector3 playerpos = Player.transform.position;

            this.gameObject.transform.position = new Vector3(playerpos.x, playerpos.y, -10);
        }

    }

    void mapMode()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Map");
        }
        else
        {
            Vector3 playerpos = new Vector3((float)(Player.GetComponent<MineralController>().Width-1)/2,(float) -(Player.GetComponent<MineralController>().Height-1)/2, -12);

            this.gameObject.transform.position = playerpos;
        }

    }
}
