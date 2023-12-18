﻿using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.AppiumTests.Issues
{
	public class CarouselViewAdjustPeekAreaInsets : _IssuesUITest
	{
		public CarouselViewAdjustPeekAreaInsets(TestDevice device)
			: base(device)
		{
		}

		public override string Issue => "[Bug] Java.Lang.IllegalArgumentException in CarouselView adjusting PeekAreaInsets in OnSizeAllocated using XF 5.0";

		// Issue13436 (src\ControlGallery\src\Issues.Shared\Issue13436.cs
		[Test]
		public void ChangePeekAreaInsetsInOnSizeAllocatedTest()
		{
			App.WaitForElement("CarouselId");
		}
	}
}