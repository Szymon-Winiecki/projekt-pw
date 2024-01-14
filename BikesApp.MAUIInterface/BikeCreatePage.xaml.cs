using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class BikeCreatePage : ContentPage
{
	public BikeCreatePage(BikeCreateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}