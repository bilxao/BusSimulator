using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using StartApp;
using System;
using admob;
//Bus wali game

public class GUIManager : MonoBehaviour 
{
	public static bool Steering, tilt;
	public GameObject playerCar;
	public GameObject failpanel;
	public GameObject gas;
	public GameObject breakbus;
	public GameObject left;
	public GameObject right;
	public GameObject pausebutton;
	public static bool bt;
	public GameObject pausepanel;
	float loadtime;
	public GameObject loadingpanel;
	bool adBool;
	public float timer;
	public Text timetext;
	public bool checktimer;
	public static bool iswheel=false;
	public static bool ispause=false;
	public  static bool isfailed=false;
	public static bool iscomplete = false;
	bool adBool1;
	public static bool OnMain;
	public GameObject Grey1;
	public GameObject Yellow2;
	public GameObject Red3;
	public GameObject Blue4;
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
		OnMain=false;
		Time.timeScale = 1;
		Admob.Instance ().removeNativeBanner ("controlselection");
		iscomplete = false;
		ispause = false;
		isfailed = false;
		iswheel = false;
		AudioListener.pause = false;
		bt = false;
		checktimer = false;

		        if (PlayerPrefs.GetInt ("ControllerType") == 0) {
			            playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = false;
			            playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl= false;
			        }
		        else if (PlayerPrefs.GetInt ("ControllerType") == 1) {

			            playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = true;
			            playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl= false;
			        }
		        else if (PlayerPrefs.GetInt ("ControllerType") == 2) 
			        {
			            playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = false;
			            playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl= false;
			        }

		if (PlayerPrefs.GetInt ("BusNo") == 0)
		{
			Grey1.SetActive (true);
			Yellow2.SetActive (false);
			Red3.SetActive (false);
			Blue4.SetActive (false);

		} 
		else if (PlayerPrefs.GetInt ("BusNo") == 1)
		{
			Grey1.SetActive (false);
			Yellow2.SetActive (true);
			Red3.SetActive (false);
			Blue4.SetActive (false);

		}
		else if (PlayerPrefs.GetInt ("BusNo") == 2)
		{
			Grey1.SetActive (false);
			Yellow2.SetActive (false);
			Red3.SetActive (true);
			Blue4.SetActive (false);

		}
		else if (PlayerPrefs.GetInt ("BusNo") == 3) 
		{
			Grey1.SetActive (false);
			Yellow2.SetActive (false);
			Red3.SetActive (false);
			Blue4.SetActive (true);

		}
		else 
		{
			
		}
		if (LevelManager.levelload) {   
			loadtime = 1.5f;
			Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
			Invoke ("addwait", 0.5f);
		}
		else 
		{
			loadtime = 4.5f;
			Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
			Invoke ("addwait", 3.5f);

		}
		adBool1 = true;
		adBool = true;
		loadingpanel.SetActive (true);
	}

	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		int a = (int)timer;
		timetext.text = a.ToString ();
		if (timer <= 0)
		{
			if (!checktimer) 
			{
				Time.timeScale = 0f;
				bt = true;
				Admob.Instance ().removeBanner ("gamePlay");
				Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.MIDDLE_LEFT, 0, "pauseadd");	
				AudioListener.pause = true;
				failpanel.SetActive (true);
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			bt = true;
			Time.timeScale = 0f;
			Admob.Instance ().removeBanner ("gamePlay");
			AudioListener.pause = true;
			pausepanel.SetActive (true);

		}
		if (bt) 
		{
			pausebutton.SetActive (false);
			gas.SetActive (false);
			breakbus.SetActive (false);
			left.SetActive (false);
			right.SetActive (false);
		}
		loadtime -= Time.deltaTime;
		if (loadtime > 0)
		{
			loadingpanel.SetActive (true);
			if (adBool1) 
			{
				if (Admob.Instance ().isInterstitialReady ())
				{
					Admob.Instance ().showInterstitial ();
					adBool1 = false;
				}
			}

		}

		if (loadtime <= 0) 
		{
			loadingpanel.SetActive (false);
			iswheel = true;
		}
		if (PlayerPrefs.GetInt ("ControllerType") == 2) 
		{
			if (iswheel) {
				playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = false;
				playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl = true;

			} 
			else
			{
				playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = false;
				playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl = false;
			}
		}
		if (PlayerPrefs.GetInt ("ControllerType") == 2) {
			if (ispause) {
				playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = false;
				playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl = false;

			} 
		}
		if (PlayerPrefs.GetInt ("ControllerType") == 2) 
		{
			if (isfailed) {
				playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = false;
				playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl = false;

			} 
		}
		if (PlayerPrefs.GetInt ("ControllerType") == 2) 
		{
			if (iscomplete) {
				playerCar.GetComponent<RCCCarControllerV2> ().useAccelerometerForSteer = false;
				playerCar.GetComponent<RCCCarControllerV2> ().steeringWheelControl = false;

			} 
		}
	}
	public void OnPause()
	{
		bt = true;
		ispause = true;
		iswheel = false;
		isfailed = false;
		Admob.Instance ().removeBanner ("gamePlay");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.MIDDLE_LEFT, 0, "pauseadd");	
		AudioListener.pause = true;

		if(adBool)
		{
			if (Advertisement.IsReady ())
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
			else if (adBool) 
			{
				StartAppWrapper.showSplash ();
				StartAppWrapper.loadAd ();
				adBool = false;

			}

		}


		Time.timeScale = 0f;
		pausepanel.SetActive (true);

	}
	public void OnResume()
	{
		
		//Admob.Instance().showNativeBannerRelative(new AdSize(280,80),AdPosition.TOP_CENTER,0,"ca-app-pub-9698930307418557/3285458426","gamePlay");
		Admob.Instance ().removeBanner ("pauseadd");
		ispause = false;
		bt = false;
		AudioListener.pause = false;
		pausebutton.SetActive (true);
		Time.timeScale = 1f;
		pausepanel.SetActive (false);

	}
	public void OnRestart()
	{
		//Admob.Instance().showNativeBannerRelative(new AdSize(280,80),AdPosition.TOP_CENTER,0,"ca-app-pub-9698930307418557/3285458426","gamePlay");
		LevelManager.levelload=false;
		bt = false;
		isfailed = false;
		checktimer = true;
    	LevelManager.restart = true;
		Admob.Instance ().removeBanner ("pauseadd");
		AudioListener.pause = true;
		Time.timeScale = 1f;
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		Application.LoadLevel (Application.loadedLevel);

	}
	public void OnMainmenu()
	{
		OnMain = true;
		Time.timeScale = 1f;
		loadtime = 4;
		Admob.Instance ().removeBanner ("pauseadd");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "mainmenu1");	
		Admob.Instance ().removeBanner ("gameplay");
		Application.LoadLevel (0);
	}
	public void OnNext()
	{
		Time.timeScale = 1f;
		Admob.Instance ().removeBanner ("pauseadd");
		loadtime = 4;
		Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.TOP_LEFT, 0, "levelselectiontop");
		Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.BOTTOM_RIGHT, 0, "levelselectionbottom");
		Application.LoadLevel (1);
	}
	public void OnYes()
	{
		Application.Quit();
	}
	public void OnNo()
	{
		Application.LoadLevel (0);
	}


	void AdClosed(object obj,EventArgs args)
	{
		loadtime = -1;
	}
	public void addwait()
	{
		Admob.Instance ().removeBanner ("loadinglevel");
		//Admob.Instance().showNativeBannerRelative(new AdSize(280,80),AdPosition.TOP_CENTER,0,"ca-app-pub-9698930307418557/3285458426","gamePlay");
	}
}
