Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.DataSourceWizard
Imports DevExpress.DashboardWin
Imports DevExpress.DashboardWin.DataSourceWizard
Imports DevExpress.DashboardWin.Native
Imports DevExpress.DataAccess.UI.Wizard

Namespace DataSourceWizardCustomization
    Partial Public Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
            dashboardDesigner1.CreateRibbon()
            dashboardDesigner1.DataSourceWizardCustomizationService = New DataSourceWizardCustomizationService()
            dashboardDesigner1.ShowDataSourceWizard()
        End Sub
    End Class

    Public Class DataSourceWizardCustomizationService
        Implements IDataSourceWizardCustomizationService

        Public Sub CustomizeDataSourceWizard(ByVal customization As IWizardCustomization(Of DashboardDataSourceModel)) _
            Implements IDataSourceWizardCustomizationService.CustomizeDataSourceWizard
            customization.RegisterPageView(Of IConfigureOlapParametersPageView, CustomConfigureOlapParametersPageView)()
        End Sub
    End Class

    Friend Class CustomConfigureOlapParametersPageView
        Inherits ConfigureOlapParametersPageView

        Protected Overrides Function CreateOlapConnectionParametersControl() As OlapConnectionParametersControl
            Return New CustomOlapConnectionParametersControl()
        End Function
    End Class

    Friend Class CustomOlapConnectionParametersControl
        Inherits OlapConnectionParametersControl

        Public Sub New()
            MyBase.New()
            lciConnectionType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Sub
    End Class
End Namespace