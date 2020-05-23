using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;
using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Visuals.Chart;
using QuadrantAnalysis.Settings;
using ZoneFiveSoftware.Common.Visuals.Forms;
using ZoneFiveSoftware.Common.Data.Measurement;
using QuadrantAnalysis.Data;

namespace QuadrantAnalysis.UI.DetailPage
{
    public partial class QuadrantAnalysisDetail : UserControl
    {
        #region Fields

        private List<QAActivity> qActivities;
        private AnalysisHelp help;
        private bool maximized;
        private Point tooltipMousePt;

        #endregion

        public enum ChartType
        {
            Cadence,
            PedalVelocity
        }

        #region Properties

        public IEnumerable<IActivity> Activities
        {
            set
            {
                IList<IActivity> activities = value as IList<IActivity>;

                if (activities != null && activities.Count > 0)
                {
                    txtCadence.Enabled = true;
                    txtPower.Enabled = true;
                    txtCrank.Enabled = true;
                    txtPwrBands.Enabled = true;
                }
                else
                {
                    txtCadence.Enabled = false;
                    txtPower.Enabled = false;
                    txtCrank.Enabled = false;
                    txtPwrBands.Enabled = false;
                }

                UpdateTreelist(activities);
                RefreshPage();
                UpdateReferenceLines();
            }
        }

        #endregion

        #region Constructor

        public QuadrantAnalysisDetail()
        {
            InitializeComponent();

            MaximizeButton.Location = new Point(ChartBanner.Width - 50, 0);

            qActivities = new List<QAActivity>();

            // Setup default columns if none selected
            if (GlobalSettings.Instance.TreeColumns == null)
            {
                List<string> treeColumns = new List<string> { ColumnDefinition.Q1Percent, 
                                                               ColumnDefinition.Q2Percent, 
                                                               ColumnDefinition.Q3Percent, 
                                                               ColumnDefinition.Q4Percent };
                GlobalSettings.Instance.TreeColumns = treeColumns;
            }

            txtCrank.Text = GlobalSettings.Instance.CrankLength.ToString(CultureInfo.CurrentCulture);
            txtCadence.Text = GlobalSettings.Instance.Cadence.ToString(CultureInfo.CurrentCulture);
            txtPower.Text = GlobalSettings.Instance.Power.ToString(CultureInfo.CurrentCulture);
            txtPwrBands.Text = GlobalSettings.Instance.PowerBand.ToString(CultureInfo.CurrentCulture);

            InitializeTreelist(false);

            GraphPane myPane = zedChart.GraphPane;
            switch (GlobalSettings.Instance.ChartType)
            {
                case ChartType.PedalVelocity:
                    myPane.XAxis.Title.Text = String.Format(Resources.Strings.Label_CircumPedalVelocity, Length.LabelAbbr(Length.Units.Meter) + "/" + Time.LabelAbbr(Time.TimeRange.Second));
                    break;
                case ChartType.Cadence:
                    myPane.XAxis.Title.Text = CommonResources.Text.LabelCadence;
                    break;
            }

            myPane.YAxis.Title.Text = String.Format(Resources.Strings.Label_AvgPedalForce, "N");
            myPane.XAxis.MajorGrid.IsVisible = false;
            myPane.YAxis.MajorGrid.IsVisible = false;
            zedChart.PointValueEvent += new ZedGraphControl.PointValueHandler(zedChart_PointValueEvent);

            treeActivities.RowDataRenderer = new ActivityRowRenderer(treeActivities);

            cadenceToolStripMenuItem.Tag = ChartType.Cadence;
            pedalVelocityToolStripMenuItem.Tag = ChartType.PedalVelocity;
            foreach (ToolStripMenuItem item in chartMenu.Items)
            {
                item.Checked = (ChartType)item.Tag == GlobalSettings.Instance.ChartType;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Refresh quad analysis graph to match selected activities
        /// </summary>
        public void RefreshPage()
        {
            GraphPane myPane = zedChart.GraphPane;

            switch (GlobalSettings.Instance.ChartType)
            {
                case ChartType.Cadence:
                    myPane.XAxis.Title.Text = CommonResources.Text.LabelCadence;
                    myPane.YAxis.Title.Text = String.Format(Resources.Strings.Label_AvgPedalForce, "N");
                    break;
                case ChartType.PedalVelocity:
                    myPane.XAxis.Title.Text = String.Format(Resources.Strings.Label_CircumPedalVelocity, Length.LabelAbbr(Length.Units.Meter) + "/" + Time.LabelAbbr(Time.TimeRange.Second));
                    myPane.YAxis.Title.Text = String.Format(Resources.Strings.Label_AvgPedalForce, "N");
                    break;
            }

            myPane.XAxis.Type = AxisType.Linear;
            myPane.XAxis.MajorGrid.IsVisible = false;
            myPane.YAxis.MajorGrid.IsVisible = false;

            if (qActivities.Count > 0)
            {
                foreach (QAActivity qActivity in qActivities)
                {
                    bool alreadyAdded = false;

                    foreach (LineItem curve in zedChart.GraphPane.CurveList)
                    {
                        // Set display properties for single (2 includes the total row) or multiple activities
                        if (qActivities.Count > 2)
                        {
                            curve.Symbol.Size = 2;
                        }
                        else
                        {
                            curve.Symbol.Size = 3;
                        }

                        if (curve.Tag as string == qActivity.ReferenceId)
                        {
                            alreadyAdded = true;
                            break;
                        }
                    }

                    if (!alreadyAdded)
                    {
                        AddQuadAnalysis(qActivity);
                    }
                }

                RemoveOldActivities();
            }
            else
            {
                zedChart.GraphPane.CurveList.Clear();
            }

            zedChart.Refresh();
        }

        public void MaximizePage(bool maximize)
        {
            this.maximized = maximize;

            switch (maximize)
            {
                case true:
                    // Maximize
                    // Need to organize the controls in the parent container before settings dock properties.
                    // This sets what 'layer' things are on.
                    this.SuspendLayout();

                    this.panelMain.SuspendLayout();
                    this.panelMain.Dock = DockStyle.None;
                    this.panelMain.Location = new Point(panelConfig.Width, 0);
                    this.panelMain.Size = new Size(this.Width - panelConfig.Width, this.Height);
                    this.panelMain.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                        | AnchorStyles.Bottom | AnchorStyles.Right)));

                    this.panelActivity.SuspendLayout();
                    this.panelActivity.Dock = DockStyle.None;
                    this.panelActivity.MaximumSize = new Size(panelConfig.MaximumSize.Width, int.MaxValue);
                    this.panelActivity.Location = new Point(0, this.panelConfig.Height);
                    this.panelActivity.Size = new Size(panelConfig.Width, this.Height - this.panelConfig.Height);
                    this.panelActivity.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                        | AnchorStyles.Bottom)));

                    this.panelMain.ResumeLayout(true);
                    this.panelConfig.ResumeLayout(true);
                    this.panelActivity.ResumeLayout(true);
                    this.MaximizeButton.CenterImage = CommonResources.Images.View3PaneLowerLeft16;
                    this.ResumeLayout(true);

                    break;

                case false:
                    // Restore

                    this.SuspendLayout();

                    this.panelActivity.SuspendLayout();
                    this.panelActivity.MaximumSize = new Size(int.MaxValue, panelConfig.MaximumSize.Height);
                    this.panelActivity.Location = new Point(panelConfig.Width, 0);
                    this.panelActivity.Size = new Size(this.Width - panelConfig.Width, panelConfig.MaximumSize.Height);
                    this.panelActivity.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                        | AnchorStyles.Right)));

                    this.panelMain.SuspendLayout();
                    this.panelMain.Location = new Point(0, panelConfig.Height);
                    this.panelMain.Size = new Size(this.Width, this.Height - panelConfig.Height);
                    this.panelMain.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                        | AnchorStyles.Bottom | AnchorStyles.Right)));

                    this.panelActivity.ResumeLayout(true);
                    this.panelMain.ResumeLayout(true);
                    this.MaximizeButton.CenterImage = CommonResources.Images.View2PaneLowerHalf16;
                    this.ResumeLayout(false);

                    break;
            }

            InitializeTreelist(maximize);
        }

        /// <summary>
        /// Get a curve for a specific power
        /// </summary>
        /// <param name="power">Wattage constant to be charted</param>
        /// <returns></returns>
        private PointPairList GetPowerCurve(float power)
        {
            float cadence;
            float velocity = .25f;
            float increment = .1f;
            float force;

            PointPairList powerCurve = new PointPairList();

            while (velocity < 3)
            {
                // Calculate power curve based on pedal velocity
                force = power / velocity;

                switch (GlobalSettings.Instance.ChartType)
                {
                    case ChartType.Cadence:
                        cadence = velocity / ((GlobalSettings.Instance.CrankLength / 1000f) * 2 * (float)Math.PI / 60f);
                        powerCurve.Add(new PointPair(cadence, force));
                        break;
                    case ChartType.PedalVelocity:
                        powerCurve.Add(new PointPair(velocity, force));
                        break;
                }

                velocity += increment;
            }

            return powerCurve;
        }

        /// <summary>
        /// Add quadrant analysis of an activity to the zed chart
        /// </summary>
        /// <param name="track">Data to be displayed</param>
        internal void AddQuadAnalysis(QAActivity activity)
        {
            // Activity cannot be null
            if (activity == null || activity.IsTotalsRow)
            {
                return;
            }

            GraphPane myPane = zedChart.GraphPane;

            PointPairList quadAnalysis = activity.GetQuadAnalysis();
            string refId = activity.ReferenceId;

            // Quadrant Analysis Scatter plot
            Color color = Common.GetRandomColor();
            activity.Color = color;
            LineItem quadScatter = myPane.AddCurve(activity.StartTime.Add(activity.Activity.TimeZoneUtcOffset).Date.ToShortDateString(), quadAnalysis, color, SymbolType.Circle);
            quadScatter.Tag = activity.ReferenceId;

            if (qActivities.Count > 2)
            {
                quadScatter.Symbol.Size = 2;
            }
            else
            {
                quadScatter.Symbol.Size = 3;
            }

            quadScatter.Symbol.IsAntiAlias = true;
            quadScatter.Line.IsVisible = false;

            ZoomChartButton_Click(null, null);
        }

        /// <summary>
        /// Update visual theme
        /// </summary>
        /// <param name="visualTheme"></param>
        public void ThemeChanged(ITheme visualTheme)
        {
            ButtonPanel.ThemeChanged(visualTheme);
            ButtonPanel.BackColor = visualTheme.Window;
            ChartBanner.ThemeChanged(visualTheme);
            panelMain.ThemeChanged(visualTheme);
            panelMain.BackColor = visualTheme.Window;
            panelConfig.BackColor = visualTheme.Control;
            zedThemeChanged(visualTheme, zedChart);
            txtPower.ThemeChanged(visualTheme);
            txtPwrBands.ThemeChanged(visualTheme);
            txtCadence.ThemeChanged(visualTheme);
            txtCrank.ThemeChanged(visualTheme);
            treeActivities.ThemeChanged(visualTheme);

            menuTree.Renderer = new ThemedContextMenuStripRenderer(visualTheme);
            chartMenu.Renderer = new ThemedContextMenuStripRenderer(visualTheme);
        }

        /// <summary>
        /// Setup zed chart to look like ST charts.  Everything here should be generic (colors, fonts, etc.), not specific to the plugin data.
        /// </summary>
        /// <param name="visualTheme"></param>
        /// <param name="graph"></param>
        private void zedThemeChanged(ITheme visualTheme, ZedGraphControl graph)
        {
            GraphPane myPane = graph.GraphPane;

            // Overall appearance settings
            graph.BorderStyle = BorderStyle.None;
            myPane.Legend.IsVisible = false;
            myPane.Border.IsVisible = false;
            myPane.Title.IsVisible = false;

            // Add a background color
            myPane.Fill.Color = visualTheme.Window;
            myPane.Chart.Fill = new Fill(visualTheme.Window);
            myPane.Chart.Border.IsVisible = false;

            // Add gridlines to the plot, and make them gray
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.DarkGray;
            myPane.YAxis.MajorGrid.Color = myPane.XAxis.MajorGrid.Color;
            myPane.XAxis.MajorGrid.DashOff = 1f;
            myPane.XAxis.MajorGrid.DashOff = myPane.XAxis.MajorGrid.DashOn;
            myPane.YAxis.MajorGrid.DashOff = myPane.XAxis.MajorGrid.DashOn;
            myPane.YAxis.MajorGrid.DashOff = myPane.YAxis.MajorGrid.DashOn;
            myPane.XAxis.IsAxisSegmentVisible = true;
            myPane.YAxis.IsAxisSegmentVisible = true;
            myPane.XAxis.MajorGrid.IsZeroLine = false;
            myPane.YAxis.MajorGrid.IsZeroLine = false;

            // Update axis Tic marks
            myPane.XAxis.MinorTic.IsAllTics = false;
            myPane.XAxis.MajorTic.IsAllTics = false;
            myPane.YAxis.MinorTic.IsAllTics = false;
            myPane.YAxis.MajorTic.IsAllTics = false;
            myPane.XAxis.MajorTic.IsOutside = true;
            myPane.YAxis.MajorTic.IsOutside = true;

            // Setup Text Appearance
            string fontName = "Microsoft Sans Sarif";
            myPane.IsFontsScaled = false;
            myPane.XAxis.Title.FontSpec.Family = fontName;
            myPane.XAxis.Title.FontSpec.IsBold = true;
            myPane.XAxis.Scale.FontSpec.Family = fontName;
            myPane.XAxis.Scale.IsUseTenPower = false;

            // Setup Legend
            //myPane.Legend.IsVisible = true;
            //myPane.Legend.FontSpec.Family = fontName;
            //myPane.Legend.FontSpec.IsBold = false;
            //myPane.Legend.Border.IsVisible = false;
            //myPane.Legend.Fill = new Fill(visualTheme.Window);
            //myPane.Legend.IsHStack = true;

            Color mainCurveColor;
            if (myPane.CurveList.Count > 0)
            {
                mainCurveColor = myPane.CurveList[0].Color;
            }
            else
            {
                mainCurveColor = Color.Black;
            }

            myPane.YAxis.Title.FontSpec.Family = fontName;
            myPane.YAxis.Title.FontSpec.IsBold = true;
            myPane.YAxis.Title.FontSpec.FontColor = mainCurveColor;
            myPane.YAxis.Scale.FontSpec.FontColor = mainCurveColor;
            myPane.YAxis.Scale.FontSpec.Family = fontName;

            zedChart.Refresh();
        }

        public void UICultureChanged(CultureInfo culture)
        {
            ChartBanner.Text = Resources.Strings.Label_QuadrantAnalysis;
            lblCadence.Text = CommonResources.Text.LabelCadence;
            lblPower.Text = CommonResources.Text.LabelPower;
            lblRange.Text = CommonResources.Text.LabelRange + " (±%)";
            lblCrankLength.Text = Resources.Strings.Label_CrankLength;
            cadenceToolStripMenuItem.Text = CommonResources.Text.LabelCadence;
            pedalVelocityToolStripMenuItem.Text = String.Format(Resources.Strings.Label_CircumPedalVelocity, Length.LabelAbbr(Length.Units.Meter) + "/" + Time.LabelAbbr(Time.TimeRange.Second));
            listSettingsMenuItem.Text = Resources.Strings.Label_ListSettings + "...";
        }

        /// <summary>
        /// Initializes the treelist adding the appropriate columns for quadrant analysis.
        /// </summary>
        private void InitializeTreelist(bool maximized)
        {
            treeActivities.Columns.Clear();
            treeActivities.Columns.Add(new TreeList.Column("check", string.Empty, 20, StringAlignment.Near));
            treeActivities.Columns.Add(new TreeList.Column("id", string.Empty, 20, StringAlignment.Near));
            treeActivities.Columns.Add(new TreeList.Column("StartTime", CommonResources.Text.LabelStartTime, 100, StringAlignment.Near));

            if (!maximized)
            {
                foreach (string id in GlobalSettings.Instance.TreeColumns)
                {
                    ColumnDefinition column = new ColumnDefinition(id);
                    treeActivities.Columns.Add(new TreeList.Column(column.Id, column.Text(column.Id), column.Width, StringAlignment.Far));
                }
            }

            treeActivities.CheckBoxes = true;
        }

        /// <summary>
        /// Updates the Treelist adding (if necessary) the new activity to the list, and also updates the QA data as well.
        /// </summary>
        /// <param name="activity"></param>
        private void UpdateTreelist(IEnumerable<IActivity> activities)
        {
            // Create lists of QActivities for later use
            List<QAActivity> newQActivities = new List<QAActivity>();
            IList<QAActivity> checkedQActivities = new List<QAActivity>();
            foreach (QAActivity qActivity in treeActivities.CheckedElements as ArrayList)
            {
                if (!qActivity.IsTotalsRow)
                    checkedQActivities.Add(qActivity);
            }

            if (activities != null)
            {
                foreach (IActivity activity in activities)
                {
                    if (activity != null)
                        newQActivities.Add(new QAActivity(activity));
                }
            }

            // Remove old activities
            foreach (QAActivity qActivity in new List<QAActivity>(qActivities))
            {
                if (!checkedQActivities.Contains(qActivity) && !newQActivities.Contains(qActivity))
                {
                    qActivities.Remove(qActivity);
                }
            }

            // Add new activities
            foreach (QAActivity qActivity in newQActivities)
            {
                // Add the new activity to the list (if it's not already there)
                if (!qActivities.Contains(qActivity))
                {
                    qActivities.Add(qActivity);
                }
            }

            // Update FTP if this is only 1 activity
            if (qActivities.Count == 1)
            {
                GlobalSettings.Instance.Power = (int)qActivities[0].FTP;
                txtPower.Text = GlobalSettings.Instance.Power.ToString();
            }

            // Add totals row
            if (qActivities.Count > 0)
            {
                qActivities.Add(new QAActivity());
            }

            treeActivities.RowData = qActivities;
        }

        /// <summary>
        /// Removes activities from the zed chart that are no longer included in the selection tree
        /// </summary>
        private void RemoveOldActivities()
        {
            // Remove excluded activities from the chart
            for (int i = 0; i < zedChart.GraphPane.CurveList.Count; )
            {
                bool validCurve = false;

                foreach (QAActivity qActivity in treeActivities.RowData as List<QAActivity>)
                {
                    string id = zedChart.GraphPane.CurveList[i].Tag as string;
                    if (id == qActivity.ReferenceId || id == "Power" || id == "horizLine" || id == "vertLine")
                    {
                        validCurve = true;
                        break;
                    }
                }
                if (!validCurve)
                {
                    // Curve has been discarded, remove it
                    zedChart.GraphPane.CurveList.RemoveAt(i);
                }
                else
                {
                    // Becasue the length of this list is dynamically changing, only increment the index if an item is not removed.
                    i++;
                }
            }
        }

        /// <summary>
        /// Update the power line, vertical, and horizontal lines
        /// </summary>
        private void UpdateReferenceLines()
        {
            GraphPane myPane = zedChart.GraphPane;

            // Remove static lines in order to replace them
            for (int i = 0; i < zedChart.GraphPane.CurveList.Count; )
            {
                string lineId = zedChart.GraphPane.CurveList[i].Tag as string;

                if (lineId == "Power" || lineId == "horizLine" || lineId == "vertLine")
                {
                    zedChart.GraphPane.CurveList.RemoveAt(i);
                }
                else
                {
                    // Becasue the length of this list is dynamically changing, only increment the index if an item is not removed.
                    i++;
                }
            }

            // Add Power Curve
            float bandPercent = (float)GlobalSettings.Instance.PowerBand / 100f;
            PointPairList powerPoints = GetPowerCurve(GlobalSettings.Instance.Power);
            PointPairList powerPointsHi = GetPowerCurve((float)GlobalSettings.Instance.Power * (1f + bandPercent));
            PointPairList powerPointsLo = GetPowerCurve((float)GlobalSettings.Instance.Power * (1f - bandPercent));
            Color color = Color.Blue;
            LineItem powerCurve = myPane.AddCurve(CommonResources.Text.LabelPower + ": " + GlobalSettings.Instance.Power.ToString("#", CultureInfo.CurrentCulture), powerPoints, color, SymbolType.None);
            powerCurve.Tag = "Power";
            powerCurve.Label.IsVisible = false;
            powerCurve.Line.IsAntiAlias = true;

            color = Color.Red;
            LineItem powerCurveHi = myPane.AddCurve(CommonResources.Text.LabelPower + ": " + (GlobalSettings.Instance.Power * (1 + bandPercent)).ToString("#", CultureInfo.CurrentCulture), powerPointsHi, color, SymbolType.None);
            powerCurveHi.Tag = "Power";
            powerCurveHi.Label.IsVisible = false;
            powerCurveHi.Line.IsAntiAlias = true;

            LineItem powerCurveLo = myPane.AddCurve(CommonResources.Text.LabelPower + ": " + (GlobalSettings.Instance.Power * (1 - bandPercent)).ToString("#", CultureInfo.CurrentCulture), powerPointsLo, color, SymbolType.None);
            powerCurveLo.Tag = "Power";
            powerCurveLo.Label.IsVisible = false;
            powerCurveLo.Line.IsAntiAlias = true;

            // Add Quadrant Dividers: Vertical, then Horizontal
            float pedalVelocity = GlobalSettings.Instance.Cadence * (GlobalSettings.Instance.CrankLength / 1000f) * 2f * (float)Math.PI / 60f;

            float xIntercept, xmin, xmax;
            switch (GlobalSettings.Instance.ChartType)
            {
                case ChartType.PedalVelocity:
                    xIntercept = pedalVelocity;
                    xmin = (float)QAActivity.CadenceToVelocity(20);
                    xmax = (float)QAActivity.CadenceToVelocity(140);
                    break;
                default:
                case ChartType.Cadence:
                    xIntercept = GlobalSettings.Instance.Cadence;
                    xmin = 20;
                    xmax = 140;
                    break;
            }

            double[] x = new double[2] { xIntercept, xIntercept };
            double[] y = new double[2] { 0, 700 };
            LineItem vertLine = myPane.AddCurve("Vertical", x, y, Color.DimGray, SymbolType.None);
            vertLine.Tag = "vertLine";
            vertLine.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            vertLine.Line.Width = 1.9f;
            vertLine.Label.IsVisible = false;

            float pedalForce = GlobalSettings.Instance.Power * 60f / (GlobalSettings.Instance.Cadence * 2f * (float)Math.PI * (GlobalSettings.Instance.CrankLength / 1000f));

            x = new double[2] { xmin, xmax };
            y = new double[2] { pedalForce, pedalForce };
            LineItem horizLine = myPane.AddCurve("Horizontal", x, y, Color.DimGray, SymbolType.None);
            horizLine.Tag = "horizLine";
            horizLine.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            horizLine.Line.Width = 1.9f;
            horizLine.Label.IsVisible = false;

            // Update activities to match new lines
            foreach (QAActivity activity in qActivities)
            {
                foreach (CurveItem curve in zedChart.GraphPane.CurveList)
                {
                    if (curve.Tag as string == activity.ReferenceId)
                    {
                        double q1 = 0, q2h = 0, q2l = 0, q3 = 0, q4h = 0, q4l = 0;

                        for (int i = 0; i < curve.Points.Count; i++)
                        {
                            PointPair point = curve.Points[i];

                            if (point.X > xIntercept)
                            {
                                if (point.Y > pedalForce)
                                {
                                    // Add to quad 1
                                    q1 += point.Z;
                                }
                                else
                                {
                                    double temp = powerPoints.InterpolateX(point.X);
                                    if (point.Y > temp)
                                    {
                                        // Add to quad 4 (high)
                                        q4h += point.Z;
                                    }
                                    else
                                    {
                                        // Add to quad 4 (low)
                                        q4l += point.Z;
                                    }
                                }
                            }
                            else
                            {
                                if (point.Y > pedalForce)
                                {
                                    if (point.Y > powerPoints.InterpolateX(point.X))
                                    {
                                        // Add to quad 2 (high)
                                        q2h += point.Z;
                                    }
                                    else
                                    {
                                        // Add to quad 2 (low)
                                        q2l += point.Z;
                                    }
                                }
                                else
                                {
                                    // Add to quad 3
                                    q3 += point.Z;
                                }
                            }
                        }

                        if (activity.TotalQuadTime != TimeSpan.Zero)
                        {
                            // Assign activity values
                            activity.Q1Percent = (float)(q1 / activity.TotalQuadTime.TotalSeconds);
                            activity.Q2PercentHigh = (float)(q2h / activity.TotalQuadTime.TotalSeconds);
                            activity.Q2PercentLow = (float)(q2l / activity.TotalQuadTime.TotalSeconds);
                            activity.Q3Percent = (float)(q3 / activity.TotalQuadTime.TotalSeconds);
                            activity.Q4PercentHigh = (float)(q4h / activity.TotalQuadTime.TotalSeconds);
                            activity.Q4PercentLow = (float)(q4l / activity.TotalQuadTime.TotalSeconds);
                        }
                    }
                }
            }

            // Calculate 'totals' data
            QAActivity totalRow = null;
            double[] totalSeconds = { 0, 0, 0, 0, 0, 0, 0 };
            foreach (QAActivity qActivity in qActivities)
            {
                if (!qActivity.IsTotalsRow)
                {
                    totalSeconds[0] += qActivity.TotalQuadTime.TotalSeconds;
                    totalSeconds[1] += qActivity.Q1Time.TotalSeconds;
                    totalSeconds[2] += qActivity.Q2TimeHigh.TotalSeconds;
                    totalSeconds[3] += qActivity.Q2TimeLow.TotalSeconds;
                    totalSeconds[4] += qActivity.Q3Time.TotalSeconds;
                    totalSeconds[5] += qActivity.Q4TimeHigh.TotalSeconds;
                    totalSeconds[6] += qActivity.Q4TimeLow.TotalSeconds;
                }
                else
                {
                    totalRow = qActivity;
                }
            }

            // Add Totals Row to treelist
            if (totalRow != null && totalSeconds[0] != 0)
            {
                totalRow.TotalQuadTime = TimeSpan.FromSeconds(totalSeconds[0]);
                totalRow.Q1Percent = (float)(totalSeconds[1] / totalSeconds[0]);
                totalRow.Q2PercentHigh = (float)(totalSeconds[2] / totalSeconds[0]);
                totalRow.Q2PercentLow = (float)(totalSeconds[3] / totalSeconds[0]);
                totalRow.Q3Percent = (float)(totalSeconds[4] / totalSeconds[0]);
                totalRow.Q4PercentHigh = (float)(totalSeconds[5] / totalSeconds[0]);
                totalRow.Q4PercentLow = (float)(totalSeconds[6] / totalSeconds[0]);

                string message13 = "{0}\r\n "
                                    + CommonResources.Text.LabelTime + ": {2}\r\n "
                                    + CommonResources.Text.LabelPercent + ": {1}";
                string message24 = "{0}\r\n "
                                    + CommonResources.Text.LabelTime + ": {2}\r\n   >"
                                    + CommonResources.Text.LabelPower + ": {5}\r\n   <"
                                    + CommonResources.Text.LabelPower + ": {6}\r\n "
                                    + CommonResources.Text.LabelPercent + ": {1}\r\n   >"
                                    + CommonResources.Text.LabelPower + ": {3}\r\n   <"
                                    + CommonResources.Text.LabelPower + ": {4}";
                object[] args1 = { "Quadrant 1" 
                                    , totalRow.Q1Percent.ToString("P1", CultureInfo.CurrentCulture)
                                    , TimeSpan.FromSeconds(totalSeconds[1])};

                object[] args2 = { "Quadrant 2" 
                                    , totalRow.Q2Percent.ToString("P1", CultureInfo.CurrentCulture)
                                    , TimeSpan.FromSeconds(totalSeconds[2] + totalSeconds[3])
                                    , totalRow.Q2PercentHigh.ToString("P1",CultureInfo.CurrentCulture)
                                    , totalRow.Q2PercentLow.ToString("P1",CultureInfo.CurrentCulture)
                                    , TimeSpan.FromSeconds(totalSeconds[2])
                                    , TimeSpan.FromSeconds(totalSeconds[3])};

                object[] args3 = { "Quadrant 3" 
                                    , totalRow.Q3Percent.ToString("P1", CultureInfo.CurrentCulture)
                                    , TimeSpan.FromSeconds(totalSeconds[4])};

                object[] args4 = { "Quadrant 4" 
                                    , totalRow.Q4Percent.ToString("P1", CultureInfo.CurrentCulture)
                                    , TimeSpan.FromSeconds(totalSeconds[5] + totalSeconds[6])
                                    , totalRow.Q4PercentHigh.ToString("P1",CultureInfo.CurrentCulture)
                                    , totalRow.Q4PercentLow.ToString("P1",CultureInfo.CurrentCulture)
                                    , TimeSpan.FromSeconds(totalSeconds[5])
                                    , TimeSpan.FromSeconds(totalSeconds[6])};

                lblQ1.Text = String.Format(message13, args1);
                lblQ2.Text = String.Format(message24, args2);
                lblQ3.Text = String.Format(message13, args3);
                lblQ4.Text = String.Format(message24, args4);
            }
            else
            {
                lblQ1.Text = "Q1";
                lblQ2.Text = "Q2";
                lblQ3.Text = "Q3";
                lblQ4.Text = "Q4";
            }

            treeActivities.Refresh();
            zedChart.Refresh();
            zedChart.AxisChange();
        }

        private void ZoomFit()
        {
            GraphPane myPane = zedChart.GraphPane;

            // Chart setup min/max bounds
            switch (GlobalSettings.Instance.ChartType)
            {
                case ChartType.Cadence:
                    myPane.XAxis.Scale.Max = 140;
                    myPane.YAxis.Scale.Max = 700;
                    myPane.XAxis.Scale.Min = 20;
                    myPane.YAxis.Scale.Min = 0;
                    break;
                case ChartType.PedalVelocity:
                    myPane.XAxis.Scale.Max = QAActivity.CadenceToVelocity(140);
                    myPane.YAxis.Scale.Max = 700;
                    myPane.XAxis.Scale.Min = QAActivity.CadenceToVelocity(20);
                    myPane.YAxis.Scale.Min = 0;
                    break;
            }

            zedChart.Refresh();
            zedChart.AxisChange();
            //zedChart.ZoomOutAll(zedChart.GraphPane);
        }

        #endregion

        #region EventHandlers

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (help == null || help.IsDisposed)
            {
                help = new AnalysisHelp();
            }

            help.Show();
        }

        /// <summary>
        /// Add a user defined floating power curve.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void btnPower_Click(object sender, EventArgs e)
        {
            // Toggle button to selected or not
            btnPower.Selected = !btnPower.Selected;

            if (btnPower.Selected)
            {
                // Turn feature on - begin floating line
                zedChart.MouseClick += zedChart_MouseClick;
                zedChart.MouseMove += zedChart_MouseMove;
            }
            else
            {
                // Abort feature - remove handlers and line if it exists
                zedChart.MouseClick -= zedChart_MouseClick;
                zedChart.MouseMove -= zedChart_MouseMove;

                int index = zedChart.GraphPane.CurveList.IndexOfTag("UserPower");
                if (index != -1)
                {
                    zedChart.GraphPane.CurveList.RemoveAt(index);
                    zedChart.Refresh();
                }
            }
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            Maximize.Invoke(sender, e);
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            ITheme theme = PluginMain.GetApplication().VisualTheme;

            SaveImageDialog save = new SaveImageDialog();
            save.ThemeChanged(theme);
            save.CanChangeImageSize = false;

            save.FileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                            Resources.Strings.Label_QuadrantAnalysis + " " + DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture));

            if (save.ShowDialog() == DialogResult.OK)
            {
                // Image Saved (save occurs in SaveDialog)
                string filename = save.FileName;

                if (System.IO.File.Exists(filename))
                {
                    if (MessageDialog.Show("File exists.  Overwrite?", "File Save", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                zedChart.GetImage().Save(save.FileName, save.ImageFormat);
            }

            save.Dispose();

        }

        private void ZoomChartButton_Click(object sender, EventArgs e)
        {
            ZoomFit();
        }

        private void zedChart_DoubleClick(object sender, EventArgs e)
        {
            ZoomFit();
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            zedChart.ZoomPane(zedChart.GraphPane, 1.1, zedChart.GraphPane.Chart.Rect.Location, false);
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            zedChart.ZoomPane(zedChart.GraphPane, 0.9, zedChart.GraphPane.Chart.Rect.Location, false);
        }

        private void txtPower_Leave(object sender, EventArgs e)
        {
            int result;

            if (!int.TryParse(txtPower.Text, out result) && qActivities.Count > 0)
            {
                txtPower.Text = GlobalSettings.Instance.Power.ToString("#", CultureInfo.CurrentCulture);
            }
            else
            {
                GlobalSettings.Instance.Power = result;
                UpdateReferenceLines();
            }
        }

        private void txtPwrBands_Leave(object sender, EventArgs e)
        {
            ZoneFiveSoftware.Common.Visuals.TextBox textbox = sender as ZoneFiveSoftware.Common.Visuals.TextBox;
            int result;

            if (!int.TryParse(textbox.Text, out result) && qActivities.Count > 0)
            {
                textbox.Text = GlobalSettings.Instance.PowerBand.ToString("#", CultureInfo.CurrentCulture);
            }
            else
            {
                GlobalSettings.Instance.PowerBand = result;
                UpdateReferenceLines();
            }
        }

        private void txtCadence_Leave(object sender, EventArgs e)
        {
            int result;

            if (!int.TryParse(txtCadence.Text, out result) && qActivities.Count > 0)
            {
                txtCadence.Text = GlobalSettings.Instance.Cadence.ToString("#", CultureInfo.CurrentCulture);
            }
            else
            {
                GlobalSettings.Instance.Cadence = result;
                UpdateReferenceLines();
            }
        }

        private void txtCrank_Leave(object sender, EventArgs e)
        {
            float result;

            if (!float.TryParse(txtCrank.Text, out result) && qActivities.Count > 0)
            {
                txtCrank.Text = GlobalSettings.Instance.CrankLength.ToString("#.#", CultureInfo.CurrentCulture);
            }
            else
            {
                GlobalSettings.Instance.CrankLength = result;
                UpdateReferenceLines();
            }
        }

        private void ChartBanner_MenuClicked(object sender, EventArgs e)
        {
            chartMenu.Show(ChartBanner.Parent.PointToScreen(new System.Drawing.Point(ChartBanner.Right - chartMenu.Width - 2, ChartBanner.Bottom + 1)));
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selected = sender as ToolStripMenuItem;

            if ((ChartType)selected.Tag == GlobalSettings.Instance.ChartType)
            {
                // Menu is already selected.  Nothing to do.
                return;
            }

            foreach (ToolStripMenuItem item in chartMenu.Items)
            {
                if (item != selected)
                {
                    item.Checked = false;
                }
                else
                {
                    item.Checked = true;
                }
            }


            GlobalSettings.Instance.ChartType = (ChartType)selected.Tag;
            ChartBanner.Text = selected.Text;
            zedChart.GraphPane.CurveList.Clear();
            UpdateReferenceLines();
            RefreshPage();
        }

        /// <summary>
        /// Formats the tooltip popups
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="pane">The parameter is not used.</param>
        /// <param name="curve">The curve containing the points</param>
        /// <param name="iPt">The index of the point of interest</param>
        /// <returns>A tooltip string</returns>
        string zedChart_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            if (MousePosition != tooltipMousePt)
            {
                string tooltip = curve.Label.Text;

                chartToolTip.SetToolTip(sender, tooltip);
                tooltipMousePt = MousePosition;
            }

            return default(string);
        }

        /// <summary>
        /// Float a power line on the QA chart.
        /// </summary>
        /// <param name="sender">zedChart</param>
        /// <param name="e">Mouse Location (to be converted to graph points)</param>
        private void zedChart_MouseMove(object sender, MouseEventArgs e)
        {
            ZedGraphControl chart = sender as ZedGraphControl;
            GraphPane myPane = chart.GraphPane;

            // Get calculated values
            double cadence, force;
            chart.GraphPane.ReverseTransform(e.Location, out cadence, out force);
            float pedalForce = GlobalSettings.Instance.Power / (float)QAActivity.CadenceToVelocity(GlobalSettings.Instance.Cadence);

            // Power line at current coordinate
            float power = (float)(force * QAActivity.CadenceToVelocity(cadence));

            // Draw Power Curve
            PointPairList powerPoints = GetPowerCurve(power);
            CurveItem powerCurve;
            Color color = Color.Navy;
            int index = myPane.CurveList.IndexOfTag("UserPower");
            if (index == -1)
            {
                // New Line
                powerCurve = myPane.AddCurve(CommonResources.Text.LabelPower + ": " + power.ToString("#", CultureInfo.CurrentCulture), powerPoints, color, SymbolType.None);
                powerCurve.Tag = "UserPower";
                powerCurve.Label.IsVisible = false;
            }
            else
            {
                // Update exsiting
                powerCurve = myPane.CurveList[index];
                powerCurve.Points = powerPoints;
                powerCurve.Label.Text = CommonResources.Text.LabelPower + ": " + power.ToString("#", CultureInfo.CurrentCulture);
            }

            chart.Refresh();
        }

        private void zedChart_MouseClick(object sender, MouseEventArgs e)
        {
            zedChart.MouseMove -= zedChart_MouseMove;
            zedChart.MouseClick -= zedChart_MouseClick;
            btnPower.Selected = false;
        }

        private void menuTreeItem_Click(object sender, EventArgs e)
        {
            ListSettingsDialog listDialog = new ListSettingsDialog();
            ICollection<IListColumnDefinition> available = new List<IListColumnDefinition>();

            available.Add(new ColumnDefinition(ColumnDefinition.Q1Percent));
            available.Add(new ColumnDefinition(ColumnDefinition.Q2Percent));
            available.Add(new ColumnDefinition(ColumnDefinition.Q2PercentHigh));
            available.Add(new ColumnDefinition(ColumnDefinition.Q2PercentLow));
            available.Add(new ColumnDefinition(ColumnDefinition.Q3Percent));
            available.Add(new ColumnDefinition(ColumnDefinition.Q4Percent));
            available.Add(new ColumnDefinition(ColumnDefinition.Q4PercentHigh));
            available.Add(new ColumnDefinition(ColumnDefinition.Q4PercentLow));
            available.Add(new ColumnDefinition(ColumnDefinition.Q1Time));
            available.Add(new ColumnDefinition(ColumnDefinition.Q2Time));
            available.Add(new ColumnDefinition(ColumnDefinition.Q2TimeHigh));
            available.Add(new ColumnDefinition(ColumnDefinition.Q2TimeLow));
            available.Add(new ColumnDefinition(ColumnDefinition.Q3Time));
            available.Add(new ColumnDefinition(ColumnDefinition.Q4Time));
            available.Add(new ColumnDefinition(ColumnDefinition.Q4TimeHigh));
            available.Add(new ColumnDefinition(ColumnDefinition.Q4TimeLow));

            listDialog.AvailableColumns = available;

            List<string> selected = new List<string>();

            foreach (string id in GlobalSettings.Instance.TreeColumns)
            {
                ColumnDefinition value = new ColumnDefinition(id);

                if (available.Contains(value) && !selected.Contains(id))
                {
                    selected.Add(id);
                }
            }

            listDialog.SelectedColumns = selected;
            listDialog.Text = CommonResources.Text.LabelCharts;
            listDialog.SelectedItemListLabel = Resources.Strings.Label_SelectedCharts;
            listDialog.AddButtonLabel = CommonResources.Text.ActionAdd;
            listDialog.AllowFixedColumnSelect = false;
            listDialog.AllowZeroSelected = true;
            listDialog.Icon = Util.Utilities.GetIcon(Resources.Images.Charts);

            listDialog.ThemeChanged(PluginMain.GetApplication().VisualTheme);

            if (listDialog.ShowDialog() == DialogResult.OK)
            {
                GlobalSettings.Instance.TreeColumns = listDialog.SelectedColumns as List<string>;

                InitializeTreelist(maximized);

                RefreshPage();
            }

            listDialog.Close();
            listDialog.Dispose();

            return;
        }

        #endregion

        #region Events

        internal event EventHandler Maximize;

        #endregion

    }
}
