using UnityEngine;
using System.Collections;
using System;
using admob;
//bus wali game
using StartApp;

public class mainmenu : MonoBehaviour {
	float loadtime;
	public GameObject loadingpanel;
	public GameObject quitpanel;
	public GameObject steeringControlBtn, buttonsControlBtn, tiltControlBtn;
	public bool isPressed = false;
	public static bool steering,tilt;
	public GameObject steeringpanel;
	bool splashadbool=true;
	public GameObject policypanel;
	public GameObject declinepanel;
	public GameObject busSelection;
	public static bool OnBus; 
	public GameObject policy_button;



	bool adBool;
	// Use this for initialization

	void Start ()
	{
		OnBus = false;
		//-------------------------     Ads   -------------------------------------------

		// Add Mob
		Admob.Instance().initAdmob("ca-app-pub-9698930307418557/2162913890","ca-app-pub-9698930307418557/8860024824");
		Admob.Instance ().loadInterstitial ();


		//----------------------   Ads   --------------------------------------------
		Time.timeScale=1;
		quitpanel.SetActive (false);


		steeringControlBtn.SetActive (true);
		buttonsControlBtn.SetActive (true);
		tiltControlBtn.SetActive (true);

		//StartApp
		StartAppWrapper.init ();
		StartAppWrapper.loadAd ();
		Invoke ("addwait", 2.5f);


		adBool = true;
		if (GUIManager.OnMain)
		{
			loadtime = 5;
			loadingpanel.SetActive (true);
			Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "mainmenu1");

			//Invoke ("addwait2", 4);
		}
		else
		{
			loadtime =2.5f;
			loadingpanel.SetActive (false);
			StartAppWrapper.showSplash ();
		}

	}

	// Update is called once per frame
	void Update ()
	{
		if (OnBus)
		{
			busSelection.SetActive (false);
		}
		//------------------------    Update()   ---------------------------------- 

		if (PlayerPrefs.GetInt ("policy") == 1) 
		{
			policypanel.SetActive (false);
			policy_button.SetActive (false);
		} 

		//------------------------    Update()   ---------------------------------- 

		if (PlayerPrefs.GetInt ("policy") == 1) 
		{
			policypanel.SetActive (false);
		} 

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Admob.Instance ().removeNativeBanner ("loading1");
			Admob.Instance ().removeNativeBanner ("loading2");
			Admob.Instance ().removeNativeBanner ("mainmenu1");
			Admob.Instance ().removeNativeBanner ("main");
			quitpanel.SetActive (true);

		}
		loadtime -= Time.deltaTime;

		if (loadtime > 0)
		{
			if (Admob.Instance ().isInterstitialReady ()) 
			{
				Admob.Instance ().showInterstitial ();
				GUIManager.OnMain = false;
			}
		}

		if (loadtime <= 0) 
		{
			loadingpanel.SetActive (false);
		}

  }
	public void addwait()
	{
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "mainmenu1");	
	}

  public void OnPlay()
	{
		Admob.Instance ().removeBanner ("mainmenu1");
		Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.BOTTOM_LEFT, 0, "busselection");
		busSelection.SetActive (true);
	}
	public void policy_click()
	{
		Admob.Instance ().removeBanner ("mainmenu1");
		policypanel.SetActive (true);
	}
	public void OnMore()
	{
		Application.OpenURL("http://play.google.com/store/apps/developer?id=AspireSoft+Tech");
	}
	public void OnRate()
	{
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.litestudios.drive.Tourist.Bus.offroad.simulator.apps");
	}
	public void OnExit()
	{
		Application.Quit();
	}
	void AdClosed(object obj,EventArgs args)
	{
		loadtime = -1;
	}

	public void ControllerOptions()
	    {
		        isPressed = !isPressed;

		        if (isPressed) {
			            steeringControlBtn.SetActive (true);
			            buttonsControlBtn.SetActive (true);
			            tiltControlBtn.SetActive (true);
			        }
		        if (!isPressed) {
			            steeringControlBtn.SetActive (false);
			            buttonsControlBtn.SetActive (false);
			            tiltControlBtn.SetActive (false);
			        }
		    }

	    public void SteerringControl()
	    {
		        steeringControlBtn.SetActive (true);
		        buttonsControlBtn.SetActive (false);
		        tiltControlBtn.SetActive (false);
		        isPressed = false;
		        PlayerPrefs.SetInt ("ControllerType", 2);
	         	Admob.Instance ().removeBanner ("controlselection");
	        	Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.TOP_LEFT, 0, "levelselectiontop");
	         	Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.BOTTOM_RIGHT, 0, "levelselectionbottom");
		        Application.LoadLevel (1);

		    }

	    public void ButtonControl()
	    {

		        steeringControlBtn.SetActive (false);
		        buttonsControlBtn.SetActive (true);
		        tiltControlBtn.SetActive (false);
		        isPressed = false;
		        PlayerPrefs.SetInt ("ControllerType", 0);
	         	Admob.Instance ().removeBanner ("controlselection");
		       Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.TOP_LEFT, 0, "levelselectiontop");
	        	Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.BOTTOM_RIGHT, 0, "levelselectionbottom");

		        Application.LoadLevel (1);
		    }
	    public void tileControl()
	    {
		        steeringControlBtn.SetActive (false);
		        buttonsControlBtn.SetActive (false);
		        tiltControlBtn.SetActive (true);
		        isPressed = false;
		        PlayerPrefs.SetInt ("ControllerType", 1);
		        Admob.Instance ().removeBanner ("controlselection");
		        Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.TOP_LEFT, 0, "levelselectiontop");
	        	Admob.Instance ().showBannerRelative (new AdSize (468, 60), AdPosition.BOTTOM_RIGHT, 0, "levelselectionbottom");

		        Application.LoadLevel (1);
		    }

	public void accept()
	{
		policypanel.SetActive (false);
		policy_button.SetActive (false);
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "mainmenu1");
		PlayerPrefs.SetInt ("policy", 1);
	}

	public void decline()
	{
		PlayerPrefs.SetInt ("policy", 0);
	}

	public void ok()
	{
		declinepanel.SetActive (false);
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "mainmenu1");
	}

	//------------------------    Functions   ---------------------------------- 

	public void link()
	{
		Application.OpenURL ("https://litestudios.blogspot.com/p/privacy-policy.html");
	}





}
