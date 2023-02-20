
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp;

public class Client
{
    public static int ClientID { get; set; }
    public static string FirstName { get; set; }
    public static string Surname { get; set; }
    public static string Patronimyc { get; set; }
    public static string MobileNums { get; set; }
    public static string PassportNums { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public Client(int clientId, string firstName, string surname, string patronimyc, string mobileNums, string passportNums)
    {
        ClientID = clientId;
        FirstName = firstName;
        Surname = surname;
        Patronimyc = patronimyc;
        MobileNums = mobileNums;
        PassportNums = passportNums;
    }

}