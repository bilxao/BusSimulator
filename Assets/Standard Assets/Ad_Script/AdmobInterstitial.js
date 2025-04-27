#pragma strict

public class AdmobInterstitial extends MonoBehaviour {
    private static var s_Controller : AdmobInterstitial;
    private static var jo:AndroidJavaObject;
    private static var iTime = 0;
    public static var InterUnit_Id : String="ca-app-pub-7508147665621899/6617547166";
    var bol_ :boolean=true;
    function Awake()
    {
        s_Controller = this;
        #if UNITY_ANDROID    
		jo = new AndroidJavaObject("com.example.googleplayplugin.playads");
		jo.Call("playintads",InterUnit_Id);
		#endif
	
	
    }
    

    
    function Update()
    {
    	if(jo.Call.<boolean>("isInterstitialLoaded") && bol_)
    	{
    			bol_=false;
    			jo.Call("displayInterstitial");

    	}
    }
}