using UnityEngine;
using System.Collections;

public class StandLightScript : MonoBehaviour {
	public GameObject greenbuff;
	public static bool checkpersoninsidebus;
	public GameObject busnew;
	public static bool reached;
	public GameObject newcam;
	// Use this for initialization
	void Start () 
	{
		checkpersoninsidebus = false;
		reached = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			newcam.SetActive (true);
			reached = true;
			greenbuff.SetActive (false);
			busnew.GetComponent<Rigidbody> ().isKinematic = true;
			Invoke ("wait", 8);
		
		}

		
	}
	public void wait()
	{
		newcam.SetActive (false);
		busnew.GetComponent<Rigidbody> ().isKinematic = false;
	}
}
