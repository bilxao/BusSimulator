using UnityEngine;
using System.Collections;
//buswali game
using admob;


public class LevelManager : MonoBehaviour {
	public GameObject lock2, lock3,lock4,lock5,lock6,lock7,lock8,lock9,lock10;
	public static bool restart = false;
	public GameObject loading;
	public static bool levelload;
	// Use this for initialization
	void Start ()
	{
		levelload = false;
		loading.SetActive (false);
		restart = false;
	}

	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt ("level1") == 1)
		{
			lock2.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level2") == 2)
		{
			lock3.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level3") == 3)
		{
			lock4.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level4") == 4)
		{
			lock5.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level5") == 5)
		{
			lock6.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level6") == 6)
		{
			lock7.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level7") == 7)
		{
			lock8.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level8") == 8)
		{
			lock9.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level9") == 9)
		{
			lock10.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level10") == 10)
		{
		}

	}
	public void InLevelOne()
	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}
		Application.LoadLevel ("Level1");
	}

	public void InLevelTwo()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level2");

	}

	public void InLevelThree()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level3");

	}

	public void InLevelFour()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level4");

	}

	public void InLevelFive()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level5");

	}

	public void InLevelSix()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level6");

	}

	public void InLevelSeven()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level7");

	}

	public void InLevelEight()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level8");

	}
	public void InLevelNine()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}

		Application.LoadLevel ("Level9");

	}
	public void InLevelTen()

	{
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "loadinglevel");	
		levelload = true;
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}
		Application.LoadLevel ("Level10");

	}
	public void OnMainmenu()

	{
		GUIManager.OnMain = true;
		restart = false;
		Time.timeScale = 1f;
		loading.SetActive (true);
		Admob.Instance ().removeBanner ("levelselectiontop");
		Admob.Instance ().removeBanner ("levelselectionbottom");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "mainmenu1");	
		Application.LoadLevel (0);

	}

}
