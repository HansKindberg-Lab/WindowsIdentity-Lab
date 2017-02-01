using System.Security.Principal;
using HansKindberg.Security.Claims;

namespace HansKindberg.Security.Principal
{
	public class WindowsIdentityWrapper : ClaimsIdentityWrapper<WindowsIdentity>, IWindowsIdentity
	{
		#region Constructors

		public WindowsIdentityWrapper(WindowsIdentity windowsIdentity) : base(windowsIdentity, "windowsIdentity") {}

		#endregion
	}
}