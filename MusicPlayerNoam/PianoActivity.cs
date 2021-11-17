using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayerNoam
{
    [Activity(Label = "PianoActivity")]
    public class PianoActivity : Activity
    {
        Button btdo, re, mi, fa, sol, la, ci;
        MediaPlayer mp;
        AudioManager am;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PianoLayout);
            btdo = (Button)FindViewById(Resource.Id.btdo);
            re = (Button)FindViewById(Resource.Id.btre);
            mi = (Button)FindViewById(Resource.Id.btmi);
            fa = (Button)FindViewById(Resource.Id.btfa);
            sol = (Button)FindViewById(Resource.Id.btso);
            la = (Button)FindViewById(Resource.Id.btla);
            ci = (Button)FindViewById(Resource.Id.btci);
            btdo.Click += Btdo_Click;
            re.Click += Re_Click;
            mi.Click += Mi_Click;
            fa.Click += Fa_Click;
            sol.Click += Sol_Click;
            la.Click += La_Click;
            ci.Click += Ci_Click;
            am = (AudioManager)GetSystemService(Context.AudioService);
            int max = am.GetStreamMaxVolume(Stream.Music);
            am.SetStreamVolume(Stream.Music, max / 2, 0);
        }

        private void Ci_Click(object sender, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Raw.ci);
            mp.Start();
        }

        private void La_Click(object sender, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Raw.la);
            mp.Start();
        }

        private void Sol_Click(object sender, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Raw.so);
            mp.Start();
        }

        private void Fa_Click(object sender, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Raw.fa);
            mp.Start();
        }

        private void Mi_Click(object sender, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Raw.mi);
            mp.Start();
        }

        private void Re_Click(object sender, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Raw.re);
            mp.Start();
        }

        private void Btdo_Click(object sender, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Raw.ddo);
            mp.Start();
        }
    }
}