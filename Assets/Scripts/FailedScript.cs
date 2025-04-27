using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using StartApp;
//using Heyzap;
//bus wali game
using admob;


public class FailedScript : MonoBehaviour {
	bool adBool;
	public GameObject failpanel;
	public GameObject gas;
	public GameObject breakbus;
	public GameObject left;
	public GameObject right;
	public GameObject pausebutton;
	public static bool bt;
	public int healthcounter=0;
	public Slider healthSlider;
	public bool onfail;


	// Use this for initialization
	void Start () 
	{
		healthSlider = GameObject.Find ("Slider").GetComponent<Slider> ();


		//-------------------------     Ads   -------------------------------------------
		// Unity
		Advertisement.Initialize ("1247675");

		// Add Mob
		Admob.Instance().initAdmob("ca-app-pub-9698930307418557/6438460003","ca-app-pub-9698930307418557/8860024824");
		Admob.Instance ().loadInterstitial ();
		//StartApp
		StartAppWrapper.init ();
		StartAppWrapper.loadAd ();

		// HeyZapp
		HeyzapAds.start ("285d75db3424d70b22f014f163cc466d", HeyzapAds.FLAG_NO_OPTIONS);
		HZInterstitialAd.fetch ();

		//-------------------------     Ads   -------------------------------------------

		adBool = true;
		onfail = false;
		healthcounter = 0;

		GUIManager.isfailed = false;
		AudioListener.pause = false;
		bt = false;
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (bt ) 
		{
			pausebutton.SetActive (false);
			gas.SetActive (false);
			breakbus.SetActive (false);
			left.SetActive (false);
			right.SetActive (false);
		}
		if (healthSlider.value == 0f) 
		{

			onfail = true;

		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			healthSlider.value = healthSlider.value - 3f;
			if (onfail)
			{
				bt = true;
				Time.timeScale = 0f;
				AudioListener.pause = true;
				GUIManager.isfailed = true;

				if(adBool)
				{

					if (HZInterstitialAd.isAvailable ()) 
					{
						HZInterstitialAd.show ();
						HZInterstitialAd.fetch ();
						adBool = false;
					}
					else if (adBool)
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
					else
					{}

				}
					
				Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.MIDDLE_LEFT, 0, "pauseadd");	
				Admob.Instance ().removeNativeBanner ("gamePlay");
				failpanel.SetActive (true);
			}
		}

	}	

}
