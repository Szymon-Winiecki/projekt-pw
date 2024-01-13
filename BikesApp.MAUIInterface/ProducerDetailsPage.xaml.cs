using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class ProducerDetailsPage : ContentPage
{
	public ProducerDetailsPage(ProducerDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}