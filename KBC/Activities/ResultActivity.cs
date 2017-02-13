﻿using Android.App;
using Android.OS;
using Android.Widget;

namespace KBC
{
    [Activity(Label = "KBC", Icon = "@drawable/icon")]
    public class ResultActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Result);

            var answered = Intent.Extras.GetInt("Answered");
            
            var message = answered >= 4 ? "Congratulation" : "Better Luck Next Time";

            var msgView = FindViewById<TextView>(Resource.Id.resultMessageView);
            msgView.Text = message;

            var cashView = FindViewById<TextView>(Resource.Id.resultCashView);
            cashView.Text = "₹" + GetAmount(answered);
        }

        string GetAmount(int Answered)
        {
            if (Answered == Question.Amounts.Length)
                return Question.Amounts[Answered - 1];
            else if (Answered >= 8)
                return Question.Amounts[7];
            else if (Answered >= 4)
                return Question.Amounts[3];

            return "0";
        }
    }
}

