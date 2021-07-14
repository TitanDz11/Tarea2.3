using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
    using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace TareaCamara.Droid
{
    [Activity(Label = "MainApplication")]
    public class MainApplication : Activity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);
        }
    }
}
