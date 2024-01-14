using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class BikesIndexPage : ContentPage
{
	public BikesIndexPage(BikeCollectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}