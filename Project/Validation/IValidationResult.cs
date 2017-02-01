using System;
using System.Collections.Generic;

namespace HansKindberg.Validation
{
	public interface IValidationResult
	{
		#region Properties

		IList<Exception> Exceptions { get; }
		bool IsValid { get; }

		#endregion
	}

	public interface IValidationResult<T> : IValidationResult
	{
		#region Properties

		T ValidatedInstance { get; set; }

		#endregion
	}
}