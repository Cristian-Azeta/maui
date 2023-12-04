﻿using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.AppiumTests.Issues
{
	public class Issue18712 : _IssuesUITest
	{
		public Issue18712(TestDevice device)
			: base(device)
		{ }

		public override string Issue => "Editor IsEnabled and IsVisible works";

		[Test]
		public void Issue18712IsEnabledTest()
		{
			try
			{
				App.Click("IsEnabledButton");

				App.WaitForElement("WaitForStubControl");

				// 1. The test fails if you are able to interact with the editor below.
				App.Click("TestEditor");
				VerifyScreenshot();

			}
			finally
			{
				this.Back();
			}
		}

		[Test]
		public void Issue18712IsVisibleTest()
		{
			try
			{
				App.Click("IsVisibleButton");

				App.WaitForElement("WaitForStubControl");

				// 1. The test fails if the editor below is visible.
				// Verify therefore that when trying to find, we cannot.
				var editor = App.FindElement("TestEditor");
				Assert.NotNull(editor);

				// With a snapshot ensure that the Editor is not visible.
				VerifyScreenshot();
			}
			finally
			{
				this.Back();
			}
		}
	}
}