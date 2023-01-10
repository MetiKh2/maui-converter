using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsNet;

namespace Converter.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        public string Option { get; set; }
        public ObservableCollection<string> FromMeasure { get; set; }
        public ObservableCollection<string> ToMeasure { get; set; }

        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }

        public double FromValue { get; set; } = 1;
        public double ToValue { get; set; }

        public ICommand TextChangedCommand => new Command(() =>
        {
            Convert();
        });
        public void Convert()
        {
            ToValue = UnitConverter.ConvertByName(FromValue,Option,CurrentFromMeasure,CurrentToMeasure);
        }
        public ConverterViewModel(string option)
        {
            Option = option;
            FromMeasure = LoadMeasure();
            ToMeasure = LoadMeasure();
            CurrentFromMeasure = FromMeasure.FirstOrDefault();
            CurrentToMeasure=ToMeasure.Skip(1).FirstOrDefault();
            Convert();
        }
        private ObservableCollection<string> LoadMeasure()
        {
            var units = Quantity.Infos.FirstOrDefault(p=>p.Name==Option).UnitInfos.Select(p=>p.Name).ToList();
            return new ObservableCollection<string>(units);
        }
    }
}
