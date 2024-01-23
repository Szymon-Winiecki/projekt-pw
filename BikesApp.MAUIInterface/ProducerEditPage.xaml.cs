using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface;

public partial class ProducerEditPage : ContentPage
{
	public ProducerEditPage(ProducerEditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}