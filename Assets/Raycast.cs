using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

    /*RaycastHit[] hit;
    Ray Touches;
    public float Speed;
    public float Distance;*/

    public GameObject[] currentHitObject;
    public float SphereRadius;
    public float maxDistance;
    public LayerMask layermask;
    public Ray Origin;
    public Vector3[] direction;

    private float[] currentHitDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* if (Input.touchCount > 0) {
             Touches = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
             hit = Physics.RaycastAll(Touches, Distance);

             for(int i = 0; i < hit.Length; i++) {
                 hit[i].transform.Rotate(0, Time.deltaTime * Speed, 0);

                 if (i == 0)
                 {
                     Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), hit[i].point, Color.yellow);
                 }
                 else
                 {
                     Debug.DrawLine(hit[i-1].point, hit[i].point, Color.red);
                 }
             }
         }*/

        if (Input.GetMouseButton(0))
        {
            Origin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] SphereHit;
            SphereHit = Physics.SphereCastAll(Origin, SphereRadius, maxDistance, layermask, QueryTriggerInteraction.UseGlobal);


            if (SphereHit.Length > 0)
            {
                currentHitObject = new GameObject[SphereHit.Length];
                currentHitDistance = new float[SphereHit.Length];
                direction = new Vector3[SphereHit.Length];

                for (int i = 0; i < SphereHit.Length; i++)
                {
                    direction[i] = SphereHit[i].point;
                    currentHitObject[i] = SphereHit[i].transform.gameObject;
                    currentHitObject[i].transform.Rotate(0, 0, Time.deltaTime * 50);
                    currentHitDistance[i] = SphereHit[i].distance;
                    Debug.Log("hit" + i);
                }
            }
            /*else
            {
                for (int i = 0; i < SphereHit.Length; i++)
                {
                    currentHitObject[i] = SphereHit[i].transform.gameObject;
                    currentHitDistance[i] = SphereHit[i].distance;
                }
            }*/
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (currentHitObject.Length > 0 && Input.GetMouseButton(0))
        {
            for (int i = 0; i < currentHitObject.Length; i++)
            {
                Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), direction[i]);
                Gizmos.DrawWireSphere(direction[i], SphereRadius);
            }
        }
    }
}
