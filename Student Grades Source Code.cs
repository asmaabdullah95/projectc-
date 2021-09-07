//Overview:
//1. User can enter unlimited no of students and their grades. The status of they grades which will be either passed or failed will be shown as soon as the user finishes entering the grades.
//2. The User has to define a number of students which can be 1000 or just 1. The purpose of it is to display or print the whole data when the user finishes entring the record.
 

//Below are the libraries that will help us use pre-defined functions like Console class or the WriteLine function/method and Lists (ArrayList) to temperory store students record
using System;
using System.Collections.Generic;

namespace CSMarkList
{
    //CStudent Class for Declaring Variables
    class CStudent
    {
        //Declaring Variables to store user input and display when needed
        public string name;
        public int marks;
    }
    //CStudents Class for Declaring List (ArrayList) and Adding Records
    class CStudents
    {
        //Declaring CStudent List (ArrayList)
        public List<CStudent> m_studList = new List<CStudent>();
        //Declaring a variable to hold the total number of students
        public int m_nMaxStudents;
        //Declaring AddRecord() Function to store student name and grades through parameters. (string name, int marks) are the parameters
        public int AddRecord(string name, int marks)
        {
            //Declared CStudent Object that will hold all the values of an individual student in "stud"
            CStudent stud = new CStudent();
            stud.name = name;
            stud.marks = marks;
            //Adding record of student one by one in the defined List (ArrayList)
            m_studList.Add(stud);
            //Counting total no of students in the array at the time and storing that value in MaxStudents Variable to keep a track of total no of students
            m_nMaxStudents = m_studList.Count;
            //Return means, that this add function has returned true
            return 1;
        }
    }
    
    class Program
    {
        //Object theStudents is declared to hold total no of students entered during the executing of CStudents ArrayList
        static public CStudents theStudents = new CStudents();
        //Declaring a function to print or display the total no of students when the user has finished entering the data
        static public void ViewRecords()
        {
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("Name     |      Grades      |    Staus");
            Console.WriteLine("_______________________________________________________________");
            //For loop to print each student's record in a row at the end of the program 
            for (int i = 0; i < theStudents.m_nMaxStudents; i++)
            {
                  Console.Write("{0, 0}", theStudents.m_studList[i].name);
                  Console.Write("{0, 15}", theStudents.m_studList[i].marks);
                      //Here, we will compare the value of marks to make sure if student has passed or failed to print it in the end result.
                      if (theStudents.m_studList[i].marks > 60)
                      {
                          Console.Write("{0, 25}", "Passed");
                      }
                      else
                      {
                          Console.Write("{0, 25}", "Failed");
                      }
                  Console.WriteLine();
            }
                Console.WriteLine("_______________________________________________________________");
        }
        //This is the function that will ask the user to input name and grades of the student and store it in the above arrayList.
        static public void InputRecords()
        {   
              Console.Write("Student Name: ");
              //Variables declared which are only accessiblein this particular function just like we did above which was only accessible in CStudent Class
              string name;
              int marks;
              //This will ask for input the Name of the student
              name = Console.ReadLine();
              Console.Write("Student Grades: ");
              //This will ask for input the Grade of the student and convert it into integer from string and the values will be added to AddRecord() function finally
              marks = Convert.ToInt32(Console.ReadLine());
              theStudents.AddRecord(name, marks);
              //Here, we will compare the value of marks to make sure if student has passed or failed.
              if (marks > 60)
              {
                Console.WriteLine("The Student Has Passed");
              }
              else
              {
                Console.WriteLine("The Student Has Failed");
              }
        }       
        //This Main function will run as soon as you execute the code on the start
        static void Main(string[] args)
        {
          //It will print the introduction text. Console.WriteLine prints the text and move to the next line, but Console.Write only prints the text and stays on the line.
          Console.WriteLine("Welcome to Students Result Portal");
          Console.Write("Enter the total number of students: ");
          //Declared variable to store the total no of students temperory to print it later.
          int numStudents = -1; //-1  is declared for no reason, as it is being replaced by the user input later.
          string s = Console.ReadLine(); //asks the user input of total no of students.
          numStudents = Convert.ToInt32(s); //stores the no in numstudents variable.
          for (int i = 1; i <= numStudents; i++) //For loop will run and print, ask for students data and save it. It will run equal to the number provided of total students. 
          {
                Console.WriteLine("\nEnter " + i.ToString() + " Student Information\n");
                InputRecords();
          }
          //This will show/print the whole record of the students when user puts equal no of records defined in the numstudent. i.e. if user has input 3 as total students to be added, then it will print the record as soon as user finishes entering 3 records. or it can be any number.
          ViewRecords();
          char ch = Console.ReadKey().KeyChar;
        }
    }
}