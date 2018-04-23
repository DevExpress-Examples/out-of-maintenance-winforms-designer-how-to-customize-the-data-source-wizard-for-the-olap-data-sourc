using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.DataSourceWizard;
using DevExpress.DashboardWin;
using DevExpress.DashboardWin.DataSourceWizard;
using DevExpress.DashboardWin.Native;
using DevExpress.DataAccess.UI.Wizard;

namespace DataSourceWizardCustomization {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
            dashboardDesigner1.CreateRibbon();
            dashboardDesigner1.DataSourceWizardCustomizationService = new DataSourceWizardCustomizationService();
            dashboardDesigner1.ShowDataSourceWizard();
        }
    }

    public class DataSourceWizardCustomizationService : IDataSourceWizardCustomizationService {
        public void CustomizeDataSourceWizard(IWizardCustomization<DashboardDataSourceModel> customization) {
            customization.RegisterPageView<IConfigureOlapParametersPageView, CustomConfigureOlapParametersPageView>();
        }
    }

    class CustomConfigureOlapParametersPageView : ConfigureOlapParametersPageView {
        protected override OlapConnectionParametersControl CreateOlapConnectionParametersControl() {
            return new CustomOlapConnectionParametersControl();
        }
    }

    class CustomOlapConnectionParametersControl : OlapConnectionParametersControl {
        public CustomOlapConnectionParametersControl() : base() {
            lciConnectionType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
    }
}