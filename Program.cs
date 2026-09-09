using AIAssistantSystem.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
       
        SQLAssistant sqlAssistant = new SQLAssistant(); // object initialisation

        Console.WriteLine("==========================================================================================");
        Console.WriteLine("AI SQL ASSISTANT");
        Console.WriteLine("==========================================================================================");
        while (true)
        {
            Console.WriteLine("==========================================================================================");

            Console.WriteLine("1. Select Query");
            Console.WriteLine("2. Insert Query");
            Console.WriteLine("3. Update Query");
            Console.WriteLine("4. Delete Query");
            Console.WriteLine("5. Exit ");

            Console.WriteLine("Enter Your Choice");
            var choice = Console.ReadLine();

            var answer = "";
            switch (choice)
            {

                case "1":
                    Console.WriteLine("SELECT query selected");
                    Console.WriteLine("Describe the SELECT query you want");
                    var selectQuery = Console.ReadLine();
                    answer = await sqlAssistant.GenerateSelectQuery(selectQuery);
                    Console.WriteLine(answer);
                    break;
                case "2":
                    Console.WriteLine("INSERT query selected");

                    Console.WriteLine("Describe the Insert query you want");
                    var insertQuery = Console.ReadLine();
                    answer = await sqlAssistant.GenerateInsertQuery(insertQuery);
                    Console.WriteLine(answer);
                    break;
                case "3":
                    Console.WriteLine("UPDATE query selected");


                    Console.WriteLine("Describe the update query you want");
                    var updateQuery = Console.ReadLine();
                    answer = await sqlAssistant.GenerateUpdateQuery(updateQuery);
                    Console.WriteLine(answer);
                    break;


                case "4":
                    Console.WriteLine("DELETE query selected");
                    Console.WriteLine("Delete operation can permanenetly delete data. Do you want to coninue (Yes OR No");

                    var confirmation = Console.ReadLine();
                    if (confirmation == "Yes")
                    {
                        Console.WriteLine("Describe the DELETE query you want");
                        var deleteQuery = Console.ReadLine();
                        answer = await sqlAssistant.GenerateDeleteQuery(deleteQuery);
                        Console.WriteLine(answer);
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "5":
                    Console.WriteLine("Exiting...........");
                    break;
                default:
                    Console.WriteLine("Invalid choice please select between 1-5");
                    break;


            }



            if (choice == "5")
            {
                break;
            }

           
        }


    }
}