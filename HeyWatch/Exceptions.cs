using System;
namespace HeyWatch
{
	 public class HeyWatchException: ApplicationException
	 {
	     public HeyWatchException(string Message, 
	                  Exception innerException): base(Message,innerException) {}
	     public HeyWatchException(string Message) : base(Message) {}
	     public HeyWatchException() {}
	 }
}

