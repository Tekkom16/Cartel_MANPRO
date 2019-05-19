using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCubeScript : MonoBehaviour {

    public Ray Origin;
    public GameObject Canvas;
    // Use this for initialization
    void Start () {
        Canvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Origin = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(Origin, out Hit, 200))
            {
                if (Hit.collider.name == "Cube") {
                    Canvas.SetActive(true);
                    Canvas.transform.Find("Panel").GetChild(0).transform.position = this.transform.position;
                    Canvas.transform.Find("Panel").GetChild(1).transform.position = this.transform.position;
                    Canvas.transform.Find("Panel").GetChild(2).transform.position = this.transform.position;
                }
            }
        }
    }
}
