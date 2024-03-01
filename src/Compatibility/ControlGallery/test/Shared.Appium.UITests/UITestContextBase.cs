﻿using OpenQA.Selenium.Appium;
using UITest.Core;

namespace UITests
{
	public abstract class UITestContextBase
	{
		static IUIClientContext? UiTestContext;
		IServerContext? _context;
		protected TestDevice _testDevice;

		public UITestContextBase(TestDevice testDevice)
		{
			_testDevice = testDevice;
		}

		public static IUIClientContext? UITestContext { get { return UiTestContext; } }
		
		protected AppiumDriver Driver => AppiumSetup.App;

		public TestDevice Device
		{
			get
			{
				return UITestContext == null
					? throw new InvalidOperationException($"Call {nameof(InitialSetup)} before accessing the {nameof(Device)} property.")
					: UITestContext.Config.GetProperty<TestDevice>("TestDevice");
			}
		}

		public IApp App
		{
			get
			{
				return UITestContext == null
					? throw new InvalidOperationException($"Call {nameof(InitialSetup)} before accessing the {nameof(App)} property.")
					: UITestContext.App;
			}
		}

		public abstract IConfig GetTestConfig();

		public void InitialSetup(IServerContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			InitialSetup(context, false);
		}

		public void Reset()
		{
			if (_context == null)
			{
				throw new InvalidOperationException($"Cannot {nameof(Reset)} if {nameof(InitialSetup)} has not been called.");
			}

			InitialSetup(_context, true);
		}

		private void InitialSetup(IServerContext context, bool reset)
		{
			var testConfig = GetTestConfig();
			testConfig.SetProperty("TestDevice", _testDevice);

			// Check to see if we have a context already from a previous test and re-use it as creating the driver is expensive
			if (reset || UiTestContext == null)
			{
				UiTestContext?.Dispose();
				UiTestContext = context.CreateUIClientContext(testConfig);
			}

			if (UiTestContext == null)
			{
				throw new InvalidOperationException("Failed to get the driver.");
			}
		}
	}
}