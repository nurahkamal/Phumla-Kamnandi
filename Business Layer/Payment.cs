using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    internal class Payment
    {
        #region Data Members
        private int _paymentID; // Private fields storing payment data
        private int _accountID;
        private int _reservationID;
        private DateTime _paymentDate;
        private string _paymentType;
        private decimal _amountPaid;
        private decimal _totalAmount;
        private decimal _deposit;
        private decimal _balance;
        private string _status;
        #endregion

        #region Property Methods
        public int PaymentID        // Accessor and Mutator methods 
        {
            get { return _paymentID; } // returns the current payment ID
            set { _paymentID = value; } // sets a new payment ID
        }
        public int AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }
        public int ReservationID
        {
            get { return _reservationID; }
            set { _reservationID = value; }
        }
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }
        public string PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }
        public decimal AmountPaid
        {
            get { return _amountPaid; }
            set { _amountPaid = value; }
        }
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }
        public decimal Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        #endregion

        #region Constructors
        public Payment()
        {
            _paymentID = 0;
            _accountID = 0;
            _reservationID = 0;
            _paymentDate = DateTime.Today;
            _paymentType = "";
            _amountPaid = 0.0m;
            _totalAmount = 0.0m;
            _deposit = 0.0m;
            _status = "Open";
            _balance = 0;
        }
        public Payment(int paymentID, int accountID, int reservationID, DateTime paymentDate, string paymentType, decimal amountPaid, decimal totalAmount, decimal deposit, string status, decimal balance)
        {
            _paymentID = paymentID; // Parameterized constructor allows setting all fields when creating a payment
            _accountID = accountID;
            _reservationID = reservationID;
            _paymentDate = paymentDate;
            _paymentType = paymentType;
            _amountPaid = amountPaid;
            _totalAmount = totalAmount;
            _deposit = deposit;
            _status = status;
            _balance = balance;
        }
        #endregion

    }
}

