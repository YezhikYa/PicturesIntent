using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace AvodatKita
{
    [Activity(Label = "MainActivityRandom")]
    public class MainActivityRandom : Activity
    {
        private TextView tvNumber;
        private Button btnGenRan;
        private Button btnOk;

        private int number;
        private bool btnGenRanPressed = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_mainRandom);
            // Create your application here

            InitializeViews();
        }

        private void InitializeViews()
        {
            tvNumber = FindViewById<TextView>(Resource.Id.tvNumber);
            btnGenRan = FindViewById<Button>(Resource.Id.btnGenRan);
            btnOk = FindViewById<Button>(Resource.Id.btnOk);

            number = Intent.GetIntExtra("NUMBER", 1);

            btnGenRan.Click += btnGenRan_click;
            btnOk.Click += btnOk_click;
        }

        private void btnOk_click(object sender, EventArgs e)
        {
            if (btnGenRanPressed)
            {
                Intent intent = new Intent();
                intent.PutExtra("NUMBER", number);
                SetResult(Result.Ok, intent);
                Finish();
            }
            else
            {
                Toast.MakeText(Application.Context, "You haven't generated a number", ToastLength.Long).Show();
            }
        }

        private void btnGenRan_click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            number = rnd.Next(1, 11);
            tvNumber.Text = number.ToString();

            if (number >= 1 && number <= 10)
                btnGenRanPressed = true;
        }
    }
}