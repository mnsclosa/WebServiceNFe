using System;
using System.Runtime.Serialization;

namespace ServiceNFe.Entities.Exceptions
{
	[Serializable()]
	public class NFeException : Exception
	{
		public NFeException()
		{
		}
		public NFeException( string message ) : base( message )
		{
		}
		public NFeException( string message,Exception inner ) : base( message,inner )
		{
		}
		protected NFeException( SerializationInfo info,StreamingContext context ) : base( info,context )
		{
		}
	}
}
