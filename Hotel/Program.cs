using Hotel.Controllers;

namespace Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new HotelContraller();
            while (true)
            {
                Console.WriteLine(@"1. Показване на всички гости
                                    2. Добавяне на нов гост
                                    3. Стаи с цена между 80 и 100 лв (в низходящ ред)
                                    4. Изтриване на резервация по ID
                                    5. Брой свободни стаи
                                    6. Минимална цена по статус
                                    7. ID-та на активни резервации
                                    0. Изход"
                );

                Console.Write("Моля, въведете избора си: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        controller.ListGuests(); 
                        break;
                    case "2": 
                        controller.AddGuest(); 
                        break;
                    case "3": 
                        controller.ListRoomsBetweenPrices(); 
                        break;
                    case "4": 
                        controller.DeleteReservationById(); 
                        break;
                    case "5":
                        controller.CountFreeRooms(); 
                        break;
                    case "6": 
                        controller.MinPriceByStatus(); 
                        break;
                    case "0": return;
                    default:
                        Console.WriteLine("Невалиден избор.");
                        break;
                }
            }
        }
    }
}
