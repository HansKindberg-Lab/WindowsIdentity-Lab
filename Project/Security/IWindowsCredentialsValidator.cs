using System.Security.Permissions;
using HansKindberg.Security.Principal;
using HansKindberg.Validation;

namespace HansKindberg.Security
{
	public interface IWindowsCredentialsValidator
	{
		#region Methods

		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		IValidationResult<IWindowsIdentity> Validate(string userName, string domainName, string password);

		#endregion
	}
}