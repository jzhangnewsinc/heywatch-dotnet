# Client Library for encoding Videos with HeyWatch using RestSharp #

HeyWatch is a Video Encoding Web Service.

For a CLI, look at the ruby version: http://github.com/particles/heywatch-ruby

For more information:

* HeyWatch: http://heywatch.com 
* API Documentation: http://dev.heywatch.com
* Contact: [heywatch at particle-s.com](mailto:heywatch at particle-s.com)
* Twitter: [@particles](http://twitter.com/particles) / [@sadikzzz](http://twitter.com/sadikzzz)

## Usage ##

	using HeyWatch;
	
	// login with your HeyWatch username and password
	HeyWatchCli = new HeyWatchClient(username, passwd);
	
	// get all your videos
	List<HeyWatchVideo> Videos = HeyWatchCli.VideoAll();
	
	foreach(HeyWatchVideo Video in Videos)
	{
		Console.WriteLine(Video.Id + " " + Video.Title);
	}
	
	// get information about a specific video
	HeyWatchCli.VideoInfo(9662090);

### Create a download ###

	Dictionary<string, string> DownloadData = new Dictionary<string, string>();
	DownloadData.Add("url", "http://site.com/yourvideo.mp4");
	DownloadData.Add("title", "yourtitle");
	
	HeyWatchDownload Download = HeyWatchCli.DownloadCreate(DownloadData);
	Console.writeLine("Download: " + Download.Id);
	
### Create a job ###

	Dictionary<string, string> JobData = new Dictionary<string, string>();
	JobData.Add("video_id", "9662090");
	JobData.Add("format_id", "31");
	JobData.Add("keep_video_size", "true");
	JobData.Add("ping_url_after_encode", "http://yoursite.com/ping/heywatch?postid=123434");
	JobData.Add("s3_directive", "s3://accesskey:secretkey@myvideobucket/flv/123434.flv");
	
	HeyWatchJob Job = HeyWatchCli.JobCreate(JobData);
	Console.writeLine("Job: " + Job.Id);
	
### Delete a video ###

	HeyWatchCli.VideoDelete(9662090);
	
### Generating thumbnails ###

	// Will return the binary data directly (byte[])
	HeyWatchCli.EncodedVideoJpg(9662142);
	
	Dictionary<string, string> JpgData = new Dictionary<string, string>();
	JpgData.Add("start", "4");
	HeyWatchCli.EncodedVideoJpg(9662142, JpgData);
	
	// Async method, you'll receive the thumbnails to 
	// your s3 account and get pinged when it's done
	
	Dictionary<string, string> ThumbData = new Dictionary<string, string>();
	ThumbData.Add("number", "6");
	ThumbData.Add("s3_directive", "s3://accesskey:secretkey@mybucket/thumbnails/");
	ThumbData.Add("ping_url", "http://site.com/ping/heywatch/thumbs");
	
	HeyWatchCli.EncodedVideoThumbnails(9662142, ThumbData);

### Errors ###

	Raise an HeyWatchException

Released under the [MIT license](http://www.opensource.org/licenses/mit-license.php).