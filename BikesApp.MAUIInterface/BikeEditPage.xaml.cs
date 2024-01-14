using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class BikeEditPage : ContentPage
{
	public BikeEditPage(BikeEditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}