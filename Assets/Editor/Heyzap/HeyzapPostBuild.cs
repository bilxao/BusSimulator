using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.IO;
using System.Diagnostics;

public class HeyzapPostBuild : MonoBehaviour
{

	[PostProcessBuild(101)]
	private static void onPostProcessBuildPlayer( BuildTarget target, string pathToBuiltProject )
	{
		if (target == BuildTarget.iOS) {
			UnityEngine.Debug.Log ("Heyzap: started post-build script");

			// grab the path to the postProcessor.py file
			var scriptPath = Path.Combine( Application.dataPath, "Editor/Heyzap/HeyzapPostprocessBuildPlayer.py" );
			
			// sanity check
			if( !File.Exists( scriptPath ) ) {
				UnityEngine.Debug.LogError( "HZ post builder couldn't find python file. Did you accidentally delete it?" );
				return;
			} else {
				var args = string.Format( "\"{0}\" \"{1}\"", scriptPath, pathToBuiltProject );
				var proc = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = "python2.6",
						Arguments = args,
						UseShellExecute = false,
						RedirectStandardOutput = true,
						CreateNoWindow = true
					}
				};
				
				proc.Start();
				proc.WaitForExit();
				
				UnityEngine.Debug.Log( "Heyzap: Finished post-build script" );
			}
		}
	}
}