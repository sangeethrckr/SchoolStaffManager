using System;
using System.Collections.Generic;

namespace SchoolStaffManagerApp
{
    class Program
    {

        static void Main(string[] args)
        {
                    
            
            bool ifContinue ;
            
            do
            {
                Console.WriteLine("\nChoose Staff Type\n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n");   //Staff Menu
                int actionChoice = Convert.ToInt32(Console.ReadLine());
                switch (actionChoice)
                {
                    case 1:
                        TeachingStaff teachingStaff = new TeachingStaff();
                        Action(teachingStaff);
                        break;
                    case 2:
                        AdminstrativeStaff adminstrativeStaff = new AdminstrativeStaff();
                        Action(adminstrativeStaff);
                        break;
                    case 3:
                        SupportStaff supportStaff = new SupportStaff();
                        Action(supportStaff);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nDo you want to continue?(Enter y for yes)\n");
                ifContinue = Convert.ToChar(Console.ReadLine()).Equals('y') ? true : false;
            } while (ifContinue);


            void Action(Staff staff)
            {
                
                do
                {
                    Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.Update Staff Details\n"); //Action Menu
                    int actionChoice = Convert.ToInt32(Console.ReadLine());
                    switch (actionChoice)
                    {
                        case 1:
                            staff.AddStaff();
                            break;
                        case 2:
                            staff.ViewDetails();
                            break;
                        case 3:
                            staff.Update();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("\nDo you want to perform more actions on this staff?(Enter y for yes)\n");
                    ifContinue = Convert.ToChar(Console.ReadLine()).Equals('y') ? true : false;

                } while (ifContinue);
            }
        }
    }
}