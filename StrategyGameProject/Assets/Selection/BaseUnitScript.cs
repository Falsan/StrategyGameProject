using UnityEngine;
using System.Collections;

public class BaseUnitScript : MonoBehaviour {

    Vector3 targetToMoveTo;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Move(Vector3 Location)
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Location);
        if (Physics.Raycast(ray, out hit))
        {
            targetToMoveTo = hit.point;
            
        }

        //targetToMoveTo.y = gameObject.transform.position.y;

        rb.MovePosition(targetToMoveTo);


    }
}
