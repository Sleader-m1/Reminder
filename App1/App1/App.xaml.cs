using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DatBasNsp;
using System.IO;

namespace App1
{
    public partial class App : Application
    {
        static DatBas datbasDB;

        public static DatBas DatBasDB
        {
            get
            {
                if(datbasDB == null)
                {
                    datbasDB = new DatBas(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "AffairDatabase.db3"));
                }
                return datbasDB;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
