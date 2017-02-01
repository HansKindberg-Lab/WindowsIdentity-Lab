using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using HansKindberg.Security.Principal;
using HansKindberg.Validation;

namespace HansKindberg.Security
{
	public class WindowsCredentialsValidator
	{
		#region Fields

		private const int _defaultLogOnProvider = 0; // LOGON32_PROVIDER_DEFAULT
		private const int _interactiveLogOn = 2; // LOGON32_LOGON_INTERACTIVE

		#endregion

		#region Methods

		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		public virtual IValidationResult<IWindowsIdentity> Validate(string userName, string domainName, string password)
		{
			IntPtr handle;
			var validationResult = new ValidationResult<IWindowsIdentity>();

			var isValidLogon = NativeMethods.LogonUser(userName, domainName, password, _interactiveLogOn, _defaultLogOnProvider, out handle);

			if(isValidLogon)
			{
				//var windowsIdentity = new WindowsIdentity(handle);
				//validationResult.ValidatedInstance 
			}
			else
			{
				//int ret = Marshal.GetLastWin32Error();

				//throw new Win32Exception(Marshal.GetLastWin32Error());

				var lastWindowsError = Marshal.GetLastWin32Error();

				validationResult.Exceptions.Add(new Win32Exception(lastWindowsError));
			}

			if(handle != IntPtr.Zero)
				NativeMethods.CloseHandle(handle);

			//return isValid;
			return validationResult;
		}

		#endregion

		#region Nested types

		private static class NativeMethods
		{
			#region Methods

			[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CloseHandle(IntPtr handle);

			[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool LogonUser(string userUsername, string domainName, string password, int logonType, int logonProvider, out IntPtr handle);

			#endregion
		}

		#endregion
	}
}