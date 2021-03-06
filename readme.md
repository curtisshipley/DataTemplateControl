
***I'm keeping this proof of concept, but active development has moved to:*** [https://github.com/curtisshipley/SaltyDogControls](https://github.com/curtisshipley/SaltyDogControls)


***DataTemplateControl*** is a sample Xamarin Forms control that renders different DataTemplates based on a selection value.

![Screen](https://raw.githubusercontent.com/curtisshipley/DataTemplateControl/master/DataTemplateControl.gif "Screen Capture")


If you have any questions, or would like specific cusomizations post an issue, or contact the author at curtis@saltydogtechnology.com.

Notes:

* The templates can be dynamically updated by changing the Selector. 
* Rendered Data Templates are data bound as well.

Example Xaml:

<code>
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
			 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			 xmlns:local="clr-namespace:DataTemplateSample"
			 xmlns:sd="clr-namespace:SaltyDog;assembly=DataTemplateControl"
			 x:Name="me"
			 x:Class="DataTemplateSample.MainPage">

	<ContentPage.Resources>
		<ResourceDictionary x:Name="resDict">
			
			<x:Array x:Key="TemplateList" Type="{x:Type x:String}">
				<x:String>Template 1</x:String>
				<x:String>Template 2</x:String>
				<x:String>Template 3</x:String>
			</x:Array>
			
			<DataTemplate x:Key="Template 1">
				<StackLayout>
					<Label Text="This is Template 1" TextColor="Black" FontSize="Medium"/>
					<Button Text="Button from Template 1" />
				</StackLayout>
			</DataTemplate>
			
			<DataTemplate x:Key="Template 2">
				<StackLayout>
					<Label Text="This is Template 2" TextColor="Black" FontSize="Medium"/>
					<BoxView VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand" BackgroundColor="Blue" />
				</StackLayout>
			</DataTemplate>
			
			<DataTemplate x:Key="Template 3">
				<StackLayout Orientation="Vertical">
					<Label Text="Data Bindings work too:"  TextColor="Black" FontSize="Medium"/>
					<Label Text="{Binding AValue}"  TextColor="Blue" FontSize="Large"/>
				</StackLayout>
			</DataTemplate>
			
		</ResourceDictionary>
	</ContentPage.Resources>

	<StackLayout Spacing="0" Padding="16">

		<Label 
            Text="Data Template Control" 
            HorizontalOptions="Center" 
            TextColor="Blue" 
            FontSize="Large" 
            Margin="0,0,0,16" />

		<Label Text="Choose the template:" TextColor="Black" FontSize="Medium" />
		
		<Picker x:Name="ThePicker" 
            ItemsSource="{StaticResource TemplateList}" 
            SelectedIndex="0" 
            Margin="0,0,0,32" 
            BackgroundColor="LightGray" />
		
		<sd:DataTemplateControl Padding="0"
			VerticalOptions="FillAndExpand" 
			HorizontalOptions="FillAndExpand" 
			Selector="{Binding Source={x:Reference ThePicker}, Path=SelectedItem}"
			TemplateDictionary="{Binding Source={x:Reference resDict}}" 
			/>

	</StackLayout>

</ContentPage>

</code>

