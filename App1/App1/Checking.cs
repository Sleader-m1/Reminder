using AffairNamesps;
using App1.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace App1
{
    static class Checker
    {
        static public double[] GetCoordinates(string coordinates)
        {
            var v = coordinates.Replace(',', '.').Split();//.Select(x=> Convert.ToDouble(x)).ToArray();
            double[] d = new double[] { -1, -1 };
        loop:
            try
            {
                d = new double[] { double.Parse(v[0], CultureInfo.InvariantCulture), double.Parse(v[1], CultureInfo.InvariantCulture) };
                return d;
            }
            catch
            {
                goto loop;
            }
        }

        static public async void Start_Chacking()
        {
            while (true)
            {
                var affairs = await App.DatBasDB.GetAffairsAsync();
                string position = FindPosition.FindMyPosition().Result;
                affairs = affairs.Select(i => i).Where(x => x.position != string.Empty && x.wasChecked != true).ToList();

                double[] current_position = GetCoordinates(position);

                for (int i = 0; i < affairs.Count; ++i)
                {
                    double[] coordinates_of_trigger = GetCoordinates(affairs[i].position);
                    if (Math.Sqrt(Math.Pow(coordinates_of_trigger[0] - current_position[0], 2) + Math.Pow(coordinates_of_trigger[1] - current_position[1], 2)) < 0.001)
                    {
                        var m = new MainPageViewModel();
                        m.ShowNotificationCommand.Execute(m);
                        Affair updated_affair = affairs[i];
                        updated_affair.wasChecked = true;
                        await App.DatBasDB.SaveAffairAsync(updated_affair);
                    }
                }
            }
        }
    }
}