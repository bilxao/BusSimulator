using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using StartApp;
//using Heyzap;
//bus wali game
using admob;

public class completelevel : MonoBehaviour {
	bool adBool;

	public GameObject personinsidebus;
	public GameObject newcam2;
	public GameObject greenlight;
	public static bool reached2;
	public GameObject busnew2;
	public GameObject LevelCompletePanel;
	public static bool completedlevel;


	// Use this for initialization
	void Start ()
	{
		//-------------------------     Ads   -------------------------------------------
		// Unity
		Advertisement.Initialize ("1247675");

		// Add Mob
		Admob.Instance().initAdmob("ca-app-pub-9698930307418557/9303037319","ca-app-pub-9698930307418557/8860024824");
		Admob.Instance ().loadInterstitial ();
		//StartApp
		StartAppWrapper.init ();
		StartAppWrapper.loadAd ();

		// HeyZapp
		HeyzapAds.start ("285d75db3424d70b22f014f163cc466d", HeyzapAds.FLAG_NO_OPTIONS);
		HZInterstitialAd.fetch ();
		//-------------------------     Ads   -------------------------------------------

		adBool=true;
		newcam2.SetActive (false);
		completedlevel = false;
		AudioListener.pause = false;
	
	}

	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			personinsidebus.SetActive (true);
			reached2 = true;
			greenlight.SetActive (false);		
			newcam2.SetActive (true);
			personinsidebus.SetActive (true);
			busnew2.GetComponent<Rigidbody> ().isKinematic = true;
			Invoke("wait1",5);

		}
		
	}
	public void wait1()
	{
		newcam2.SetActive (false);
		reached2 = false;
		busnew2.GetComponent<Rigidbody> ().isKinematic = false;
		personinsidebus.SetActive (false);
		Invoke("wait2",1);
	}
	public void wait2()
	{
		Time.timeScale = 0f;
		GUIManager.bt = true;
		completedlevel = true;
		AudioListener.pause = true;
		GUIManager.iscomplete = true;
		Admob.Instance ().removeNativeBanner ("gamePlay");
		if(adBool)
		{
			if (adBool)
			{
				StartAppWrapper.showAd ();
				StartAppWrapper.loadAd ();
				adBool = false;

			}
			else if (Advertisement.IsReady ())
			{
				Advertisement.Show ();
				adBool = false;

			}

			else if (HZInterstitialAd.isAvailable ()) 
			{
				HZInterstitialAd.show ();
				HZInterstitialAd.fetch ();
				adBool = false;
			}
			else
			{}

		}
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.MIDDLE_LEFT, 0, "pauseadd");	
		LevelCompletePanel.SetActive (true);
		if (completedlevel)
		{
			switch (Application.loadedLevel) {
			case 2:
				PlayerPrefs.SetInt ("level1", 1);
				break;
			case 3:
				PlayerPrefs.SetInt ("level2", 2);
				break;
			case 4:
				PlayerPrefs.SetInt ("level3", 3);
				break;
			case 5:
				PlayerPrefs.SetInt ("level4", 4);
				break;
			case 6:
				PlayerPrefs.SetInt ("level5", 5);
				break;
			case 7:
				PlayerPrefs.SetInt ("level6", 6);
				break;
			case 8:
				PlayerPrefs.SetInt ("level7", 7);
				break;
			case 9:
				PlayerPrefs.SetInt ("level8", 8);
				break;
			case 10:
				PlayerPrefs.SetInt ("level9", 9);
				break;
			case 11:
				PlayerPrefs.SetInt ("level10", 10);
				break;
			}


		}

	}
}
