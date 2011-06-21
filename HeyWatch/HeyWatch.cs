using System;
using RestSharp;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Net;

namespace HeyWatch
{
	public class HeyWatchClient
	{
		RestClient Cli;
		JavaScriptSerializer Json;
		
		/// <summary>
		/// Create an HeyWatchClient instance
		/// </summary>
		/// <param name="Username"></param>
		/// <param name="Password"></param>
		/// <example>
		/// HeyWatchClient HeyWatch = new HeyWatchClient("username", "passwd");
		/// </example>
		public HeyWatchClient (string Username, string Password)
		{
			Cli = new RestClient("https://heywatch.com");
			Cli.Authenticator = new HttpBasicAuthenticator(Username, Password);
			Cli.AddDefaultHeader("Accept", "application/json");
			Cli.UserAgent = "HeyWatch dotnet/1.0.0";
			
			Json = new JavaScriptSerializer();
		}
		
		/// <summary>
		/// Get your account information
		/// </summary>
		/// <returns>HeyWatchAccount Instance</returns>
		/// <example>
		/// HeyWatch.Account();
		/// </example>
		
		public HeyWatchAccount Account ()
		{					
			return Json.Deserialize<HeyWatchAccount>(Request("account"));
		}
		
		
		/// <summary>
		/// Create a Download
		/// </summary>
		/// <param name="Data">A dictionary representing the POST parameters</param>
		/// <returns>HeyWatchDownload Instance</returns>
		/// <example>
		/// DownloadData = new Dictionary<string,string>();
		/// DownloadData.Add("url", "http://yoursite.com/video.mp4");
		/// DownloadData.Add("title", "mytitle");
		/// HeyWatch.DownloadCreate(DownloadData);
		/// </example>
		public HeyWatchDownload DownloadCreate (Dictionary<string, string> Data)
		{
			return Json.Deserialize<HeyWatchDownload>(Request("download", Method.POST, Data));
		}
		
		/// <summary>
		/// Delete a Download
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>true or raise an exception HeyWatchException</returns>
		/// <example>
		/// HeyWatch.DownloadDelete(12345);
		/// </example>
		public bool DownloadDelete (int Id)
		{
			Request("download/" + Id, Method.DELETE);
			return true;
		}
		
		/// <summary>
		/// Get info about a Download
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>HeyWatchDownload Instance</returns>
		/// <example>
		/// HeyWatch.DownloadInfo(12345);
		/// </example>
		public HeyWatchDownload DownloadInfo (int Id)
		{
			return Json.Deserialize<HeyWatchDownload>(Request("download/" + Id));
		}
		
		/// <summary>
		/// Get All the downloads
		/// </summary>
		/// <returns>List of HeyWatchDownload Instances</returns>
		/// <example>
		/// HeyWatch.DownloadAll();
		/// </example>
		public List<HeyWatchDownload> DownloadAll ()
		{
			return Json.Deserialize<List<HeyWatchDownload>>(Request("download"));
		}
		
		/// <summary>
		/// Create a Job
		/// </summary>
		/// <param name="Data">A dictionary representing the POST parameters</param>
		/// <returns>HeyWatchJob Instance</returns>
		/// <example>
		/// JobData = new Dictionary<string,string>();
		/// JobData.Add("video_id", "1234443");
		/// JobData.Add("format_id", "31");
		/// HeyWatch.JobCreate(JobData);
		/// </example>
		public HeyWatchJob JobCreate (Dictionary<string, string> Data)
		{
			return Json.Deserialize<HeyWatchJob>(Request("job", Method.POST, Data));
		}
		
		/// <summary>
		/// Get info about a Job
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>HeyWatchJob Instance</returns>
		/// <example>
		/// HeyWatch.JobInfo(9812345);
		/// </example>
		public HeyWatchJob JobInfo (int Id)
		{
			return Json.Deserialize<HeyWatchJob>(Request("job/" + Id));
		}
		
		/// <summary>
		/// Get All the jobs
		/// </summary>
		/// <returns>List of HeyWatchJob Instances</returns>
		/// <example>
		/// HeyWatch.JobAll();
		/// </example>
		public List<HeyWatchJob> JobAll ()
		{
			return Json.Deserialize<List<HeyWatchJob>>(Request("job"));
		}
		
		/// <summary>
		/// Get info about a Video
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>HeyWatchVideo Instance</returns>
		/// <example>
		/// HeyWatch.VideoInfo(8765529);
		/// </example>
		public HeyWatchVideo VideoInfo (int Id)
		{
			return Json.Deserialize<HeyWatchVideo>(Request("video/" + Id));
		}
		
		public byte[] VideoBinary (int Id)
		{
			return DownloadBinary("video/" + Id + ".bin");
		}
		
		/// <summary>
		/// Get All the videos
		/// </summary>
		/// <returns>List of HeyWatchVideo Instances</returns>
		/// <example>
		/// HeyWatch.VideoAll();
		/// </example>
		public List<HeyWatchVideo> VideoAll ()
		{
			return Json.Deserialize<List<HeyWatchVideo>>(Request("video"));
		}
		
		/// <summary>
		/// Delete a Video
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>true or raise an exception HeyWatchException</returns>
		/// <example>
		/// HeyWatch.VideoDelete(8765529);
		/// </example>
		public bool VideoDelete (int Id)
		{
			Request("video/" + Id, Method.DELETE);
			return true;
		}
		
		
		/// <summary>
		/// Get info about an Encoded Video
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>HeyWatchEncodedVideo Instance</returns>
		/// <example>
		/// HeyWatch.EncodedVideoInfo(8765540);
		/// </example>
		public HeyWatchEncodedVideo EncodedVideoInfo (int Id)
		{
			return Json.Deserialize<HeyWatchEncodedVideo>(Request("encoded_video/" + Id));
		}
		
		public byte[] EncodedVideoBinary (int Id)
		{
			return DownloadBinary("encoded_video/" + Id + ".bin");
		}
		
		/// <summary>
		/// Get the thumbnail of the encoded video
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>bytes[]</returns>
		/// <example>
		/// HeyWatch.EncodedVideoJpg(8765540);
		/// </example>
		public byte[] EncodedVideoJpg (int Id)
		{
			return DownloadBinary("encoded_video/" + Id + ".jpg");
		}
		
		/// <summary>
		/// Get the thumbnail of the encoded video
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="Data">A dictionary representing the GET parameters</param>
		/// <returns>bytes[]</returns>
		/// <example>
		/// Dictionary<string, string> JpgData = new Dictionary<string, string>();
		/// JpgData.Add("start", "5");
		/// HeyWatch.EncodedVideoJpg(8765540, JpgData);
		/// </example>
		public byte[] EncodedVideoJpg (int Id, Dictionary<string, string> Data)
		{
			return DownloadBinary("encoded_video/" + Id + ".jpg", Data);
		}
		
		/// Generate thumbnails in the background
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="Data">A dictionary representing the POST parameters</param>
		/// <returns>true or raise an exception HeyWatchException</returns>
		/// <example>
		/// Dictionary<string, string> ThumbData = new Dictionary<string, string>();
		/// ThumbData.Add("number", "6");
		/// ThumbData.Add("width", "320");
		/// ThumbData.Add("height", "240");
		/// ThumbData.Add("s3_directive", "s3://accesskey:secretkey@bucket/");
		/// HeyWatch.EncodedVideoJpg(8765540, ThumbData);
		/// </example>
		public bool EncodedVideoThumbnails(int Id, Dictionary<string, string> Data)
		{
			Request("encoded_video/" + Id + "/thumbnails", Method.POST, Data);
			return true;
		}
		
		/// <summary>
		/// Get All the encoded videos
		/// </summary>
		/// <returns>List of HeyWatchEncodedVideo Instances</returns>
		/// <example>
		/// HeyWatch.EncodedVideoAll();
		/// </example>
		public List<HeyWatchEncodedVideo> EncodedVideoAll ()
		{
			return Json.Deserialize<List<HeyWatchEncodedVideo>>(Request("encoded_video"));
		}
		
		/// <summary>
		/// Delete an Encoded Video
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>true or raise an exception HeyWatchException</returns>
		/// <example>
		/// HeyWatch.EncodedVideoDelete(8765540);
		/// </example>
		public bool EncodedVideoDelete (int Id)
		{
			Request("encoded_video/" + Id, Method.DELETE);
			return true;
		}
		
		/// <summary>
		/// Create a Format
		/// </summary>
		/// <param name="Data">A dictionary representing the POST parameters</param>
		/// <returns>HeyWatchFormat Instance</returns>
		/// <example>
		/// FormatData = new Dictionary<string,string>();
		/// FormatData.Add("name", "iPhone");
		/// FormatData.Add("category", "device");
		/// FormatData.Add("container", "mp4");
		/// FormatData.Add("video_codec", "h264");
		/// FormatData.Add("video_bitrate", "800");
		/// FormatData.Add("fps", "30");
		/// FormatData.Add("audio_codec", "aac");
		/// FormatData.Add("audio_bitrate", "128");
		/// FormatData.Add("audio_channels", "2");
		/// FormatData.Add("sample_rate", "44000");
		/// HeyWatch.FormatCreate(FormatData);
		/// </example>
		public HeyWatchFormat FormatCreate (Dictionary<string, string> Data)
		{
			return Json.Deserialize<HeyWatchFormat>(Request("format", Method.POST, Data));
		}
		
		/// <summary>
		/// Update a Format
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="Data">A dictionary representing the PUT parameters</param>
		/// <returns>HeyWatchFormat Instance</returns>
		/// <example>
		/// FormatData = new Dictionary<string,string>();
		/// FormatData.Add("video_bitrate", "1280");
		/// HeyWatch.FormatUpdate(9872, FormatData);
		/// </example>
		public HeyWatchFormat FormatUpdate (int Id, Dictionary<string, string> Data)
		{
			return Json.Deserialize<HeyWatchFormat>(Request("format/" + Id, Method.PUT, Data));
		}
		
		/// <summary>
		/// Get info about a Format
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>HeyWatchFormat Instance</returns>
		/// <example>
		/// HeyWatch.FormatInfo(31);
		/// </example>
		public HeyWatchFormat FormatInfo (int Id)
		{
			return Json.Deserialize<HeyWatchFormat>(Request("format/" + Id));
		}
		
		/// <summary>
		/// Delete a Format
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>true or raise an exception HeyWatchException</returns>
		/// <example>
		/// HeyWatch.FormatDelete(9872);
		/// </example>
		public bool FormatDelete (int Id)
		{
			Request("format/" + Id, Method.DELETE);
			return true;
		}
		
		/// <summary>
		/// Get All the formats
		/// </summary>
		/// <returns>List of HeyWatchFormat Instances</returns>
		/// <example>
		/// HeyWatch.FormatAll();
		/// </example>
		public List<HeyWatchFormat> FormatAll ()
		{
			return Json.Deserialize<List<HeyWatchFormat>>(Request("format"));
		}
		
		private string Request(String path) 
		{
			return Request(path, Method.GET);
		}
		
		private string Request(string path, RestSharp.Method method) 
		{
			var request = new RestRequest(path, method);
			RestResponse response = Cli.Execute(request);

			var code = response.StatusCode;
			
			if(code == HttpStatusCode.OK || code == HttpStatusCode.Redirect || code == HttpStatusCode.NoContent)
			{
				return response.Content;
			}
			else
			{ 
				throw new HeyWatchException(response.Content);
			}			
		}
		
		private string Request(string path, RestSharp.Method method, Dictionary<string, string> Data) {
			var request = new RestRequest(path, method);
			foreach (KeyValuePair<string, string> Pair in Data)
			{
				request.AddParameter(Pair.Key, Pair.Value);
			}
			
			RestResponse response = Cli.Execute(request);
			var code = response.StatusCode;
			
			if(code == HttpStatusCode.Created || code == HttpStatusCode.OK || code == HttpStatusCode.NoContent)
			{
				return response.Content;
			}
			else
			{ 
				throw new HeyWatchException(response.Content);
			}
			
		}
		
		private byte[] DownloadBinary(string Resource)
		{
			var request = new RestRequest(Resource);
			return Cli.DownloadData(request);
		}
		
		private byte[] DownloadBinary(string Resource, Dictionary<string, string> Data)
		{
			var request = new RestRequest(Resource);
			foreach (KeyValuePair<string, string> Pair in Data)
			{
				request.AddParameter(Pair.Key, Pair.Value);
			}
			return Cli.DownloadData(request);
		}
	}
}