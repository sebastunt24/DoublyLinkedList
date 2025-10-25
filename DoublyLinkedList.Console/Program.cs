using DoublyLinkedList.Core;

var list = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter data to agregar: ");
            var dataAgregar = Console.ReadLine();
            if (dataAgregar != null)
            {
                list.Add(dataAgregar);
            }
            break;

        case "2":
            Console.WriteLine("List (Forward):");
            Console.WriteLine(list.GetForward());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "3":
            Console.WriteLine("List (Backward):");
            Console.WriteLine(list.GetBackward());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "4":
            list.Reverse();
            Console.WriteLine("List sorted in descending order.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "5":
            var modes = list.GetModes();
            if (modes.Count == 0)
            {
                Console.WriteLine("No mode found");
            }
            else
            {
                Console.WriteLine("Mode(s): " + string.Join(", ", modes));
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "6":
            Console.WriteLine("Frequency Graph:");
            Console.WriteLine(list.GetFrequencyGraph());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "7":
            Console.Write("Enter data to check existence: ");
            var dataCheck = Console.ReadLine();
            if (dataCheck != null)
            {
                bool exists = list.Exists(dataCheck);
                Console.WriteLine(exists ? $"{dataCheck} exists in the list." : $"{dataCheck} does not exist in the list.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "8":
            Console.Write("Enter data to delete an occurrence: ");
            var dataDelete = Console.ReadLine();
            if (dataDelete != null)
            {
                bool deleted = list.RemoveOne(dataDelete);
                Console.WriteLine(deleted ? $"{dataDelete} deleted from the list." : $"{dataDelete} not found in the list.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "9":
            Console.Write("Are you sure you want to delete all occurrences from the list? (Y/N): ");
            var confirm = Console.ReadLine();

            if (confirm?.ToLower() == "y" || confirm?.ToLower() == "Y")
            {
                list.Clear();
                Console.WriteLine("All occurrences have been removed.");
            }
            else
            {
                Console.WriteLine("Operation canceled. No data deleted.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        //case "":
        //    Console.Write("Enter data to insert at beginning: ");
        //    var dataBegin = Console.ReadLine();
        //    if (dataBegin != null)
        //    {
        //        list.InsertAtBeginning(dataBegin);
        //    }
        //    break;

        //case "":
        //    Console.Write("Enter data to insert at end: ");
        //    var dataEnd = Console.ReadLine();
        //    if (dataEnd != null)
        //    {
        //        list.InsertAtEnd(dataEnd);
        //    }
        //    break;

        default:
            Console.WriteLine("Invalid option. Press any key to try again...");
            Console.ReadKey();
            break;
    }
} while (opc != "0");

string Menu()
{
    Console.WriteLine("Doubly Linked List Menu");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Display List Forward");
    Console.WriteLine("3. Display List Backward");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show the mode(s)");
    Console.WriteLine("6. Graphic");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Delete an occurrence.");
    Console.WriteLine("9. Delete all occurrence.");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");

    //Console.WriteLine(". Insert at Beginning");
    //Console.WriteLine(". Insert at End");
    return Console.ReadLine() ?? "0";
}