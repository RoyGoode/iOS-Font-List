using System;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.Dialog;

namespace GetFonts
{
	public class FontViewController : DialogViewController
	{
		public FontViewController () : base(UITableViewStyle.Plain, null)
		{
			EnableSearch = true;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Root = new RootElement("Fonts") {
				from fontFamilyName in UIFont.FamilyNames
				orderby fontFamilyName
				select new Section(fontFamilyName) {
					from fontName in UIFont.FontNamesForFamilyName(fontFamilyName)
					orderby fontName
					select (Element) new StyledStringElement(fontName) { Font = UIFont.FromName (fontName, 20f) }
				}
			};
		}
	}
}

