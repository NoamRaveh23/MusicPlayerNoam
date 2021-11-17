using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Content;
using Android.Media;


namespace MusicPlayerNoam
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btp, bts , btpause , btpiano;
        TextView tv;
        SeekBar sb;
        MediaPlayer mp;
        AudioManager am;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btp = (Button)FindViewById(Resource.Id.bt1);
            bts = (Button)FindViewById(Resource.Id.bt2);
            btpause = (Button)FindViewById(Resource.Id.bt3);
            btpiano = (Button)FindViewById(Resource.Id.btpiano);
            sb = (SeekBar)FindViewById(Resource.Id.sb);
            tv = (TextView)FindViewById(Resource.Id.tv);
            mp = MediaPlayer.Create(this, Resource.Raw.BenBassatSong);
            mp.Start();
            am = (AudioManager)GetSystemService(Context.AudioService);
            int max = am.GetStreamMaxVolume(Stream.Music);
            sb.Max = max;
            am.SetStreamVolume(Stream.Music, max / 2, 0);
            sb.ProgressChanged += Sb_ProgressChanged; ;
            btp.Click += Btp_Click;
            bts.Click += Bts_Click;
            btpause.Click += Btpause_Click;
            btpiano.Click += Btpiano_Click;
        }

        private void Btpiano_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PianoActivity));
            StartActivity(intent);
        }

        private void Btpause_Click(object sender, System.EventArgs e)
        {
            mp.Pause();
        }

        private void Bts_Click(object sender, System.EventArgs e)
        {
            mp.Stop();
        }

        private void Btp_Click(object sender, System.EventArgs e)
        {
            mp.Start();

        }

        private void Sb_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            am.SetStreamVolume(Stream.Music, e.Progress, VolumeNotificationFlags.PlaySound);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}