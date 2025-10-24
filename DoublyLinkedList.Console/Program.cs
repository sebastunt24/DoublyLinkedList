using DoublyLinkedList.Core;

var list = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter data to insert at beginning: ");
            var dataBegin = Console.ReadLine();
            if (dataBegin != null)
            {
                list.InsertAtBeginning(dataBegin);
            }
            break;

        case "2":
            Console.Write("Enter data to insert at end: ");
            var dataEnd = Console.ReadLine();
            if (dataEnd != null)
            {
                list.InsertAtEnd(dataEnd);
            }
            break;

        case "3":
            Console.WriteLine("List (Forward):");
            Console.WriteLine(list.GetForward());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "4":
            Console.WriteLine("List (Backward):");
            Console.WriteLine(list.GetBackward());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option. Press any key to try again...");
            Console.ReadKey();
            break;
    }
} while (opc != "0");

string Menu()
{
    Console.WriteLine("Doubly Linked List Menu");
    Console.WriteLine("1. Insert at Beginning");
    Console.WriteLine("2. Insert at End");
    Console.WriteLine("3. Display List Forward");
    Console.WriteLine("4. Display List Backward");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");
    return Console.ReadLine() ?? "0";
}