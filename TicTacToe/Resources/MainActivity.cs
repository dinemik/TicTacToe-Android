using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using TicTacToe.PCL;

namespace TicTacToe
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private List<Button> L1 { get; set; } = new List<Button>();
        private List<Button> L2 { get; set; } = new List<Button>();
        private List<Button> L3 { get; set; } = new List<Button>();
        private int Tmp { get; set; } = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            GetButtons(FindViewById<LinearLayout>(Resource.Id.L1), FindViewById<LinearLayout>(Resource.Id.L2), FindViewById<LinearLayout>(Resource.Id.L3));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void GetButtons(LinearLayout l1, LinearLayout l2, LinearLayout l3)
        {
            for (int i = 0; i < l1.ChildCount; i++)
            {
                L1.Add((Button)l1.GetChildAt(i));
                L2.Add((Button)l2.GetChildAt(i));
                L3.Add((Button)l3.GetChildAt(i));
            }

            foreach (var item in L1)
            {
                item.Click += Click;
            }

            foreach (var item in L2)
            {
                item.Click += Click;
            }

            foreach (var item in L3)
            {
                item.Click += Click;
            }
            var btn = FindViewById<Button>(Resource.Id.RstBtn);
            btn.Click += Restart;
        }

        public void Click(object s, EventArgs e)
        {
            var t = (Button)s;
            if(Tmp % 2 == 0)
                t.Text = "X";
            else
                t.Text = "o";

            t.Enabled = false;

            string winner = "";

            if (Tmp >= 4)
                winner = CheckWin.Win(L1, L2, L3);

            if(winner != "all" && winner != "")
                Toast.MakeText(ApplicationContext, $"Win {winner}", ToastLength.Long).Show();

            if (winner == "o" || winner == "x")
                OffAllBtns(winner);

            if (Tmp == 8 && winner == "all")
                Toast.MakeText(ApplicationContext, $"Win {winner}" , ToastLength.Long).Show();

            Tmp++;
        }

        private void OffAllBtns(string win)
        {
            foreach (var item in L1)
            {
                item.Enabled = false;
            }

            foreach (var item in L2)
            {
                item.Enabled = false;
            }

            foreach (var item in L3)
            {
                item.Enabled = false;
            }

            if (win == "x")
            {
                int.TryParse(FindViewById<TextView>(Resource.Id.ForX).Text, out int t);
                FindViewById<TextView>(Resource.Id.ForX).Text = (t + 1).ToString();
            }

            if (win == "o")
            {
                int.TryParse(FindViewById<TextView>(Resource.Id.ForO).Text, out int t);
                FindViewById<TextView>(Resource.Id.ForO).Text = (t + 1).ToString();
            }
        }

        public void Restart(object s, EventArgs e)
        {
            foreach (var item in L1)
            {
                item.Text = "";
                item.Enabled = true;
            }

            foreach (var item in L2)
            {
                item.Text = "";
                item.Enabled = true;
            }

            foreach (var item in L3)
            {
                item.Text = "";
                item.Enabled = true;
            }
            Tmp = 0;
        }
    }
}