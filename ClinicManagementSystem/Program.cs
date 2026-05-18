using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //rejon 1 : system storage ( variables ) --      store banck account information

            string pName = "";
            string PCivilID = "";
            int pAge = 0;
            string pPhone = "";
            bool pActive = false; // account has not been created yet
            string pEmail = "";
            string dname = "";
            string dspec = "";
            bool dActive = false;
            bool appActive = false;
            string appStatus = "Scheduled";
            string appPatient = "";
            string appDoctor = "";
            string appDate = "";

            //rejon 2 : system processing ( menu functions )
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Add Patient Information");
                Console.WriteLine("2. View Patient Information");
                Console.WriteLine("3. Edit Patient Information");
                Console.WriteLine("4. Add doctor Information");
                Console.WriteLine("5. view doctor Information");
                Console.WriteLine("6. Book New Appointment  ");
                Console.WriteLine("7. View All Appointments ");
                Console.WriteLine("0. Exit");

                Console.WriteLine("please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        Console.WriteLine("========Add Patient Information=======");
                        if (pActive == true) // if its already their is a patient 
                        {
                            Console.WriteLine("Patient information already exists , please edit patient information if you want to change it");
                            break;
                        }
                        else                          // if their is no patient 
                        {
                            Console.WriteLine("enter Patient name:");
                            pName = Console.ReadLine();
                            Console.WriteLine("enter Patient Civil ID:");
                            PCivilID = Console.ReadLine();
                            Console.WriteLine("enter Patient Age:");
                            pAge = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter Patient phone:");
                            pPhone = (Console.ReadLine());
                            Console.WriteLine("enter Patient Email:");
                            pEmail = Console.ReadLine();

                            pActive = true;             // here to set it as full or their is a patient
                            Console.WriteLine("account information added successfully.");
                        }
                        break;

                    case 2:                                  // view Patient information
                       
                        Console.WriteLine("======== view Patient information=======");
                        if (pActive == false)  // if the Patient blank
                        {
                            Console.WriteLine("no account information found please add account information first");
                            break;
                        }


                        else if (pActive == true)                          // if their is a patient , will print the patient information
                        {
                            int Viewoption=0;

                            Console.WriteLine("choose an option to view:");
                            Console.WriteLine("1. All Patient info");
                            Console.WriteLine("2. view Patient info by Civil ID");
                            Viewoption = int.Parse(Console.ReadLine());

                            if (Viewoption == 1)           // view all Patient info
                            {

                                Console.WriteLine("Patient name:  " + pName);
                                Console.WriteLine("Patient Civil ID: " + PCivilID);
                                Console.WriteLine("Patient Age:  " + pAge);
                                Console.WriteLine("Patient phone:  " + pPhone);
                                Console.WriteLine("Patient Email:  " + pEmail);


                            }
                            else if (Viewoption ==2)
                            {

                                Console.WriteLine("Enter Civil ID:");
                                string searchID = Console.ReadLine();


                                if (searchID == PCivilID && pActive == true)
                                {
                                    Console.WriteLine("Patient name: " + pName);
                                    Console.WriteLine("Patient Civil ID: " + PCivilID);
                                    Console.WriteLine("Patient Age: " + pAge);
                                    Console.WriteLine("Patient phone: " + pPhone);
                                    Console.WriteLine("Patient Email: " + pEmail);

                                }
                                else
                                {
                                    Console.WriteLine("Patient not found");

                                }


                            }

                        }
                       
                        break;

                    case 3:                                 // edit account information
                        Console.WriteLine("========edit account information========");
                        Console.WriteLine("choose an option to edit:");
                        Console.WriteLine("1. Edit Patient email");
                        Console.WriteLine("2. Edit Patient Phone");
                        int choice = int.Parse(Console.ReadLine());

                        if (choice == 1)              // we use if bacaue we have 2 choice , if more than 3 we need to use switch 
                        {

                            Console.WriteLine("enter a new Patient email:      ");
                            pEmail = Console.ReadLine();
                            Console.WriteLine("Patient name updated successfully.");
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("enter a new Patient phone:       ");
                            pPhone = Console.ReadLine();
                            Console.WriteLine("Patient phone updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("invalid option please try again");
                        }

                        break;

                    case 4:                            // add doctor 

                        Console.WriteLine("enter Doctor name:");
                        dname = Console.ReadLine();
                        Console.WriteLine("enter Doctor specialization:");
                        dspec = Console.ReadLine();
                        dActive = true;  // here to be not empty

                        Console.WriteLine("Doctor Added Successfully.");
                        break;

                    case 5:                            // view doctor
                        if (dActive == false)
                        {
                            Console.WriteLine("no doctor information found please add doctor information first");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Doctor Name: " + dname);
                            Console.WriteLine("Doctor specialization: " + dspec);
                            
                        }
                        break;

                    case 6:                         //Book New Appointment

                        if (appActive == true)
                        {
                            Console.WriteLine("Appointment schedule is full.");
                            break;
                        }


                        Console.WriteLine("===Active Patients===");   // to list active patient

                        if (pActive)
                        {
                            Console.WriteLine("1. " + pName);
                        }
                        Console.WriteLine("Choose patient number:");
                        int pchoice = int.Parse(Console.ReadLine()); // patient number


                        if (pchoice == 1 && pActive)
                                  
                        {
                            Console.WriteLine("Valid patient selected.");
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                            break;
                        }


                        if (dActive )
                        {
                            Console.WriteLine("1. " + dname);
                        }
                        else
                        {
                            Console.WriteLine("No doctors available.");
                            break;
                        }

                        Console.WriteLine("Choose Doctor number:");
                        int dchoice = int.Parse(Console.ReadLine()); // Doctor number 

                        if (dchoice == 1 && dActive)
                        {
                            Console.WriteLine("Doctor selected successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Doctor choice.");
                        }
                        Console.WriteLine("Enter appointment date in this format (DD/MM/YYYY)):  ");
                        string appointmentDate = Console.ReadLine();

                        if (appActive == false)         // check that appoinment available
                        {
                            appPatient = pName;
                            appDoctor = dname;
                            appDate = appointmentDate;
                            appStatus = "Scheduled";
                            appActive = true;

                            Console.WriteLine("Appointment booked successfully");
                        }
                      
                        break;


                    case 7:                                  // view appoinment

                        Console.WriteLine("=== view Appointments ===");

                        if (appActive)
                        {
                            Console.WriteLine("Patient: " + pName);
                            Console.WriteLine("Doctor: " + dname);
                            Console.WriteLine("Date: " + appDate);
                            Console.WriteLine("Status: " + appStatus);
                        }

                   
                        break;

                    case 0:
                        exit = true;
                        break;


                }

                Console.WriteLine("press any key to continue...");
                Console.ReadKey();  // to press any key to clear
                Console.Clear(); // clear the console 



            }

        }
    }
}
