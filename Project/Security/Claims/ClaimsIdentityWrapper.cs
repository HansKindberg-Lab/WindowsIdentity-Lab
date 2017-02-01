using System.Security.Claims;
using HansKindberg.Abstractions;

namespace HansKindberg.Security.Claims
{
	public class ClaimsIdentityWrapper : ClaimsIdentityWrapper<ClaimsIdentity>
	{
		#region Constructors

		public ClaimsIdentityWrapper(ClaimsIdentity claimsIdentity) : base(claimsIdentity, "claimsIdentity") {}

		#endregion
	}

	public abstract class ClaimsIdentityWrapper<T> : Wrapper<T>, IClaimsIdentity where T : ClaimsIdentity
	{
		#region Constructors

		protected ClaimsIdentityWrapper(T claimsIdentity, string claimsIdentityParameterName) : base(claimsIdentity, claimsIdentityParameterName) {}

		#endregion

		#region Properties

		public virtual string AuthenticationType => this.WrappedInstance.AuthenticationType;
		public virtual bool IsAuthenticated => this.WrappedInstance.IsAuthenticated;

		public virtual string Label
		{
			get { return this.WrappedInstance.Label; }
			set { this.WrappedInstance.Label = value; }
		}

		public virtual string Name => this.WrappedInstance.Name;

		#endregion
	}
}