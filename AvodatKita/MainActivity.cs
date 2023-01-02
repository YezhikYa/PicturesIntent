using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace AvodatKita
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private int number = 0;
        private ImageView ivAnimal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitializaViews();
        }

        private void InitializaViews()
        {
            ivAnimal = FindViewById<ImageView>(Resource.Id.ivAnimal);

            ivAnimal.Click += ivAnimal_click;
        }

        private void ivAnimal_click(object sender, EventArgs e)
        {
            Intent intentRandom = new Intent(this, typeof(MainActivityRandom));
            StartActivityForResult(intentRandom, 1);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 1)
            {
                number = data.GetIntExtra("NUMBER", 0);
            }

            switch (number)
            {
                case 1:
                    ivAnimal.SetImageResource(Resource.Drawable.Bunny);
                    break;
                case 2:
                    ivAnimal.SetImageResource(Resource.Drawable.Coala);
                    break;
                case 3:
                    ivAnimal.SetImageResource(Resource.Drawable.Deer);
                    break;
                case 4:
                    ivAnimal.SetImageResource(Resource.Drawable.Dolphin);
                    break;
                case 5:
                    ivAnimal.SetImageResource(Resource.Drawable.Fox);
                    break;
                case 6:
                    ivAnimal.SetImageResource(Resource.Drawable.Girafe);
                    break;
                case 7:
                    ivAnimal.SetImageResource(Resource.Drawable.Hedgehog);
                    break;
                case 8:
                    ivAnimal.SetImageResource(Resource.Drawable.Lemur);
                    break;
                case 9:
                    ivAnimal.SetImageResource(Resource.Drawable.Sheep);
                    break;
                case 10:
                    ivAnimal.SetImageResource(Resource.Drawable.Tiger);
                    break;
            }
        }
    }
}