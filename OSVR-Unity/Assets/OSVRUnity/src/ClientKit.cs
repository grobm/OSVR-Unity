﻿using UnityEngine;

namespace OSVR
{
	namespace Unity
	{
		public class ClientKit : MonoBehaviour
		{
			public string AppID;

			private OSVR.ClientKit.ClientContext context;

			public OSVR.ClientKit.ClientContext GetContext()
			{
				if (context == null) {
					if (0 == AppID.Length) {
						Debug.LogError("OSVR ClientKit instance needs AppID set to a reverse-order DNS name! Using dummy name...");
						AppID = "org.opengoggles.osvr-unity.dummy";
					}
					Debug.Log ("Starting OSVR with app ID: " + AppID);
					context = new OSVR.ClientKit.ClientContext (AppID, 0);
				}
				return context;
			}

			static ClientKit ()
			{
				DLLSearchPathFixer.fix ();
			}

			void Start()
			{
				GetContext();
			}

			void FixedUpdate ()
			{
				context.update ();
			}
		}
	}
}