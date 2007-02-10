using System;
using System.Reflection;

namespace NUnit.Fixtures
{
	/// <summary>
	/// Summary description for AssemblyRunner.
	/// </summary>
	public class AssemblyRunner : TestLoadFixture
	{
		public string Assembly;

		// Override doCell to handle the 'Code' column. We compile
		// the code and optionally load and run the tests.
		public override void doCell(fit.Parse cell, int columnNumber)
		{
			base.doCell (cell, columnNumber);

			FieldInfo field = columnBindings[columnNumber].field;
			if ( field != null && field.Name == "Assembly" )
				LoadAndRunTestAssembly( cell, Assembly );
		}
	}
}