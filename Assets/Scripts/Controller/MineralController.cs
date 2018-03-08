using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralController : MonoBehaviour {

    Mineral myMineral;
    public GameObject SpotPrefab;
    [SerializeField]
    public int Width;
    public int Height;


    // Use this for initialization
    void Start () {
        myMineral = new Mineral(Width, Height);
        CreateGo();
    }

    private void CreateGo()
    {
        foreach (var SpotData in myMineral.fullMineral)
        {
            Spot newSpotData = SpotData;
            GameObject Spot_Go = Instantiate(SpotPrefab, newSpotData.Pos, Quaternion.identity);
            Spot_Go.transform.SetParent(this.transform);
            Spot_Go.GetComponent<SpotController>().MySpotData = newSpotData;
        }
    }
}
