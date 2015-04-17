#if VSTEST
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using TestFixtureAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestClassAttribute;
using TestAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.AppContainer.UITestMethodAttribute;
#else
using NUnit.Framework;
#endif
using System.IO;
using System;
using System.Reflection;

namespace NGraphics.Test
{
	[TestFixture]
	public class PathTests : PlatformTest
	{
		[Test]
		public void Contains ()
		{
			var p = new Path ();
			p.MoveTo (new Point (0, 0));
			p.LineTo (new Point (100, 0));
			p.LineTo (new Point (100, 50));
			p.Close ();

			Assert.IsFalse (p.Contains (new Point (0, 1)));
			Assert.IsTrue (p.Contains (new Point (0, 0)));
			Assert.IsTrue (p.Contains (new Point (99, 49)));
			Assert.IsFalse (p.Contains (new Point (50, 49)));
		}

		[Test]
		public void ContainsWithTransform ()
		{
			var p = new Path ();
			p.MoveTo (new Point (0, 0));
			p.LineTo (new Point (100, 0));
			p.LineTo (new Point (100, 50));
			p.Close ();

			p.Transform = NGraphics.Transform.Translate (100, 100);
			Assert.IsFalse (p.Contains (new Point (0, 0), true));
			Assert.IsFalse (p.Contains (new Point (99, 49), true));

			Assert.IsFalse (p.Contains (new Point (100, 101), true));
			Assert.IsTrue (p.Contains (new Point (100, 100), true));
			Assert.IsTrue (p.Contains (new Point (199, 149), true));
			Assert.IsFalse (p.Contains (new Point (150, 149), true));
		}

		[Test]
		public void TurtleGraphics ()
		{
			var p = new Path ();
			p.MoveTo (new Point (100, 200));
			p.LineTo (new Point (200, 250));
			p.LineTo (new Point (100, 300));
			p.Close ();
		}
	}
}

