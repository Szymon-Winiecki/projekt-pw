using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class ProducerDeletePage : ContentPage
{
	public ProducerDeletePage(ProducerDeleteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}