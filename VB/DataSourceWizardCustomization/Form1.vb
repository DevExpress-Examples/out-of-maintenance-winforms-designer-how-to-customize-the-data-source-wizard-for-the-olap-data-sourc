Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.DataSourceWizard
Imports DevExpress.DashboardWin.DataSourceWizard
Imports DevExpress.DashboardWin.ServiceModel
Imports DevExpress.DataAccess.UI.Wizard
Imports DevExpress.XtraLayout

Namespace DataSourceWizardCustomization
    Partial Public Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
            dashboardDesigner1.CreateRibbon()
            dashboardDesigner1.DataSourceWizardCustomization = New DataSourceWizardCustomization()
            dashboardDesigner1.ShowDataSourceWizard()
        End Sub
    End Class

    Public Class DataSourceWizardCustomization
        Implements IDashboardDataSourceWizardCustomization

        Public Sub CustomizeDataSourceWizard(ByVal customization As IWizardCustomization(Of DashboardDataSourceModel)) _
            Implements IDashboardDataSourceWizardCustomization.CustomizeDataSourceWizard
            customization.RegisterPageView(Of IConfigureOlapParametersPageView, CustomConfigureOlapParametersPageView)()
        End Sub
    End Class

    Friend Class CustomConfigureOlapParametersPageView
        Inherits ConfigureOlapParametersPageView

        Public Sub New()
            MyBase.New()
            Dim layoutControl As LayoutControl = TryCast(Me.ConnectionParametersControl.Controls("layoutControl1"),
                LayoutControl)

            Dim сonnectionTypeOption = layoutControl.Items.FindByName("lciServerbased")
            сonnectionTypeOption.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Sub
    End Class
End Namespace
