using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomeValidationAttribute
{
    public class TransactionModel
    {
        [Required]
        public int TransactionId { get; set; }
        [Required]
        public double Price { get; set; }
        [StringLength(50, minLength=5)]
        public string BuyerName { get; set; }
    }

    internal class RequiredAttribute : Attribute
    {

    }

    public class ValidationAttribute : Attribute
    {
        public int id { get; set; }

        public double price { get; set; }

        public string buyerName { get; set; }

        public ValidationAttribute(int id)
        {
            this.id = id;
        }

        public ValidationAttribute(double price)
        {
            this.price = price;
        }

        public ValidationAttribute(string name)
        {
            this.buyerName = name;
        }

        public ValidationAttribute(int id, double price, string name)
        {
            this.id = id;
            this.price = price;
            this.buyerName = name;
        }

        public static void Required(object obj, PropertyChangedEventArgs eventArgs)
        {
            Type type = obj.GetType();
            var changedProperty = type.GetProperty(eventArgs.PropertyName);
            var attribute = (ValidationAttribute)changedProperty
                                                 .GetCustomAttributes(typeof(ValidationAttribute), false)
                                                 .FirstOrDefault();

            var valueToCompare = type.GetProperty(attribute.price).GetValue(obj, null);
            if (!valueToCompare.Equals(changedProperty.GetValue(obj, null)))
                throw new Exception("the source and destination should not be equal");
        }

    }
}
