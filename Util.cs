using System;

namespace AssemblyCSharp
{
	/// <summary>
	/// Contain various utility methods.
	/// </summary>
	public class Util
	{
		/// <summary>
		/// Calculates a number between curr and target based on percentage.
		/// </summary>
		/// <returns>The diff.</returns>
		/// <param name="curr">Current value of item.</param>
		/// <param name="target">Target value of item.</param>
		/// <param name="percentage">Percentage (between 0 and 1) between current and target to recieve.
		/// setting it to 0 causes the function to return curr, setting it to 1 causes
		/// the function to return target.</param>
		public static float percentDiff(float curr, float target, float percentage){
			return curr + percentage * (target - curr);
		}
	}
}

