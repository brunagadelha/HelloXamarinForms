using System;
using System.Collections.Generic;
using System.Text;

namespace HelloXamarin.Models
{
    public class ProductItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; } = 0;
        public string FormattedValue
        {
            get
            {
                return string.Format("{0:C}", Value);
            }
        }
        public decimal Total { get { return Value * Quantity; } }
        public string FormattedTotal
        {
            get
            {
                return string.Format("{0:C}", Total);
            }
        }

        //public override string ToString()
        //{
        //    return $"{this.Quantity} {this.Name.ToString()} - {this.Value.ToString()}";
        //}
    }
}
