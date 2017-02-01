using System;
using System.Collections.Generic;

namespace HansKindberg.Collections.Generic.Extensions
{
	public static class ListExtension
	{
		#region Methods

		public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
		{
			if(list == null)
				throw new ArgumentNullException(nameof(list));

			if(items == null)
				throw new ArgumentNullException(nameof(items));

			var concreteList = list as List<T>;

			if(concreteList != null)
			{
				concreteList.AddRange(items);

				return;
			}

			foreach(var item in items)
			{
				list.Add(item);
			}
		}

		#endregion
	}
}