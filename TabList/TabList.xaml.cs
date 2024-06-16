using System.Collections;
using System.Windows.Input;

namespace RightClick.TabListItem;

public partial class TabList : ContentView
{
    public TabList()
    {
        InitializeComponent();
    }

    public static BindableProperty ItemSourceProperty = BindableProperty.Create(nameof(ItemSource), typeof(IEnumerable), typeof(TabList), propertyChanged: ItemSourceChanged);
    private static void ItemSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((TabList)bindable).MainCollection.ItemsSource = (IList<string>)newValue;
    }

    public IEnumerable ItemSource { get => (IEnumerable)GetValue(ItemSourceProperty); set => SetValue(ItemSourceProperty, value); }

    public static BindableProperty RightClickProperty = BindableProperty.Create(nameof(RightClick), typeof(ICommand), typeof(TabList));

    public ICommand RightClick { get => (ICommand)GetValue(RightClickProperty); set => SetValue(RightClickProperty, value); }

    private void Left_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void Right_Tapped(object sender, TappedEventArgs e)
    {
        RightClick?.Execute(null);
    }
}