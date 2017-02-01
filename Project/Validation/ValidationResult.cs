using System;
using System.Collections.Generic;
using System.Linq;

namespace HansKindberg.Validation
{
	public class ValidationResult : IValidationResult
	{
		#region Constructors

		public ValidationResult()
		{
			this.Exceptions = new List<Exception>();
		}

		#endregion

		#region Properties

		public virtual IList<Exception> Exceptions { get; }
		public virtual bool IsValid => !this.Exceptions.Any();

		#endregion
	}

	public class ValidationResult<T> : ValidationResult, IValidationResult<T>
	{
		#region Properties

		public virtual T ValidatedInstance { get; set; }

		#endregion
	}
}