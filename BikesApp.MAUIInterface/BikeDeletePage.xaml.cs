using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class BikeDeletePage : ContentPage
{
	public BikeDeletePage(BikeDeleteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}