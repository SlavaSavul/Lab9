using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp1
{
    delegate int Operation(int x, int y);


    class Program
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;


            Mylist Mylist1 = new Mylist();
            Mylist1.Add= "Hello, world!!!";
            Mylist1.Add = "String 2";
            Mylist1.Add = "String 2.1";

            Mylist Mylist2 = new Mylist();
            Mylist2.Add = "String 3";
            Mylist2.Add = "String 0";


           

            Programer Event1 = new Programer();

            Event1.EventDelete += Mylist1.OnDel;
            Event1.EventDelete += Mylist2.OnDel;

            Event1.EventMutate += Mylist1.OnMut;
            Event1.EventMutate += Mylist2.OnMut;
            Event1.EventDelete += (n, s) =>
            {
                Console.WriteLine("Лямбда-выражение");                
                Console.WriteLine(s.str);
                Console.WriteLine();
            };

            Event1.Mutate();
            Event1.Delete();
            Event1.Delete();
            Console.WriteLine();
            Console.WriteLine();



            MyString str=new MyString("Hello, world!!!");          
            Action Action1;     

            Action1 = str.DeleteExclamationPoint;
            Action1 += str.DeleteСomma;
            Action1 += str.Uppercase;
            Action1 +=  ()=>
             {
                 Console.WriteLine();
                 Console.WriteLine(str.OutSTR);
             };
            Action1();



            Console.ReadKey();
        }
    }

    delegate void MyEventHandler(object sender, MyEventArgs e);


    class MyEventArgs : EventArgs
    {
        public string str;
    }

    class Mylist
    {
        public List<string> List1 = new List<string>(10);
        public string Add
        {
            set { List1.Add(value); }
        }

        public void OnDel(object sender, MyEventArgs e)
        {
            
            if(List1.Count>0)
                List1.RemoveAt(List1.Count-1);
            Console.WriteLine(e.str);

            foreach (string i in List1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
        public void OnMut(object sender, MyEventArgs e)
        {
            List1.Sort();
            Console.WriteLine(e.str);
            foreach (string i in List1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }
    
     class MyString
    {
        string a;
      public MyString(string str)
        {
            a = str;
        }

        public  string OutSTR
        {    
            get {return a; } 
        }

        public  void DeleteExclamationPoint( )
        {


            a = a.Trim('!');
            Console.WriteLine(a);
            
        }

      public void Uppercase( )
        {

            a = a.ToUpper();

            Console.WriteLine(a);
            
        }

        public void DeleteСomma( )
        {

            a = a.Trim();
            Console.WriteLine(a);
           
        }



    }

    class Programer
    {
        public event MyEventHandler EventDelete;
        public event MyEventHandler EventMutate;

        MyEventArgs MyEventArgs1=new MyEventArgs();

        public void Delete()
        {
            MyEventArgs1.str = "Delete";
            if (EventDelete != null)
                EventDelete(this, MyEventArgs1);          
        }


        public void Mutate()
        {
            MyEventArgs1.str = "Mutate";
            if (EventMutate != null)
                EventMutate(this, MyEventArgs1);
        }

    }




}

