using DevExpress.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace NextBO.Wpf.ViewModels
{
    public class Address
    {
        [Display(Name = "Dirección ")]
        public string Line { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Código Zip")]
        [ZipCode]
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CityLine { get; }
    }
}
