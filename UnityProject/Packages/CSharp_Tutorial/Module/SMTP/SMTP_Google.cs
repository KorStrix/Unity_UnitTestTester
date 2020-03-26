#region Header
/*	============================================
 *	Aurthor 			    : Strix
 *	Initial Creation Date 	: 2020-03-24
 *	Summary 		        : 
 *	
 *	코드를 사용하기 전
 *	구글 계정은 엑세스 허가가 되지 않은 앱에서 로그인을 막기 때문에
 *	여기서 엑세스 허가가 필요 없는 비밀번호를 발급받은 후
 *	그 비밀번호를 세팅해야 함
 *	https://security.google.com/settings/security/apppasswords
 *	
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
/// 구글에 Email을 보내는 클래스입니다.
/// 사용하기 전 Header를 참고 바랍니다.
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
        /// 보내는 사람
        /// </summary>
		public string strEmail_From;

		/// <summary>
		/// 보내는 사람 비밀번호
		/// </summary>
		public string strPassword;

		/// <summary>
		/// 받는 사람
		/// </summary>
		public string[] arrEmail_To;
	}

	MailInfo _pMailInfo;

	SmtpClient _pSMTP_Client;
	string _strLogFolderPath;



	public SMTP_Google(MailInfo pMailInfo)
	{
		_pMailInfo = pMailInfo;

		_pSMTP_Client = Init_SMTPClient();
		_strLogFolderPath = Application.persistentDataPath + "/Log";
	}

	// ========================================================================================================================


	public IEnumerator DoSendMail_WithLogFile_Coroutine(string strMailTitle, string strMailBody, string strLogFilename)
	{
		yield return SaveLog_Coroutine(strLogFilename);

		string strPath_txt = string.Format("{0}/{1}.txt", _strLogFolderPath, strLogFilename);
		FileInfo pFileInfo = new FileInfo(strPath_txt);
		if (pFileInfo == null)
		{
			yield break;
		}

		string strFileSize = (pFileInfo.Length / 1024) + "KB";

		Debug.Log($"Send Email Size : {strFileSize} // FilePath : {strPath_txt}");
		yield return null;

		try
		{
			SendEmail(strMailTitle, strMailBody, strPath_txt);
			Debug.Log("Send Email Complete.");

			try
			{
				File.Delete(strPath_txt);
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
		if (System.IO.Directory.Exists(_strLogFolderPath) == false)
			System.IO.Directory.CreateDirectory(_strLogFolderPath);

		using (System.IO.FileStream pFileStream = new System.IO.FileStream(strLogFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
		using (System.IO.StreamWriter pWriter = new System.IO.StreamWriter(pFileStream))
		{
			pWriter.WriteLine("Test_Line_1");
			pWriter.WriteLine("Test_Line_2");
		}


		Debug.Log("Save Log Done.");

		yield break;
	}

	void SendEmail(string strMailTitle, string strMailBody, string strFilePath)
	{
		MailMessage pMail = CreateMail(strMailTitle, strMailBody);

		// 첨부파일 - 대용량은 안됨.
		if (string.IsNullOrEmpty(strFilePath) == false)
		{
			System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(strFilePath);
			pMail.Attachments.Add(attachment);
		}
		ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

		_pSMTP_Client.Send(pMail);
		pMail.Attachments.Dispose();
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
		pSMTPClient.Credentials = new System.Net.NetworkCredential(_pMailInfo.strEmail_From, _pMailInfo.strPassword);

		// 보내는사람 주소 및 비밀번호 확인
		System.Net.ServicePointManager.Expect100Continue = false;

		pSMTPClient.EnableSsl = true;

		return pSMTPClient;
	}
}
