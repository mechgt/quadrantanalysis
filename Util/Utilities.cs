// <copyright file="Utilities.cs" company="N/A">
// Copyright (c) 2008 All Right Reserved
// </copyright>
// <author>mechgt</author>
// <email>mechgt@gmail.com</email>
// <date>2008-12-23</date>
namespace QuadrantAnalysis.Util
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using ZoneFiveSoftware.Common.Data.Fitness;
    using ZoneFiveSoftware.Common.Visuals;
    using ZoneFiveSoftware.Common.Data;
    using System.Drawing;
    using System.Globalization;

    /// <summary>
    /// Generic utilities class that can be used on many projects
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        internal static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return constructedString;
        }

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        internal static byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        /// <summary>
        /// Rainbow will return a distinct list of colors based on ROYGBIV
        /// </summary>
        /// <param name="totalItems">Number of colors to generate</param>
        /// <param name="alpha">Alpha to be applied to all colors</param>
        /// <returns>Returns a distinct list of colors</returns>
        internal static List<Color> Rainbow(int totalItems, int alpha)
        {
            List<Color> colors = new List<Color>();
            double red;
            double green;
            double blue;
            double scaleFactor;

            // Harshness of the color. Max is 255
            int harshness = 150;

            // Manually add the colors if there are less than 6 items
            if (totalItems == 1)
            {
                colors.Add(Color.FromArgb(alpha, harshness, 0, 0));
            }
            else if (totalItems == 2)
            {
                colors.Add(Color.FromArgb(alpha, harshness, 0, 0));
                colors.Add(Color.FromArgb(alpha, 0, harshness, 0));
            }
            else if (totalItems == 3)
            {
                colors.Add(Color.FromArgb(alpha, harshness, 0, 0));
                colors.Add(Color.FromArgb(alpha, 0, harshness, 0));
                colors.Add(Color.FromArgb(alpha, 0, 0, harshness));
            }
            else if (totalItems == 4)
            {
                colors.Add(Color.FromArgb(alpha, harshness, 0, 0));
                colors.Add(Color.FromArgb(alpha, harshness, harshness, 0));
                colors.Add(Color.FromArgb(alpha, 0, harshness, 0));
                colors.Add(Color.FromArgb(alpha, 0, 0, harshness));
            }
            else if (totalItems == 5)
            {
                colors.Add(Color.FromArgb(alpha, harshness, 0, 0));
                colors.Add(Color.FromArgb(alpha, harshness, harshness, 0));
                colors.Add(Color.FromArgb(alpha, 0, harshness, 0));
                colors.Add(Color.FromArgb(alpha, 0, harshness, harshness));
                colors.Add(Color.FromArgb(alpha, 0, 0, harshness));
            }

            // Make sure we have a multiple of 6 to rainbow
            while (totalItems % 6 != 0)
            {
                totalItems += 1;
            }

            // Find the factor to which we will scale the colors
            scaleFactor = ((double)harshness / totalItems) * 6f;

            // Red is our starting point
            red = harshness;
            green = 0;
            blue = 0;

            // Add red to the list
            colors.Add(Color.FromArgb(alpha, (int)red, (int)green, (int)blue));

            // Work your way through the spectrum to build the colors
            while (green < harshness)
            {
                green += scaleFactor;

                // Catch any potential rounding issues
                if (green > harshness)
                {
                    green = harshness;
                }
                colors.Add(Color.FromArgb(alpha, (int)red, (int)green, (int)blue));
            }

            while (red > 0)
            {
                red -= scaleFactor;

                // Catch any potential rounding issues
                if (red < 0)
                {
                    red = 0;
                }

                colors.Add(Color.FromArgb(alpha, (int)red, (int)green, (int)blue));
            }

            while (blue < harshness)
            {
                blue += scaleFactor;

                // Catch any potential rounding issues
                if (blue > harshness)
                {
                    blue = harshness;
                }

                colors.Add(Color.FromArgb(alpha, (int)red, (int)green, (int)blue));
            }

            while (green > 0)
            {
                green -= scaleFactor;

                // Catch any potential rounding issues
                if (green < 0)
                {
                    green = 0;
                }

                colors.Add(Color.FromArgb(alpha, (int)red, (int)green, (int)blue));
            }

            while (red < harshness)
            {
                red += scaleFactor;

                // Catch any potential rounding issues
                if (red > harshness)
                {
                    red = harshness;
                }

                colors.Add(Color.FromArgb(alpha, (int)red, (int)green, (int)blue));
            }

            while (blue > 0)
            {
                blue -= scaleFactor;

                // Catch any potential rounding issues
                if (blue < 0)
                {
                    blue = 0;
                }

                colors.Add(Color.FromArgb(alpha, (int)red, (int)green, (int)blue));
            }

            // The last color and the first color should be the same.  Remove the last color
            colors.RemoveAt(colors.Count - 1);

            // Return the colors list
            return colors;
        }
        
        /// <summary>
        /// Remove paused time from data tracks
        /// </summary>
        /// <param name="sourceTrack"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static INumericTimeDataSeries RemovePausedTimesInTrack(INumericTimeDataSeries sourceTrack, IActivity activity)
        {
            ActivityInfo activityInfo = ActivityInfoCache.Instance.GetInfo(activity);

            if (activityInfo != null && sourceTrack != null)
            {
                INumericTimeDataSeries result = new NumericTimeDataSeries();

                if (activityInfo.NonMovingTimes.Count == 0)
                {
                    // Remove invalid data nonetheless
                    DateTime currentTime = sourceTrack.StartTime;
                    IEnumerator<ITimeValueEntry<float>> sourceEnumerator = sourceTrack.GetEnumerator();
                    bool sourceEnumeratorIsValid;

                    sourceEnumeratorIsValid = sourceEnumerator.MoveNext();

                    while (sourceEnumeratorIsValid)
                    {
                        if (!float.IsNaN(sourceEnumerator.Current.Value))
                        {
                            result.Add(currentTime, sourceEnumerator.Current.Value);
                        }

                        sourceEnumeratorIsValid = sourceEnumerator.MoveNext();
                        currentTime = sourceTrack.StartTime + new TimeSpan(0, 0, (int)sourceEnumerator.Current.ElapsedSeconds);
                    }
                }
                else
                {
                    DateTime currentTime = sourceTrack.StartTime;
                    IEnumerator<ITimeValueEntry<float>> sourceEnumerator = sourceTrack.GetEnumerator();
                    IEnumerator<IValueRange<DateTime>> pauseEnumerator = activityInfo.NonMovingTimes.GetEnumerator();
                    double totalPausedTimeToDate = 0;
                    bool sourceEnumeratorIsValid;
                    bool pauseEnumeratorIsValid;

                    pauseEnumeratorIsValid = pauseEnumerator.MoveNext();
                    sourceEnumeratorIsValid = sourceEnumerator.MoveNext();

                    while (sourceEnumeratorIsValid)
                    {
                        bool addCurrentSourceEntry = true;
                        bool advanceCurrentSourceEntry = true;

                        // Loop to handle all pauses up to this current track point
                        if (pauseEnumeratorIsValid)
                        {
                            if (currentTime > pauseEnumerator.Current.Lower &&
                                currentTime <= pauseEnumerator.Current.Upper)
                            {
                                addCurrentSourceEntry = false;
                            }
                            else if (currentTime > pauseEnumerator.Current.Upper)
                            {
                                // Advance pause enumerator
                                totalPausedTimeToDate += (pauseEnumerator.Current.Upper - pauseEnumerator.Current.Lower).TotalSeconds;
                                pauseEnumeratorIsValid = pauseEnumerator.MoveNext();

                                // Make sure we retry with the next pause
                                addCurrentSourceEntry = false;
                                advanceCurrentSourceEntry = false;
                            }
                        }

                        if (addCurrentSourceEntry && !float.IsNaN(sourceEnumerator.Current.Value))
                        {
                            DateTime entryTime = currentTime - new TimeSpan(0, 0, (int)totalPausedTimeToDate);

                            result.Add(entryTime, sourceEnumerator.Current.Value);
                        }

                        if (advanceCurrentSourceEntry)
                        {
                            sourceEnumeratorIsValid = sourceEnumerator.MoveNext();
                            currentTime = sourceTrack.StartTime + new TimeSpan(0, 0, (int)sourceEnumerator.Current.ElapsedSeconds);
                        }
                    }
                }

                return result;
            }

            return null;
        }

        /// <summary>
        /// Perform a smoothing operation using a moving average on the data series
        /// </summary>
        /// <param name="track">The data series to smooth</param>
        /// <param name="period">The range to smooth.  This is the total number of seconds to smooth across (slightly different than the ST method.)</param>
        /// <param name="min">An out parameter set to the minimum value of the smoothed data series</param>
        /// <param name="max">An out parameter set to the maximum value of the smoothed data series</param>
        /// <returns></returns>
        internal static INumericTimeDataSeries Smooth(INumericTimeDataSeries track, uint period, out float min, out float max)
        {
            min = float.NaN;
            max = float.NaN;
            INumericTimeDataSeries smooth = new NumericTimeDataSeries();

            if (track != null && track.Count > 0 && period > 1)
            {
                //min = float.NaN;
                //max = float.NaN;
                int start = 0;
                int index = 0;
                float value = 0, firstAvg = 0;
                float delta;

                float per = period;
                int offset = (int)period / 2;

                // TODO: (LOW) Handle smoothing beginning and end of track.  Remove debug line below and replace with real code.  Debug establishes the first point.
                smooth.Add(track.StartTime, track[0].Value);
                //  Idea: Fill unavailable points with first (and last) fully averaged values to weight everything appropriately.

                //// Find first average set
                //while (track[index].ElapsedSeconds < track[start].ElapsedSeconds + period)
                //{
                //    delta = track[index + 1].ElapsedSeconds - track[index].ElapsedSeconds;
                //    firstAvg += track[index].Value * delta;
                //    index++;
                //}

                //// Finish value calculation
                //per = track[index].ElapsedSeconds - track[start].ElapsedSeconds;
                //firstAvg = firstAvg / per;

                // Iterate through track
                // For each point, create average starting with 'start' index and go forward averaging 'period' seconds.
                // Stop when last 'full' period can be created ([start].ElapsedSeconds + 'period' seconds >= TotalElapsedSeconds)
                index = 0;
                while (track[start].ElapsedSeconds + period < track.TotalElapsedSeconds)
                {
                    while (track[index].ElapsedSeconds < track[start].ElapsedSeconds + period)
                    {
                        delta = track[index + 1].ElapsedSeconds - track[index].ElapsedSeconds;
                        value += track[index].Value * delta;
                        index++;
                    }

                    // Finish value calculation
                    per = track[index].ElapsedSeconds - track[start].ElapsedSeconds;
                    value = value / per;

                    // Add value to track - Offset will align it so that the value is centered within the period
                    smooth.Add(track.EntryDateTime(track[index]).AddSeconds(-offset), value);

                    // Remove beginning point for next cycle
                    delta = track[start + 1].ElapsedSeconds - track[start].ElapsedSeconds;
                    value = (per * value - delta * track[start].Value);

                    // Next point
                    start++;
                }

                max = smooth.Max;
                min = smooth.Min;
            }
            else if (track != null && track.Count > 0 && period == 1)
            {
                min = track.Min;
                max = track.Max;
                return track;
            }

            return smooth;
        }

        /// <summary>
        /// Formats a timespan into hh:mm:ss format.
        /// </summary>
        /// <param name="span">Timespan</param>
        /// <returns>hh:mm:ss formatted string (omits hours if less than 1 hour).  Returns empty string if timespan = 0.</returns>
        public static string ToTimeString(TimeSpan span)
        {
            if (span == TimeSpan.Zero)
            {
                // Return empty if zero.
                return string.Empty;
            }

            string displayTime;

            if ((span.Days * 24) + span.Hours > 0)
            {
                // Hours & minutes
                displayTime = ((span.Days * 24) + span.Hours).ToString("#0", CultureInfo.CurrentCulture) + ":" +
                              span.Minutes.ToString("00", CultureInfo.CurrentCulture) + ":";
            }
            else if (span.Minutes < 10)
            {
                // Single digit minutes
                displayTime = span.Minutes.ToString("#0", CultureInfo.CurrentCulture) + ":";
            }
            else
            {
                // Double digit minutes
                displayTime = span.Minutes.ToString("00", CultureInfo.CurrentCulture) + ":";
            }

            displayTime = displayTime +
                          span.Seconds.ToString("00", CultureInfo.CurrentCulture);

            return displayTime;
        }

        /// <summary>
        /// Get an icon from an image
        /// </summary>
        /// <param name="image">Icon image (bitmap)</param>
        public static Icon GetIcon(Image image)
        {
            Bitmap bitmap = image as Bitmap;

            if (bitmap != null)
            {
                return Icon.FromHandle(bitmap.GetHicon());
            }

            return null;
        }
    }
}
