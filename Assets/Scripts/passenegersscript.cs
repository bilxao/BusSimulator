using UnityEngine;
using System.Collections;

public class passenegersscript : MonoBehaviour {
	public GameObject person;

	//public GameObject newcam;
	// Use this for initialization
	void Start () {
	//	newcam.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (StandLightScript.reached)
//		{
//			newcam.SetActive (true);
//		}
	
	}
	void OnTriggerEnter(Collider col)
	{
		
		if (col.tag == "Finish")
		{
			
			person.SetActive (false);
			//newcam.SetActive (false);

		}
		
	}
}
