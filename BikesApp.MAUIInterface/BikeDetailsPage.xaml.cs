using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class BikeDetailsPage : ContentPage
{
	public BikeDetailsPage(BikeDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}