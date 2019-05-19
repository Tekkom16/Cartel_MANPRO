using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosOriUI : MonoBehaviour {

    public Vector3 OriginalPos;
    public Vector3 OriginalScale;
    public float Speed;
    // Use this for initialization
    void Start ()
    {
        Speed = Random.Range(4, 7);
        this.transform.localScale = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, OriginalPos, Time.deltaTime * Speed);
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, OriginalScale, Time.deltaTime * Speed);
    }

    private void OnEnable()
    {
        Speed = Random.Range(4, 7);
        
        this.transform.localScale = new Vector3(0, 0, 0);
    }
}
