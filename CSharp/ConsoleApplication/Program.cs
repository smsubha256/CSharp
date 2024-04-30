// See https://aka.ms/new-console-template for more information
using System;
using System.Net.WebSockets;
using System.Reflection.Metadata;

namespace ListWorkouts;

public class PersonInfo
{
    private  string userID;
    public required string UserID
    {
        get
        {
            return convertAllUppercase(this.userID ?? "user id was empty");
        }
        set => this.userID = value;
    }
    private string firstName;
    public string FirstName
    {
        get => this.firstName;
        set => this.firstName = value;
    }
    private string lastName;
    public string LastName
    {
        get => this.lastName;
        set => this.lastName = value;
    }
    private string email;
    public string Email
    {
        get => this.email;
        set => this.email = value;
    }

    private string convertAllUppercase(string value)
    {
        if (value == null) return value;
        return value.ToUpper();
    }
}
interface IUserList
{
    List<PersonInfo> GetAllUsers();
    PersonInfo GetUserByID();
}
class DisplayUser : IUserList
{
    List<PersonInfo> users = new List<PersonInfo>();
  
    public List<PersonInfo> GetAllUsers()
    {
       users = new List<PersonInfo>();
        if (users != null && users.Count > 0)
        {
            return users;
        }
        
            
        users = new List<PersonInfo> {
        new PersonInfo{UserID="abc", Email="abc@gmail.com", FirstName="A"},
        new PersonInfo{UserID="def", Email="def@gmail.com", LastName="EF"},
        new PersonInfo{UserID="ghi", Email="ghi@gmail.com", FirstName="G", LastName="HI"},
        new PersonInfo{UserID="jkl", Email="jkl@gmail.com", FirstName="J", LastName="KL"},
        new PersonInfo{UserID="mno", Email="mno@gmail.com", FirstName="M", LastName="NO"}
        };
        return users;
    }

    public PersonInfo GetUserByID()
    { 
        Console.WriteLine("Enter the User ID");
        string id = Console.ReadLine();
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("please enter valid iuser id");
                this.GetUserByID();
        }
        PersonInfo userdetails = users.FirstOrDefault(user => user.UserID.ToLowerInvariant() == id.ToLowerInvariant());
        List<PersonInfo> userdetails1 = users.Where(user => user.UserID.ToLowerInvariant() == id.ToLowerInvariant()).ToList();
        userdetails = userdetails1.FirstOrDefault();
        return userdetails;  
    }
        
}
class Program
{
    static void Main(string[] args)
    {
        IUserList userList = new DisplayUser();

        List<PersonInfo> users = userList.GetAllUsers();
        foreach (PersonInfo user in users)
        {
            Console.WriteLine (user.Email, user.FirstName, user.LastName, user.UserID);
        }
        PersonInfo userInfo = userList.GetUserByID();

        var ttt = "id " + userInfo.UserID + " | " + userInfo.Email;
        ttt = $"id  user id is { userInfo.UserID }  emssil is: {userInfo.Email}";
       
        Console.WriteLine("The User details are: " + ttt);
        
        Console.WriteLine("The User details are: {0} {1}", userInfo.UserID, userInfo.FirstName);

    }
}




