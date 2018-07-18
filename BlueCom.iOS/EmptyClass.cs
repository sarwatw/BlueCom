using System;
using BlueCom.iOS;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BlueCom.DoneEntry), typeof(DoneEntryRenderer))]
namespace BlueCom.iOS
{
    public class DoneEntryRenderer : EntryRenderer
    {
        /*protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

            toolbar.Items = new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
            };

            this.Control.InputAccessoryView = toolbar;
        }*/
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

            toolbar.Items = new[]
            {
        new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
        new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate {
            Control.ResignFirstResponder();
            ((IEntryController)Element).SendCompleted();
        })
    };

            this.Control.InputAccessoryView = toolbar;
        }
    }
}
