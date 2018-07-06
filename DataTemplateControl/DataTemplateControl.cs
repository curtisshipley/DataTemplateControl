using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace SaltyDog
{
	public class DataTemplateControl : Frame
	{
		public static readonly BindableProperty TemplateDictionaryProperty =
			BindableProperty.Create("TemplateDictionary", typeof(ResourceDictionary), typeof(DataTemplateControl), null,
				propertyChanged: (b, o, n) => (b as DataTemplateControl).ItemTemplateProperty_Changed(b, o, n));

		public ResourceDictionary TemplateDictionary
		{
			get
			{
				return (ResourceDictionary)GetValue(TemplateDictionaryProperty);
			}
			set
			{
				SetValue(TemplateDictionaryProperty, value);
			}
		}

		public static readonly BindableProperty SelectorProperty =
			BindableProperty.Create("ItemsSource", typeof(String), typeof(DataTemplateControl), null,
				propertyChanged: (b, o, n) => (b as DataTemplateControl).SelectorProperty_Changed(b, o, n));

		public String Selector
		{
			get
			{
				return (String)GetValue(SelectorProperty);
			}
			set
			{
				SetValue(SelectorProperty, value);
			}
		}

		protected void SelectorProperty_Changed(BindableObject bindable, object oldValue, object newValue)
		{
			Render();
		}

		protected void ItemTemplateProperty_Changed(BindableObject bindable, object oldValue, object newValue)
		{
			Render();
		}

		protected DataTemplate SelectTemplate(String selector)
		{
			// We might be skipping because it is not a templatable
			// item
			if (selector == null)
				return null;

			if (TemplateDictionary == null)
				throw new Exception("Templates not set");

			Object entry;

			if (!TemplateDictionary.TryGetValue(selector, out entry))
				throw new Exception($"ResourceDictionary key {selector.ToString()} not found");

			if (!(entry is DataTemplate))
				throw new Exception($"ResourceDictionary item {selector.ToString()} is not a DataTemplate");

			return entry as DataTemplate;
		}


		public void Render()
		{
			if (Selector == null || TemplateDictionary == null)
				return;

			DataTemplate template = SelectTemplate(Selector);
			var o = template.CreateContent();

			if (o != null)
			{
				var view = o as View;
				view.BindingContext = BindingContext;
				Content = view;
			}
		}
		
	}
}
