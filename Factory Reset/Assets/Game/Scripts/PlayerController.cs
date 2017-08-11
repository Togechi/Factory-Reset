using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15f; 
	
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

	}
	
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        transform.position += Vector3.right * speed * Time.deltaTime;
		}
}
