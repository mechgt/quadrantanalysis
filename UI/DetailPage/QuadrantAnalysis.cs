using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;
using ZoneFiveSoftware.Common.Visuals.Util;

namespace QuadrantAnalysis.UI.DetailPage
{
    public class QuadrantAnalysis : IDetailPage
    {
        #region Fields

        private QuadrantAnalysisDetail control;
        private bool maximized;
        private IDailyActivityView view;

        #endregion

        #region Constructor

        internal QuadrantAnalysis(IDailyActivityView view)
        {
            this.view = view;
        }

        #endregion

        #region Properties

        private QuadrantAnalysisDetail Control
        {
            get
            {
                if (control == null)
                {
                    control = CreatePageControl() as QuadrantAnalysisDetail;
                }

                return control;
            }
        }

        #endregion

        #region IDialogPage Members

        public Control CreatePageControl()
        {
            if (control == null)
            {
                control = new QuadrantAnalysisDetail();
                //control.Activity = null;
            }

            return control;
        }

        public bool HidePage()
        {
            if (control != null)
            {
                view.SelectionProvider.SelectedItemsChanged -= SelectionProvider_SelectedItemsChanged;
                control.Maximize -= control_Maximize;
            }
            return true;
        }

        public string PageName
        {
            get { return Resources.Strings.Label_QuadrantAnalysis; }
        }

        public void ShowPage(string bookmark)
        {
            if (control != null)
            {
                view.SelectionProvider.SelectedItemsChanged += new EventHandler(SelectionProvider_SelectedItemsChanged);
                control.Maximize += new EventHandler(control_Maximize);
                SelectionProvider_SelectedItemsChanged(null, null);
            }
        }

        void control_Maximize(object sender, EventArgs e)
        {
            PageMaximized = !PageMaximized;
        }

        public IPageStatus Status
        {
            get { return null; }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            Control.ThemeChanged(visualTheme);
        }

        public string Title
        {
            get { return Resources.Strings.Label_QuadrantAnalysis; }
        }

        public void UICultureChanged(CultureInfo culture)
        {
            Control.UICultureChanged(culture);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region IDetailPage Members

        public Guid Id
        {
            get { return GUIDs.DetailPage; }
        }

        public bool MenuEnabled
        {
            get { return true; }
        }

        public IList<string> MenuPath
        {
            get
            {
                IList<string> list = new List<string>();
                list.Add(CommonResources.Text.LabelPower);
                return list;
            }
        }

        public bool MenuVisible
        {
            get
            {
                return true;
            }
        }

        public bool PageMaximized
        {
            get
            {
                return maximized;
            }
            set
            {
                maximized = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PageMaximized"));
                    control.MaximizePage(maximized);
                }
            }
        }

        #endregion

        void SelectionProvider_SelectedItemsChanged(object sender, EventArgs e)
        {
            if (control != null)
            {

                IEnumerable<IActivity> activities = CollectionUtils.GetAllContainedItemsOfType<IActivity>(view.SelectionProvider.SelectedItems);
                Control.Activities = activities;

                //    IActivity activity = CollectionUtils.GetSingleItemOfType<IActivity>(view.SelectionProvider.SelectedItems);
                //    Control.Activities = activity;
            }
        }
    }
}
