using ZoneFiveSoftware.Common.Visuals.Chart;
using System;
using System.Collections.Generic;
using System.Text;
using QuadrantAnalysis.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness.CustomData;
using QuadrantAnalysis.Settings;
using System.Drawing;
using QuadrantAnalysis.Util;

namespace QuadrantAnalysis.UI.DetailPage
{
    class QAActivity
    {
        private IActivity activity;
        private TimeSpan quadTime;

        private bool isTotalsRow;

        /// <summary>
        /// Used to create the totals row
        /// </summary>
        internal QAActivity()
        {
            isTotalsRow = true;
        }

        /// <summary>
        /// Create new Quadrant Analysis activity.
        /// </summary>
        /// <param name="activity"></param>
        internal QAActivity(IActivity activity)
        {
            this.activity = activity;
            isTotalsRow = false;
        }

        /// <summary>
        /// Gets or sets the activity
        /// </summary>
        internal IActivity Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        #region IActivity Members

        public float AverageCadencePerMinuteEntered
        {
            get { return activity.AverageCadencePerMinuteEntered; }
        }

        public float AverageHeartRatePerMinuteEntered
        {
            get { return activity.AverageHeartRatePerMinuteEntered; }
        }

        public float AveragePowerWattsEntered
        {
            get { return activity.AveragePowerWattsEntered; }
        }

        public INumericTimeDataSeries CadencePerMinuteTrack
        {
            get { return activity.CadencePerMinuteTrack; }
        }

        public IActivityCategory Category
        {
            get { return activity.Category; }
        }

        public double FTP
        {
            get
            {
                ICustomDataFieldDefinition ftpDef = CustomDataFields.GetCustomProperty(CustomDataFields.TLCustomFields.FTPcycle);
                double? ftp = PluginMain.GetLogbook().Athlete.InfoEntries.LastEntryAsOfDate(activity.StartTime).GetCustomDataValue(ftpDef) as double?;

                if (ftp != null)
                {
                    return (double)ftp;
                }
                else
                {
                    // Default value of 250 if no valid entry.
                    return GlobalSettings.Instance.Power;
                }
            }
        }

        public IDistanceDataTrack DistanceMetersTrack
        {
            get { return activity.DistanceMetersTrack; }
        }

        public bool HasStartTime
        {
            get { return activity.HasStartTime; }
        }

        public INumericTimeDataSeries PowerWattsTrack
        {
            get { return activity.PowerWattsTrack; }
        }

        public string ReferenceId
        {
            get
            {
                if (IsTotalsRow)
                {
                    return "96ea252c-c80e-47f5-80dd-6c60d0681c5b";
                }

                return activity.ReferenceId;
            }
        }

        public DateTime StartTime
        {
            get { return activity.StartTime.Add(activity.TimeZoneUtcOffset); }
        }

        #endregion

        public float Q1Percent
        { get; set; }

        public float Q2Percent
        {
            get { return Q2PercentHigh + Q2PercentLow; }
        }

        public float Q2PercentLow
        { get; set; }

        public float Q2PercentHigh
        { get; set; }

        public float Q3Percent
        { get; set; }

        public float Q4Percent
        {
            get { return Q4PercentHigh + Q4PercentLow; }
        }

        public float Q4PercentLow
        { get; set; }

        public float Q4PercentHigh
        { get; set; }

        public TimeSpan Q1Time
        {
            get
            {
                double seconds = Q1Percent * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan Q2Time
        {
            get
            {
                double seconds = Q2Percent * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan Q2TimeHigh
        {
            get
            {
                double seconds = Q2PercentHigh * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan Q2TimeLow
        {
            get
            {
                double seconds = Q2PercentLow * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan Q3Time
        {
            get
            {
                double seconds = Q3Percent * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan Q4Time
        {
            get
            {
                double seconds = Q4Percent * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan Q4TimeHigh
        {
            get
            {
                double seconds = Q4PercentHigh * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan Q4TimeLow
        {
            get
            {
                double seconds = Q4PercentLow * TotalQuadTime.TotalSeconds;
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public bool IsTotalsRow
        {
            get { return isTotalsRow; }
        }

        public Color Color
        { get; set; }

        public TimeSpan TotalQuadTime
        {
            get { return quadTime; }
            set { quadTime = value; }
        }

        /// <summary>
        /// Get quadrant analysis scatter data for this activity.
        /// </summary>
        /// <param name="activity">Activity to analyze</param>
        /// <returns></returns>
        public PointPairList GetQuadAnalysis()
        {
            double pedalForce, pedalVelocity, cadence, power;

            uint lastTime = 0;
            float min, max;
            quadTime = TimeSpan.Zero;
            // TODO: (LOW) Investigate smoothing and if it helps QA in any way.
            uint smoothing = 2;

            INumericTimeDataSeries powerTrack = Util.Utilities.RemovePausedTimesInTrack(activity.PowerWattsTrack, activity);
            powerTrack = Utilities.Smooth(powerTrack, smoothing, out min, out max);
            INumericTimeDataSeries cadenceTrack = Util.Utilities.RemovePausedTimesInTrack(activity.CadencePerMinuteTrack, activity);
            cadenceTrack = Utilities.Smooth(cadenceTrack, smoothing, out min, out max);

            PointPairList quadAnalysis = new PointPairList();

            // Insufficient data exists.  Return empty dataset.
            if (cadenceTrack == null || cadenceTrack.Count == 0 ||
                powerTrack == null || powerTrack.Count == 0)
            {
                return quadAnalysis;
            }

            foreach (ITimeValueEntry<float> item in powerTrack)
            {
                DateTime time = powerTrack.EntryDateTime(item);
                uint seconds = item.ElapsedSeconds - lastTime;

                if (cadenceTrack.StartTime <= time && time <= cadenceTrack.StartTime.AddSeconds(cadenceTrack.TotalElapsedSeconds))
                {
                    cadence = cadenceTrack.GetInterpolatedValue(time).Value;
                    power = item.Value;
                    pedalForce = power / CadenceToVelocity(cadence);

                    switch (GlobalSettings.Instance.ChartType)
                    {
                        case QuadrantAnalysisDetail.ChartType.Cadence:
                            quadAnalysis.Add(new PointPair(cadence, pedalForce, seconds));
                            break;
                        case QuadrantAnalysisDetail.ChartType.PedalVelocity:
                            pedalVelocity = CadenceToVelocity(cadence);
                            quadAnalysis.Add(new PointPair(pedalVelocity, pedalForce, seconds));
                            break;
                    }

                    // Total time analyzed (needed for percentage calculations)
                    quadTime = quadTime.Add(new TimeSpan(0, 0, (int)seconds));
                }

                lastTime = item.ElapsedSeconds;
            }

            return quadAnalysis;
        }

        /// <summary>
        /// Convert cadence to pedal velocity using user defined crank length
        /// </summary>
        /// <param name="cadence"></param>
        /// <returns>pedal velocity</returns>
        public static double CadenceToVelocity(double cadence)
        {
            return cadence * (GlobalSettings.Instance.CrankLength / 1000f) * 2f * (float)Math.PI / 60f;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        public override int GetHashCode()
        {
            return ReferenceId.GetHashCode();
        }
    
    }
}
