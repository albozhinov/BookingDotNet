using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace HotelManagement.Models
{
    public abstract class AccomodationProperty : IAccomodationProperty
    {
        private int capacity;
        private int beds;
        private readonly bool forSmokers;
        //private readonly ViewType view;
        private readonly List<IExtra> listOfExtras;
        private readonly List<DateTime> notAvailable;
        private decimal basePrice;

        public AccomodationProperty(int capacity, int beds, bool forSmokers, string view, decimal basePrice)
        {
            this.Capacity = capacity;
            this.Beds = beds;
            this.forSmokers = forSmokers;
            view = view.First().ToString().ToUpper() + view.Substring(1);
            //Investigate why this option does not work

            //if (Enum.TryParse(view, out ViewType result))
            //{
            //    this.view = result;
            //}
            //else
            //{
            //    throw new ArgumentException("View not valid.");
            //}
            try
            {
                this.View = Enum.Parse<ViewType>(view, true);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("View not valid.");
            }
            this.BasePrice = basePrice;
            this.listOfExtras = new List<IExtra>();
            this.notAvailable = new List<DateTime>();
        }

        public virtual int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                Validation.NumberBorderCheck(1, 10, value, Constants.commonCapacity);
                this.capacity = value;
            }
        }
        public virtual int Beds
        {
            get
            {
                return this.beds;
            }
            set
            {
                Validation.NumberBorderCheck(1, 10, value, Constants.commonBeds);
                this.beds = value;
            }
        }

        public bool ForSmokers
        {
            get
            {
                return this.forSmokers;
            }
        }

        public ViewType View { get; set; }

        public List<IExtra> ListOfExtras
        {
            get
            {
                return new List<IExtra>(this.listOfExtras);
            }
        }

        public virtual decimal BasePrice
        {
            get
            {
                return this.basePrice;
            }
            set
            {
                Validation.NumberBorderCheck(50, 400, value, Constants.commonBasePrice);
                this.basePrice = value;
            }
        }

        public List<DateTime> NotAvailable
        {
            get
            {
                return new List<DateTime>(this.notAvailable);
            }
        }

        public virtual void AddExtra(IExtra extra)
        {
            this.listOfExtras.Add(extra);
        }

        public virtual decimal CalculatePrice()
        {
            return this.BasePrice;
        }

        public void SaveRoom(DateTime date)
        {
            if(date < DateTime.Now.Date)
            {
                throw new ArgumentException("You cannot save rooms for past dates");
            }
            this.notAvailable.Add(date.Date);
            this.notAvailable.Sort();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== Information for property of type: {this.GetType().Name}");
            sb.AppendLine($"===== Capacity: {this.Capacity}");
            sb.AppendLine($"===== Number of beds: {this.Beds}");
            sb.AppendLine($"===== For Smokers: {((this.ForSmokers) ? "Yes":"No" )}");
            sb.AppendLine($"===== View: {this.View.ToString()}");
            sb.AppendLine($"===== Price: {this.BasePrice}");
            sb.AppendLine($"===== Extras: {String.Join(',',this.ListOfExtras.Select(x=>x.Name.ToString()).ToList())}");
            sb.AppendLine($"===== Not available for the following dates: {String.Join("| ", this.NotAvailable.Select(x => x.ToString("dd/MM/yyyy")))}");
            return sb.ToString();

        }
    }
}
