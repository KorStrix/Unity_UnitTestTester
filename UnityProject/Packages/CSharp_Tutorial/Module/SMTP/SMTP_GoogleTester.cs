#region Header
/*	============================================
 *	Author   			    : Strix
 *	Initial Creation Date 	: 2020-03-25
 *	Summary 		        : 
 *  Template 		        : For Unity Editor V1
   ============================================ */
#endregion Header

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public class SMTP_GoogleTester : MonoBehaviour
{
	/* const & readonly declaration             */

	/* enum & struct declaration                */

	/* public - Field declaration               */

	public SMTP_Google.MailInfo pMailInfo = new SMTP_Google.MailInfo() { strEmail_From = "korstrix@gmail.com", arrEmail_To = new string[] { "korstrix@gmail.com" } };

	public string strMailTitle;
	public string strMailBody;
	public string strLogFileName;

	/* protected & private - Field declaration  */


	// ========================================================================== //

	/* public - [Do~Something] Function 	        */

	public void DoSendMail_WithLogFile()
	{
		iTest = 5;

		SMTP_Google pSMTPGoogle = new SMTP_Google(pMailInfo);
		StartCoroutine(pSMTPGoogle.DoSendMail_WithLogFile_Coroutine(strMailTitle, strMailBody, strLogFileName, GetLog));
	}

	// ========================================================================== //

	/* protected - [Override & Unity API]       */


	/* protected - [abstract & virtual]         */


	// ========================================================================== //

	#region Private

	int iTest = 5;

	string GetLog(out bool bIsFinish)
	{
		bIsFinish = iTest < 0;

		return "GetLog Test " + iTest--;
	}

	#endregion Private
}

#if UNITY_EDITOR

[CustomEditor(typeof(SMTP_GoogleTester))]
public class SMTP_GoogleTester_Inspector : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SMTP_GoogleTester pTarget = target as SMTP_GoogleTester;

		if (GUILayout.Button(nameof(pTarget.DoSendMail_WithLogFile)))
		{
			pTarget.DoSendMail_WithLogFile();
		}
	}
}

#endif