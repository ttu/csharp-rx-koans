using System;
using System.Drawing;
using System.Reactive.Linq;

namespace Koans.Utils
{
    public class RxKoans
    {
        public static IObservable<Point> CreateMouseEvents(params Point[] points)
        {
            return points.ToObservable();
        }

        public static IObservable<T> CallWebApi<T>(int delay, string name, string request, params T[] events)
        {
            return events.ToObservable().Delay(TimeSpan.FromSeconds(delay));
        }
    }
}