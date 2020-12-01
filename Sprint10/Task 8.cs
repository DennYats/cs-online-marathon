using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint10.Task8
{
    public class Invoice
    {
        public double GetDiscount(double amount) =>
            amount;
    }

    public class FinalInvoice : Invoice
    {
        public double GetDiscount(double amount) =>
            amount - amount * 0.03;
    }

    public class ProposedInvoice : Invoice
    {
        public double GetDiscount(double amount) =>
            amount - amount * 0.05;
    }

    public class RecurringInvoice : Invoice
    {
        public double GetDiscount(double amount) =>
            amount - amount * 0.1;
    }

    public class OrdinaryInvoice : Invoice
    {
        public double GetDiscount(double amount) =>
            amount - amount * 0.01;
    }
}
