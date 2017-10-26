using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Reflection;

namespace CustomPicker
{
    public class ComboPicker : Picker
    {
        public ComboPicker()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        public static readonly BindableProperty TextValueProperty =
           BindableProperty.Create<ComboPicker, string>(p => p.TextValue, "");
        private Type Tipo;
        public string TextValue
        {
            get { return GetValue(TextValueProperty).ToString(); }
            set { SetValue(TextValueProperty, value); }
        }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<ComboPicker, IEnumerable>(o => o.ItemsSource,
                default(IEnumerable), propertyChanged: OnItemsSourceChanged);

        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create<ComboPicker, object>(o => o.SelectedItem,
                default(object));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); Tipo = value.GetType(); }
        }
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        private static void OnItemsSourceChanged(BindableObject bindable,
            IEnumerable oldvalue, IEnumerable newvalue)
        {
            var picker = bindable as ComboPicker;
            picker.Items.Clear();
            if (newvalue != null)
            {
                foreach (var item in newvalue)
                {
                    if (!string.IsNullOrEmpty(picker.TextValue))
                        picker.Items.Add(item.GetType().GetRuntimeProperty(picker.TextValue).GetValue(item, null).ToString());
                    else
                        picker.Items.Add(item.ToString());
                }
            }
        }
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
                SelectedItem = null;
            else
            {
                var i = 0;
                foreach (var item in ItemsSource)
                {
                    if (i == SelectedIndex)
                    {
                        SelectedItem = item;
                        break;
                    }
                    else
                        i++;
                }
            }
        }
    }
}
