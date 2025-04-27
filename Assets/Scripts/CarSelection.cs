using UnityEngine;
using System.Collections;
using admob;
//---------------------- Rewarded Video Class ------------------------------
using StartApp;

public class VideoListenerImplementation : StartAppWrapper.VideoListener 
{
	public void onVideoCompleted()
	{
		PlayerPrefs.SetInt ("unlock1", 1);
		PlayerPrefs.SetInt ("unlock2", 2);
		PlayerPrefs.SetInt ("unlock3", 3);
	}

}

//---------------------  Rewarded Video Class End  ------------------------


public class CarSelection : MonoBehaviour {

	public GameObject[] cars;
	public int currentIndex;
	bool nextPressed;
	public GameObject controlselection;
	public  GameObject lock1;
	public bool lock1check;
	public bool lock2check;
	public bool lock3check;
	public  GameObject lock2;
	public  GameObject lock3;
	public  GameObject selectbuttton;
	// Use this for initialization
	void Start ()
	{
		Time.timeScale=1;
		AudioListener.pause = false;
		//---------------------  Start ()  start ------------------------

		//Rewarded Video
		VideoListenerImplementation videoListener = new VideoListenerImplementation ();
		StartAppWrapper.setVideoListener (videoListener);
		StartAppWrapper.loadAd(StartAppWrapper.AdMode.REWARDED_VIDEO);

		//---------------------  Start ()  end -----------------------------------------

		lock1check = false;
		lock2check = false;
		lock3check = false;
		selectbuttton.SetActive (true);
		controlselection.SetActive (false);
		currentIndex = 0;
		nextPressed = false;
		foreach (var item in cars) {
			item.SetActive (false);
		}

		cars [currentIndex].SetActive (true);
	}

	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetInt ("unlock1") == 1) 
		{
			lock1.SetActive (false);
			lock2.SetActive (false);
			lock3.SetActive (false);
			selectbuttton.SetActive (true);
		}

		if (!mainmenu.OnBus) 
		{

			if (nextPressed) {
				Invoke ("waitnew", 1);
				foreach (var item in cars) {
					item.SetActive (false);
				}
				if (currentIndex == 0) {
					selectbuttton.SetActive (true);
					cars [currentIndex].SetActive (true);
					lock1.SetActive (false);
					lock2.SetActive (false);
					lock3.SetActive (false);
				}
				if (currentIndex == 1) {

					if (PlayerPrefs.GetInt ("unlock1") != 1)
					{
						lock1check = true;
						lock1.SetActive (true);
						cars [currentIndex].SetActive (true);
						selectbuttton.SetActive (false);
					} else {
						lock1check = false;
						lock2check = false;
						lock3check = false;
						lock1.SetActive (false);
						cars [currentIndex].SetActive (true);
						selectbuttton.SetActive (true);

					}
					lock2.SetActive (false);
					lock3.SetActive (false);
				}
				if (currentIndex == 2) {
					if (PlayerPrefs.GetInt ("unlock2") != 2) {
						lock2check = true;
						lock2.SetActive (true);
						cars [currentIndex].SetActive (true);
						selectbuttton.SetActive (false);
					} else {
						lock2check = false;
						lock1check = false;
						lock3check = false;
						lock2.SetActive (false);
						cars [currentIndex].SetActive (true);
						selectbuttton.SetActive (true);
						selectbuttton.SetActive (true);

					}
					lock1.SetActive (false);
					lock3.SetActive (false);
				}
				if (currentIndex == 3) {
					if (PlayerPrefs.GetInt ("unlock3") != 3) {
						lock3.SetActive (true);
						lock3check = true;
						cars [currentIndex].SetActive (true);
						selectbuttton.SetActive (false);
					} else {
						lock3check = false;
						lock2check = false;
						lock1check = false;
						lock3.SetActive (false);
						cars [currentIndex].SetActive (true);
						selectbuttton.SetActive (true);


					}
					lock2.SetActive (false);
					lock1.SetActive (false);
				}

				nextPressed = false;
			}
		}
	}

	public void Next()
	{
		nextPressed = true;
		mainmenu.OnBus = false;
		if (currentIndex < cars.Length-1) {
			currentIndex++;
		} 
		else {
			currentIndex = 0;
		}
	}
	public void Previous()
	{
		nextPressed = true;
		mainmenu.OnBus = false;
		if (currentIndex < cars.Length - 1) {
			currentIndex--;
			if (currentIndex < 0) {
				currentIndex = 3;
			}
		} else if (currentIndex == cars.Length - 1) {
			currentIndex--;
		}
	}

	public void Select()
	{
		//small size
		PlayerPrefs.SetInt ("BusNo", currentIndex);
		mainmenu.OnBus=true;
		Admob.Instance ().removeBanner ("busselection");
		Admob.Instance ().showBannerRelative (new AdSize (550,90), AdPosition.TOP_CENTER, 0, "controlselection");
		controlselection.SetActive (true);
	}
	public void waitnew()
	{
	}
	public void back()
	{
		GUIManager.OnMain = true;
		Admob.Instance ().removeBanner ("busselection");
		Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "mainmenu1");	
		Application.LoadLevel (0);	
	}
	public void FreeVideos()
	{
		StartAppWrapper.showAd();
		StartAppWrapper.loadAd(StartAppWrapper.AdMode.REWARDED_VIDEO);
	}
}
