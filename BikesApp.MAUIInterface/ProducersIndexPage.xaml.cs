using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class ProducersIndexPage : ContentPage
{
	public ProducersIndexPage(ProducersCollectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}