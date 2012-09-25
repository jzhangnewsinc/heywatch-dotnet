using System;
using System.Collections.Generic;

namespace HeyWatch
{
	public class HeyWatchDownload 
	{
	    public DateTime Created_At { get; set; }
		public string Error_Msg { get; set; }
		public string Title { get; set; }
		public int Video_Id { get; set; }
		public DateTime Updated_At { get; set; }
		public string Url { get; set; }
		public Dictionary<string, string> Progress { get; set; }
		public int Id { get; set; }
		public int? Error_Code { get; set; }
		public int Length { get; set; }
		public string Status { get; set; }
	}
	
	public class HeyWatchFormat 
	{
		public string Name { get; set; }
		public int Sample_Rate { get; set; }
		public string Category { get; set; }
		public int Audio_Channels { get; set; }
		public string Container { get; set; }
		public float Video_Bitrate { get; set; }
		public float Audio_Bitrate { get; set; }
		public int Id { get; set; }
		public string Audio_Codec { get; set; }
		public int Height { get; set; }
		public bool Two_Pass { get; set; }
		public string Video_Codec { get; set; }
		public float Fps { get; set; }
		public int Width { get; set; }
		public bool Owner { get; set; }
	}
	
	public class HeyWatchAccount 
	{
		public DateTime Created_At { get; set; }
		public DateTime Updated_At { get; set; }
		public string Upload_Key { get; set; }
		public string Lastname { get; set; }
		public int IO { get; set; }
		public int Encode_Credits { get; set; }
		public string Firstname { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public int Default_Format { get; set; }
		public bool Automatic_Encode { get; set; }
	}
	
	public class HeyWatchJob
	{
		public string Ping_Url_After_Encode { get; set; }
		public DateTime Created_At { get; set; }
		public string Error_Msg { get; set; }
		public string Cf_Directive { get; set; }
		public int Video_Id { get; set; }
		public DateTime Updated_At { get; set; }
		public int Progress { get; set; }
		public int Id { get; set; }
		public int Format_Id { get; set; }
		public string S3_Directive { get; set; }
		public string Ping_Url_If_Error { get; set; }
		public int? Error_Code { get; set; }
		public Dictionary<string, string> Encoding_Options { get; set; }
		public int Encoded_Video_Id { get; set; }
		public string Ftp_Directive { get; set; }
		public string Status { get; set; }
		public string Http_Upload_Directive { get; set; }
	}
	
	public class HeyWatchVideo
	{
		public DateTime Created_At { get; set; }
		public string Title { get; set; }
		public Dictionary<string, string> Specs { get; set; }
		public DateTime Updated_At { get; set; }
		public int Id { get; set; }
	}
	
	public class HeyWatchEncodedVideo
	{
		public DateTime Created_At { get; set; }
		public string Title { get; set; }
		public Dictionary<string, string> Specs { get; set; }
		public DateTime Updated_At { get; set; }
		public int Id { get; set; }
		public string Filename { get; set; }
		public string Link { get; set; }
		public int Job_Id { get; set; }
	}			
}

