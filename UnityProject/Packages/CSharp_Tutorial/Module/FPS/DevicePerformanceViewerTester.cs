#region Header
/*	============================================
 *	Aurthor 			    : Strix
 *	Initial Creation Date 	: 2020-03-25
 *	Summary 		        : 
 *  Template 		        : For Unity Editor V1
   ============================================ */
#endregion Header

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Text;

/// <summary>
/// 
/// </summary>
public class DevicePerformanceViewerTester : MonoBehaviour
{
	/* const & readonly declaration             */

	/* enum & struct declaration                */

	/* public - Field declaration               */


	/* protected & private - Field declaration  */

	DevicePerformanceViewer pFPSViewer = new DevicePerformanceViewer();

	StringBuilder _pStrBuilder = new StringBuilder();

	// ========================================================================== //

	/* public - [Do~Somthing] Function 	        */

	// ========================================================================== //

	/* protected - [Override & Unity API]       */

	private void Update()
	{
		pFPSViewer.DoUpdate();
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
		GUIStyle style = new GUIStyle();
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		//			style.fontSize = h * 2 / 100;
		style.fontSize = h * 2 / 50;
		style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

		_pStrBuilder.Length = 0;
		_pStrBuilder.AppendLine(pFPSViewer.GetCPU_ElpaseTime_MicroSecond_String());
		_pStrBuilder.AppendLine(pFPSViewer.GetCPU_FPS_String());
		_pStrBuilder.AppendLine(pFPSViewer.GetCPU_MHZ_String());

		GUI.color = Color.red;
		GUI.Label(rect, _pStrBuilder.ToString(), style);
	}
	/* protected - [abstract & virtual]         */


	// ========================================================================== //

	#region Private

	#endregion Private
}