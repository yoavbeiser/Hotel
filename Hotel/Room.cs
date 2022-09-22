using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel
{
    public class Room
    {
        public MinibarManager MinibarManager { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public IList<Guest> Guests { get; set; }
        public int CleanessLevel { get; set; }
        public int Rank { get; set; }
        public double ClientSatisfaction { get; set; }

        public bool IsRoomAvailble => !Guests.Any();
        public bool IsBetterThen(Room other) => Rank > other.Rank;

        public void Host(IList<Guest> guests)
        {
            if (!IsRoomAvailble)
                throw new UnavailableRoomException();

            Guests = guests;
            ClientSatisfaction = 1.0;
        }

        public void Transfer(Room otherRoom)
        {
            otherRoom.Host(Guests);
            Guests = new List<Guest>();
            otherRoom.MinibarManager.SetInitialBill(MinibarManager.Charge());
        }

        public double CalculateFinalBill()
        {
            return (Rank * 100 + CleanessLevel * 50) * Guests.Count * FloorNumber + MinibarManager.Charge();
        }

        public void Checkout()
        {
            ClientSatisfaction = Guests.First().GetSatisfaction();
            Guests = new List<Guest>();
        }

        public bool Contains(Guest guest)
        {
            return Guests.Contains(guest);
        }
    }
}
3