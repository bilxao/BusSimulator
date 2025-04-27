using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
	public GameObject buscube;
	public GameObject person1;
	public GameObject person2;
	public GameObject person3;
	public bool saudbool;


	// Use this for initialization
	void Start ()
	{
		saudbool = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (StandLightScript.reached) {
			if (saudbool)
			{

				person1.GetComponent<Animation> ().Play("walk");
				person2.GetComponent<Animation> ().Play("walk");
				person3.GetComponent<Animation> ().Play("walk");
				saudbool = false;
			}
			//passenegersscript.personscamera.SetActive (true);
			transform.position = Vector3.MoveTowards (transform.position, buscube.transform.position, 1.0f * Time.deltaTime);
			
		}

	}

}
