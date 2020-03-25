#region Header
/*	============================================
 *	Aurthor 			    : Strix
 *	Initial Creation Date 	: 2020-03-24
 *	Summary 		        : 
 *  Template 		        : For Unity Editor V1
   ============================================ */
#endregion Header

using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;

/// <summary>
/// 구글에 Email을 보내는 클래스입니다
/// </summary>
public class SMTP_Google
{
	/// <summary>
    /// 이메일 정보
    /// </summary>
	[System.Serializable]
	public class MailInfo
    {
		/// <summary>
        /// 받는 사람
        /// </summary>
		public string strEmail_From;

		/// <summary>
        /// 보내는 사람
        /// </summary>
		public string[] arrEmail_To;
	}

	/// <summary>
    /// SMTP 자격증
    /// </summary>
	[System.Serializable]
	public class NetworkCredential
    {
		public string strEmail;
		public string strPassword;
	}

	MailInfo _pMailInfo;
	NetworkCredential _pCredential;

	SmtpClient _pSMTP_Client;
	string _strLogFolderPath;



	public SMTP_Google(MailInfo pMailInfo, NetworkCredential pCredential)
	{
		_pMailInfo = pMailInfo;
		_pCredential = pCredential;

		_pSMTP_Client = Init_SMTPClient();
		_strLogFolderPath = Application.persistentDataPath + "/Log";

		ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
	}

	// ========================================================================================================================


	public IEnumerator DoSendMail_WithLogFile_Coroutine(string strMailTitle, string strMailBody, string strLogFilename)
	{
		yield return SaveLog_Coroutine(strLogFilename);

		string strPath_txt = string.Format("{0}/{1}.txt", _strLogFolderPath, strLogFilename);
		string strPath_zip = string.Format("{0}/{1}.zip", _strLogFolderPath, strLogFilename);

		FileInfo pZipFileInfo = GetZipFileInfo(strPath_txt, strPath_zip);
		if (pZipFileInfo == null)
		{
			yield break;
		}

		string strFileSize = (pZipFileInfo.Length / 1024) + "KB";

		Debug.Log($"Send Email Size : {strFileSize} // FilePath : {strPath_zip}");
		yield return null;

		try
		{
			SendEmail(strMailTitle, strMailBody, strPath_zip);
			Debug.Log("Send Email Complete.");

			try
			{
				File.Delete(strPath_zip);
			}
			catch (System.Exception e)
			{
				Debug.LogError("Delete Zip2 Exception :" + e.ToString());
			}
		}
		catch (System.Exception e)
		{
			Debug.Log("Send Email Error \n" + e.ToString());
		}
	}

	// ========================================================================================================================

	IEnumerator SaveLog_Coroutine(string strFileName)
	{
		if (string.IsNullOrEmpty(strFileName))
			strFileName = SystemInfo.deviceUniqueIdentifier;
		string strLogFilePath = string.Format("{0}/{1}.txt", _strLogFolderPath, strFileName);

		Debug.Log("SaveLog: path:" + strLogFilePath);
		if (!System.IO.Directory.Exists(_strLogFolderPath))
		{
			System.IO.Directory.CreateDirectory(_strLogFolderPath);
		}

		using (System.IO.FileStream fs = new System.IO.FileStream(strLogFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
		using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fs))
		{
			writer.WriteLine("Test_Line_1");
			writer.WriteLine("Test_Line_2");
		}


		Debug.Log("Save Log Done.");

		yield break;
	}

	void SendEmail(string strMailTitle, string strMailBody, string filepath)
	{
		MailMessage pMail = CreateMail(strMailTitle, strMailBody);

		// 첨부파일 - 대용량은 안됨.
		if (filepath != "")
		{
			System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(filepath);
			pMail.Attachments.Add(attachment);
		}

		_pSMTP_Client.Send(pMail);
		pMail.Attachments.Dispose();
	}

	FileInfo GetZipFileInfo(string strPath_txt, string strPath_zip)
	{
		try
		{
			if (File.Exists(strPath_zip))
				File.Delete(strPath_zip);
		}
		catch (System.Exception e)
		{
			Debug.LogError("Delete Zip1 Exception :" + e.ToString());
		}

		using (var pZipFile = new Ionic.Zip.ZipFile())
		{
			pZipFile.AddFile(strPath_txt);
			pZipFile.Save(strPath_zip);
		}

		return new FileInfo(strPath_zip);
	}

	MailMessage CreateMail(string strMailTitle, string strMailBody)
	{
		MailMessage pMail = new MailMessage();
		pMail.From = new MailAddress(_pMailInfo.strEmail_From);

		foreach(var pMember in _pMailInfo.arrEmail_To)
			pMail.To.Add(pMember);

		if (string.IsNullOrEmpty(strMailTitle))
			strMailTitle = "Empty Mail Title";
		pMail.Subject = strMailTitle;

		if (string.IsNullOrEmpty(strMailBody))
			strMailTitle = "Empty Mail Body";
		pMail.Body = strMailBody;
		return pMail;
	}

	SmtpClient Init_SMTPClient()
    {
		SmtpClient pSMTPClient = new SmtpClient("smtp.gmail.com");
		pSMTPClient.Port = 587;
		pSMTPClient.UseDefaultCredentials = false;
		pSMTPClient.Credentials = new System.Net.NetworkCredential(_pCredential.strEmail, _pCredential.strPassword) as ICredentialsByHost; // 보내는사람 주소 및 비밀번호 확인
																																		   //System.Net.ServicePointManager.Expect100Continue = false;
		pSMTPClient.EnableSsl = true;

		return pSMTPClient;
	}
}
