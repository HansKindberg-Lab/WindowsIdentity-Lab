using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.IntegrationTests
{
	[TestClass]
	[SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors")]
	public class LabTest
	{
		#region Methods

		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private static void CreateFile()
		{
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid() + ".txt");

			if(path == "Kalle")
				throw new InvalidOperationException("Test");

			File.WriteAllText(path, "Test");
		}

		#endregion
	}

	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class WindowsCredentialsValidator
	{
		#region Fields

		private const int _defaultLogOnProvider = 0; // LOGON32_PROVIDER_DEFAULT
		private const int _interactiveLogOn = 2; // LOGON32_LOGON_INTERACTIVE

		#endregion

		#region Methods

		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		[SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "isValid")]
		public virtual IntPtr Validate(string userName, string domainName, string password)
		{
			//IntPtr handle;

			//bool isValid = NativeMethods.LogonUser(userName, domainName, password, _interactiveLogOn, _defaultLogOnProvider, out handle);

			//if (handle != IntPtr.Zero)
			//	NativeMethods.CloseHandle(handle);

			//return isValid;

			IntPtr handle;

			var isValid = NativeMethods.LogonUser(userName, domainName, password, _interactiveLogOn, _defaultLogOnProvider, out handle);

			//if (handle != IntPtr.Zero)
			//	NativeMethods.CloseHandle(handle);

			return handle;
		}

		#endregion
	}

	public static class NativeMethods
	{
		#region Methods

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible")]
		public static extern bool CloseHandle(IntPtr handle);

		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#")]
		[SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible")]
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "logon")]
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Logon")]
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Username")]
		public static extern bool LogonUser(string userUsername, string domainName, string password, int logonType, int logonProvider, out IntPtr handle);

		#endregion
	}
}