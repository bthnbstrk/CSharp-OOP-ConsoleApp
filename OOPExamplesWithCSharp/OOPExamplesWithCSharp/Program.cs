using System;

namespace OOPExamplesWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager(new Customer(),new TeacherCreditManager());
            customerManager.GiveCredit();

            Console.ReadLine();



       

        }
    }

    class CreditManager
    {
        public void Calculate()
        {
            Console.WriteLine("Hesaplandi");
        }

        public void Save()
        {
            Console.WriteLine("Müşteriye kredi verildi.");
        }
    }

    interface ICreditManager
    {
        void Save();
        void Calculate();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();
      

        public virtual void Save()//Bir yerde farklı bir işlem yapabilmek icin. virtual kullandık javada default virtual dır.
        {
            Console.WriteLine("Bu bir abstract methoddur.Birden fazla kez tekrar edileceği için abstract kullanıldı.");
        }

        
    }
    //Abstarct ve interface ler new lenemez.

    class TeacherCreditManager :BaseCreditManager,ICreditManager
    {
        public override void Calculate()//Override yazmamızın sebebi abstract class ında methodun imzasının oluşundundandır.
        {
            Console.WriteLine("Öğretmen için kredi uygulandı");
        }

        public override void Save()
        {
            Console.WriteLine("Bu bir virtuallanmış sınıf kodudur.");
            base.Save();
        }

    }


    class DoctorCreditManager :BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Doktor için kredi uygulandı");
        }

     
    }

    class Customer
    {
        //A class have to make only one work.Not more than one.

        public Customer(){
            Console.WriteLine("Müşteri eklendi.");
            }
        public int Id { get; set; }

        public string City { get; set; }

    }
    class Company : Customer //In java extends
    {
        public string TaxNumber { get; set; }
        public string CompanyName { get; set; }
    }

    class Person : Customer
    {
        public string NationalIdentity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    class CustomerManager
    {//Interface is a referance type.
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer,ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {
            Console.WriteLine("Müşteri kaydedildi :");
        }

        public void Delete()
        {
            Console.WriteLine("Müşteri silindi");
        }

        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi Verildi");
        }

    }
}
