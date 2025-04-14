using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class HotelContraller
    {
        public HotelManagerContext _hotelManagerContext;

        public HotelContraller() 
        {
            _hotelManagerContext = new HotelManagerContext();
        }

        public void ListGuests()
        {
            var guests = _hotelManagerContext.Guests.ToList();
            foreach (var guest in guests)
            {
                Console.WriteLine($"{guest.FirstName} {guest.LastName}");
            }
        }

        public void AddGuest()
        {
            Console.Write("Име: ");
            string first = Console.ReadLine();
            Console.Write("Фамилия: ");
            string last = Console.ReadLine();
            Console.Write("ЕГН: ");
            string ucn = Console.ReadLine();
            Console.Write("Телефон: ");
            string phone = Console.ReadLine();

            var guest = new Guest { FirstName = first, LastName = last, Ucn = ucn, PhoneNumber = phone };
            _hotelManagerContext.Guests.Add(guest);
            _hotelManagerContext.SaveChanges();

            Console.WriteLine("Гостът е успешно добавен.");
        }

        public void ListRoomsBetweenPrices()
        {
            var rooms = _hotelManagerContext.Rooms
                .Where(r => r.Price >= 80 && r.Price <= 100)
                .OrderByDescending(r => r.Price)
                .Select(r => r.Number);

            foreach (var num in rooms)
            {
                Console.WriteLine(num);
            }
        }

        public void DeleteReservationById()
        {
            Console.Write("Въведете ID на резервацията: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var res = _hotelManagerContext.Reservations.Find(id);
                if (res != null)
                {
                    _hotelManagerContext.Reservations.Remove(res);
                    _hotelManagerContext.SaveChanges();
                    Console.WriteLine($"Резервацията с ID {id} е изтрита успешно.");
                }
                else
                {
                    Console.WriteLine("Няма такава резервация.");
                }
            }
        }

        public void CountFreeRooms()
        {
            int count = _hotelManagerContext.Rooms.Count(r => r.Status == "free");
            Console.WriteLine($"Свободни стаи: {count}");
        }

        public void MinPriceByStatus()
        {
            Console.Write("Въведете статус на стаята: ");
            string status = Console.ReadLine();

            var prices = _hotelManagerContext.Rooms
                .Where(r => r.Status == status)
                .Select(r => r.Price);

            if (prices.Any())
            {
                Console.WriteLine($"Минимална цена: {prices.Min():F2} лв");
            }
            else
            {
                Console.WriteLine("Няма стаи с този статус.");
            }
        }

        public void ReturnId()
        {

        }
       

    }
}
