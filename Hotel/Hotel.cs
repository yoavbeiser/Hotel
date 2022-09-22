using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel
{
    public class Hotel
    {
        public string Name { get; set; }

        public IList<Room> Rooms { get; set; }

        public void Checkin(IList<Guest> guests, int roomRank)
        {
            Rooms.Where(room => room.IsRoomAvailble).First(_ => _.Rank >= roomRank).Host(guests);
        }

        public void Transfer(Room room, Room otherRoom)
        {
            if (!otherRoom.IsRoomAvailble)
                throw new UnavailableRoomException();

            room.Transfer(otherRoom);
        }

        public void Checkout(Guest guest)
        {
            Room room = Rooms.First(_ => _.Contains(guest));
            room.Checkout();
            double finalBill = room.CalculateFinalBill();

            Console.WriteLine($"Final Bill For Room {room.RoomNumber} is: {finalBill}");
        }
    }
}

