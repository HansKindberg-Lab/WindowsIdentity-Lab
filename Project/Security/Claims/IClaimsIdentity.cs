using System.Security.Principal;

namespace HansKindberg.Security.Claims
{
	public interface IClaimsIdentity : IIdentity
	{
		#region Properties

		string Label { get; set; }

		#endregion
	}
}