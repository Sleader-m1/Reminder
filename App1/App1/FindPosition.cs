using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App1
{
    static class FindPosition
    {
        static public async Task<string> FindMyPosition()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                if (location == null)
                {
                    return "No way to find location";
                }
                else
                {
                    return $"{location.Latitude} {location.Longitude}";
                }
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}