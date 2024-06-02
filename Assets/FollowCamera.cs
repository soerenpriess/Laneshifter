using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform FollowObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update ()
	{
		Vector3 pos = new Vector3(FollowObject.position.x, transform.position.y, transform.position.z);
		transform.position = pos;
	}
}
