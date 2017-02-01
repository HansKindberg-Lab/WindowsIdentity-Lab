using System;

namespace HansKindberg.Abstractions
{
	public abstract class Wrapper<T> : IWrapper<T>
	{
		#region Constructors

		protected Wrapper(T wrappedInstance, string wrappedInstanceParameterName)
		{
			if(Equals(wrappedInstance, null))
				throw new ArgumentNullException(wrappedInstanceParameterName);

			this.WrappedInstance = wrappedInstance;
		}

		#endregion

		#region Properties

		public virtual T WrappedInstance { get; }
		object IWrapper.WrappedInstance => this.WrappedInstance;

		#endregion
	}
}