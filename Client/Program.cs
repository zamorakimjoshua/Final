using ClassroomModel;
using ClassroomServices;


namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool active = true;
            UserGetServices userGetServices = new UserGetServices();
            UserTransactionServices userTransactionServices = new UserTransactionServices();

            while (active)
            {
                Console.WriteLine("Joshua's Classroom System");
                Console.WriteLine("What's Up Neggy?");
                Console.WriteLine("1.Student wants to use a room");
                Console.WriteLine("2.Student's done to use the room");
                Console.WriteLine("3.Occupied Rooms");

                Console.WriteLine("Pick an option:");
                string number = Console.ReadLine();

                switch (number)
                {
                    case "1":
                        Console.WriteLine("Who is the prof?");
                        string prof = Console.ReadLine();

                        Console.WriteLine("What is the Classroom?");
                        string roomNum = Console.ReadLine();

                        User newUser = new User { prof = prof, roomNum = roomNum, status = "Occupied" };
                        userTransactionServices.CreateUser(newUser);
                        Console.WriteLine("Okay, heres the key to the room!");
                        break;

                    case "2":
                        Console.WriteLine("Who is the Prof?");
                        string customerDone = Console.ReadLine();

                        User userToRemove = new User { prof = customerDone };
                        userTransactionServices.DeleteUser(userToRemove);
                        Console.WriteLine("Thankyou !");
                        break;

                    case "3":
                        Console.WriteLine("Okay, the room details is listed below<3");
                        DisplayUsers(userGetServices.GetAllUsers());
                        break;

                    case "4":
                        active = false;
                        break;

                    default:
                        Console.WriteLine("ERROR: Invalid input, please try again.");
                        break;
                }
            }
        }

        public static void DisplayUsers(List<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"name: {item.prof}, roomNum: {item.roomNum}, Status: {item.status}");
            }
        }
    }
}