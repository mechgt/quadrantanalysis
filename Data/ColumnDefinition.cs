using System.Drawing;
using ZoneFiveSoftware.Common.Visuals;
using QuadrantAnalysis.Resources;
using System.Globalization;
using System.Xml.Serialization;

namespace QuadrantAnalysis.Data
{
    [XmlRootAttribute("ColumnDefinition")]
    public class ColumnDefinition : IListColumnDefinition
    {
        public const string Q1Time = "Q1Time";
        public const string Q2Time = "Q2Time";
        public const string Q2TimeHigh = "Q2TimeHigh";
        public const string Q2TimeLow = "Q2TimeLow";
        public const string Q3Time = "Q3Time";
        public const string Q4Time = "Q4Time";
        public const string Q4TimeHigh = "Q4TimeHigh";
        public const string Q4TimeLow = "Q4TimeLow";
        public const string Q1Percent = "Q1Percent";
        public const string Q2Percent = "Q2Percent";
        public const string Q2PercentHigh = "Q2PercentHigh";
        public const string Q2PercentLow = "Q2PercentLow";
        public const string Q3Percent = "Q3Percent";
        public const string Q4Percent = "Q4Percent";
        public const string Q4PercentHigh = "Q4PercentHigh";
        public const string Q4PercentLow = "Q4PercentLow";

        private string id;

        public ColumnDefinition(string id)
        {
            this.id = id;
        }

        #region IListColumnDefinition Members

        public StringAlignment Align
        {
            get { return StringAlignment.Far; }
        }

        public string GroupName
        {
            get { return null; }
        }

        public string Id
        {
            get { return id; }
        }

        public string Text(string columnId)
        {
            return GetText(columnId);
        }

        public override string ToString()
        {
            return Text(id);
        }

        public int Width
        {
            get
            {
                if (id == Q1Percent ||
                    id == Q2Percent ||
                    id == Q3Percent ||
                    id == Q4Percent ||
                    id == Q2PercentHigh ||
                    id == Q2PercentLow ||
                    id == Q4PercentHigh ||
                    id == Q4PercentLow)
                {
                    return 50;
                }
                else if (id == Q1Time ||
                    id == Q2Time ||
                    id == Q3Time ||
                    id == Q4Time ||
                    id == Q2TimeHigh ||
                    id == Q2TimeLow ||
                    id == Q4TimeHigh ||
                    id == Q4TimeLow)
                {
                    return 55;
                }

                // Default width
                return 50;
            }
        }

        #endregion

        /// <summary>
        /// Get the Text associated with the id requested.  Will return columnId if no match or bad data.
        /// </summary>
        /// <param name="columnId">The chart id requested.  See ColumnDefinition chart field constants.</param>
        /// <returns>Localized Text associated with id.  Returns columnId if no match or bad data found.</returns>
        internal static string GetText(string columnId)
        {
            string Q = Strings.Label_QuadrantAnalysis.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture);

            switch (columnId)
            {
                case Q1Percent:
                    return Q + "1 " + CommonResources.Text.LabelPercent;
                case Q2Percent:
                    return Q + "2 " + CommonResources.Text.LabelPercent;
                case Q3Percent:
                    return Q + "3 " + CommonResources.Text.LabelPercent;
                case Q4Percent:
                    return Q + "4 " + CommonResources.Text.LabelPercent;

                case Q1Time:
                    return Q + "1 " + CommonResources.Text.LabelTime;
                case Q2Time:
                    return Q + "2 " + CommonResources.Text.LabelTime;
                case Q3Time:
                    return Q + "3 " + CommonResources.Text.LabelTime;
                case Q4Time:
                    return Q + "4 " + CommonResources.Text.LabelTime;

                case Q2TimeHigh:
                    return Q + "2 > " + CommonResources.Text.LabelPower;
                case Q2TimeLow:
                    return Q + "2 < " + CommonResources.Text.LabelPower;
                case Q4TimeHigh:
                    return Q + "4 > " + CommonResources.Text.LabelPower;
                case Q4TimeLow:
                    return Q + "4 < " + CommonResources.Text.LabelPower;

                case Q2PercentHigh:
                    return Q + "2% > " + CommonResources.Text.LabelPower;
                case Q2PercentLow:
                    return Q + "2% < " + CommonResources.Text.LabelPower;
                case Q4PercentHigh:
                    return Q + "4% > " + CommonResources.Text.LabelPower;
                case Q4PercentLow:
                    return Q + "4% < " + CommonResources.Text.LabelPower;
            }

            return columnId;
        }

        public override bool Equals(object obj)
        {
            ColumnDefinition col = obj as ColumnDefinition;

            if (col == null)
            {
                return false;
            }

            return this.Id == col.Id;
        }
    }
}
