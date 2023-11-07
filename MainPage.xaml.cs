using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace maui_bug;


public partial class Data : ObservableObject
{
    [ObservableProperty]
    string _title;
    [ObservableProperty]
    DateTime _time;
}

public partial class Item : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<Data> _items = new ObservableCollection<Data>();

    public void AddItems(int n)
    {
        var t = DateTime.Now;
		for (int i = 0; i < n; ++i)
        {
            Items.Add(new Data() { Time = t, Title = "Hello" });
        }
    }
}

public partial class MainPage : ContentPage
{
	public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

    Random _random = new Random();

    public MainPage()
	{
		InitializeComponent();
        var item = new Item();
        item.AddItems(_random.Next(3, 5));
        Items.Add(item);
        BindingContext = this;
	}

	public void AddItem(object sender, EventArgs e)
	{
		var item = new Item();
		item.AddItems(_random.Next(3, 5));
		Items.Add(item);
	}

    public void RandomAddItem(object sender, EventArgs e)
    {
        var idx = _random.Next(0, Items.Count);
        Items[idx].AddItems(1);
    }
}

