namespace Simulantara.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
		MyWebView.Source = "Dashboard.html";
	}
}