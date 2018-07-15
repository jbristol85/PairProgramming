using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PairProgramming
{
    abstract class Program
    {
        public class BankAccount
        {
            public int AccountNumber { get; set; }
            public string AccountOwner { get; set; }
            protected double AccountTotal { get; set; }
            public TransactionQueue BankTransaction { get; set; }
           
            public void ApplyTransaction(Transaction transaction)
            {
                AccountTotal += transaction.TransactionAmount;
            }
          
          
        }

        public class SavingsAccount : BankAccount
        {
            public double SavingsInterest { get; set; }

            public void SavingsInterestTransaction(double savingsInterest, DateTime transactionDateTime, string BankName)
            {
                transactionDateTime = DateTime.Now;
                var interestTransaction = AccountTotal * savingsInterest;
                var chargeInterest = new Transaction(interestTransaction, transactionDateTime, BankName );
               BankTransaction.Enqueue(chargeInterest);
            }

            
        }

        public class CheckingAccount : BankAccount
        {
            public double CheckingServiceFee { get; set; }

            public void CheckingServiceFeeTransaction(double TransactionAmount, DateTime TransactionDateTime, string BankName )
            {
                TransactionDateTime = DateTime.Now;
                var chargeFee = new Transaction(TransactionAmount, TransactionDateTime, BankName );

                BankTransaction.Enqueue(chargeFee);
            }

            }

        public class Transaction
        {
            public double TransactionAmount { get; set; }
            public DateTime TransactionDateTime { get; set; }
            public string BankName { get; set; }

            public Transaction(double transactionAmount, DateTime transactionDateTime,string bankName )
            {
                this.TransactionAmount = transactionAmount;
                this.TransactionDateTime = transactionDateTime;
                this.BankName = bankName;
            }


        }

        public abstract class TransactionQueue
        {
            private List<Transaction> queue;

            public void Enqueue(Transaction newTrans)
            {
                queue.Add(newTrans);
            }

            public Transaction Dequeue(string r)
            {
                var firstTransaction = queue[0];
                queue.RemoveAt(0);
                return firstTransaction;
            }


        }

        static void Main(string[] args)
        {
       
        }
    }
}
