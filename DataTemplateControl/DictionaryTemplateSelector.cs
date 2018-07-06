using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SaltyDog
{
	public class TemplateItem
	{
		public String Key { get; set; }
		public DataTemplate Template { get; set; }
	}


	public class DictionaryTemplateSelector : DataTemplateSelector
	{
		private ResourceDictionary _templates;
		public ResourceDictionary Templates
		{
			get
			{
				return _templates;
			}
			set
			{
				_templates = value;
			}
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			if (Templates == null)
				throw new Exception("Templates not set");

			Object entry;

			if (!Templates.TryGetValue(item.ToString(), out entry))
				throw new Exception($"ResourceDictionary key {item.ToString()} not found");

			if (!(entry is DataTemplate))
				throw new Exception($"ResourceDictionary item {item.ToString()} is not a DataTemplate");

			return entry as DataTemplate;
		}

	}
}
