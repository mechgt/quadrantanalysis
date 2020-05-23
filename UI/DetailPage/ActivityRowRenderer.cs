using System;
using System.Collections.Generic;
using System.Text;
using ZoneFiveSoftware.Common.Visuals;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace QuadrantAnalysis.UI.DetailPage
{
    class ActivityRowRenderer : TreeList.DefaultRowDataRenderer
    {
        public ActivityRowRenderer(TreeList tree)
            : base(tree)
        {
        }

        protected override void DrawCell(Graphics graphics, TreeList.DrawItemState rowState, object element, TreeList.Column column, Rectangle cellRect)
        {
            QAActivity activity = element as QAActivity;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = column.TextAlign;
                

            // Draw colored square in column 1
            if (column.Id == "id" && activity != null && activity.Color != Color.Empty)
            {
                Brush selectedBrush = new SolidBrush(activity.Color);
                graphics.FillRectangle(selectedBrush, cellRect);
            }

            if (column.Id == "Q1Percent" ||
                column.Id == "Q2Percent" ||
                column.Id == "Q3Percent" ||
                column.Id == "Q4Percent" ||
                column.Id == "Q2PercentHigh" ||
                column.Id == "Q2PercentLow" ||
                column.Id == "Q4PercentHigh" ||
                column.Id == "Q4PercentLow")
            {            
                // Display percentage in appropriate format
                Type type = typeof(QAActivity);
                float value = (float)type.GetProperty(column.Id).GetValue(activity, null);

                graphics.DrawString(value.ToString("P1", CultureInfo.CurrentCulture),
                                    base.Font(GetCellFontStyle(element, column)),
                                    new SolidBrush(PluginMain.GetApplication().VisualTheme.ControlText),
                                    cellRect, stringFormat);
            }
            else if (column.Id == "Q1Time" ||
                     column.Id == "Q2Time" ||
                     column.Id == "Q2TimeHigh" ||
                     column.Id == "Q2TimeLow" ||
                     column.Id == "Q3Time" ||
                     column.Id == "Q4Time" ||
                     column.Id == "Q4TimeHigh" ||
                     column.Id == "Q4TimeLow")
            {
                // Display formatted time
                Type type = typeof(QAActivity);
                TimeSpan value = (TimeSpan)type.GetProperty(column.Id).GetValue(activity, null);
                string display = Util.Utilities.ToTimeString(value);

                graphics.DrawString(display,
                                    base.Font(GetCellFontStyle(element, column)),
                                    new SolidBrush(PluginMain.GetApplication().VisualTheme.ControlText),
                                    cellRect, stringFormat);
            }
            else if (activity.IsTotalsRow && column.Id == "StartTime")
            {
                // Displat "Totals"
                graphics.DrawString(CommonResources.Text.LabelTotal,
                                    base.Font(GetCellFontStyle(element, column)),
                                    new SolidBrush(PluginMain.GetApplication().VisualTheme.ControlText),
                                    cellRect, stringFormat);
            }
            else if (activity.IsTotalsRow && column.Id == "check")
            {
                // Don't draw checkbox on totals row
            }
            else
            {
                // Everything else
                base.DrawCell(graphics, rowState, element, column, cellRect);
            }
        }

        protected override FontStyle GetCellFontStyle(object element, TreeList.Column column)
        {
            QAActivity activity = element as QAActivity;

            // Bold totals row
            if (activity != null && activity.IsTotalsRow)
            {
                return FontStyle.Bold;
            }

            return base.GetCellFontStyle(element, column);
        }

        protected override RowDecoration GetRowDecoration(object element)
        {
            QAActivity activity = element as QAActivity;

            // Draw line for totals row
            if (activity != null && activity.IsTotalsRow)
            {
                return RowDecoration.TopLineSingle;
            }

            return base.GetRowDecoration(element);
        }
    }
}
