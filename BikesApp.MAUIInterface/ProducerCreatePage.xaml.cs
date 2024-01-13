using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class ProducerCreatePage : ContentPage
{
	public ProducerCreatePage(ProducerCreateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}