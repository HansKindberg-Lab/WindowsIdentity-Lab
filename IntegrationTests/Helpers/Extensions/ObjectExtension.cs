using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HansKindberg.IntegrationTests.Helpers.Extensions
{
	public static class ObjectExtension
	{
		#region Methods

		public static T Deserialize<T>(string value)
		{
			using(var stream = new MemoryStream(Convert.FromBase64String(value)))
			{
				return (T) new BinaryFormatter().Deserialize(stream);
			}
		}

		public static string Serialize(this object instance)
		{
			if(instance == null)
				throw new ArgumentNullException(nameof(instance));

			using(var stream = new MemoryStream())
			{
				new BinaryFormatter().Serialize(stream, instance);

				return Convert.ToBase64String(stream.ToArray());
			}
		}

		#endregion
	}
}