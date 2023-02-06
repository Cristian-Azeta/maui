using System.Collections.Generic;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui
{
	public interface IViewHandler : IElementHandler
	{
		bool HasContainer { get; set; }

		object? ContainerView { get; }

		new IView? VirtualView { get; }

		Size GetDesiredSize(double widthConstraint, double heightConstraint);

		void PlatformArrange(Rect frame);
	}

	public interface IDynamicContainerViewHandler : IViewHandler
	{
		bool NeedsContainer { get; }

		ICollection<string> ContainerAffectingProperties { get; }
	}
}