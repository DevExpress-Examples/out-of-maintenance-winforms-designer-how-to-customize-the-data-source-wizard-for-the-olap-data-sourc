using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.DataSourceWizard;
using DevExpress.DashboardWin.DataSourceWizard;
using DevExpress.DashboardWin.ServiceModel;
using DevExpress.DataAccess.UI.Wizard;
using DevExpress.XtraLayout;

namespace DataSourceWizardCustomization
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            dashboardDesigner1.CreateRibbon();
            dashboardDesigner1.DataSourceWizardCustomization = new DataSourceWizardCustomization();
            dashboardDesigner1.ShowDataSourceWizard();
        }
    }

    public class DataSourceWizardCustomization : IDashboardDataSourceWizardCustomization
    {
        public void CustomizeDataSourceWizard(IWizardCustomization<DashboardDataSourceModel> customization)
        {
            customization.RegisterPageView<IConfigureOlapParametersPageView, CustomConfigureOlapParametersPageView>();
        }
    }

    class CustomConfigureOlapParametersPageView : ConfigureOlapParametersPageView
    {
        public CustomConfigureOlapParametersPageView() : base()
        {
            LayoutControl layoutControl = this.ConnectionParametersControl.Controls["layoutControl1"] as LayoutControl;

            var сonnectionTypeOption = layoutControl.Items.FindByName("lciServerbased");
            сonnectionTypeOption.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
    }
}
