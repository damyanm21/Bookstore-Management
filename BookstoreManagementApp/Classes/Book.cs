using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes
{
    public class Book
    {
        public int ID { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException(Const.TitleError);

                _title = value;
            }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException(Const.AuthorError);

                _author = value;
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(Const.PriceError);

                _price = value;
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(Const.QuantityError);

                _quantity = value;
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value != null && value.Length > 200)
                    throw new ArgumentException(Const.DescriptionError);

                _description = value;
            }
        }
    }
}
