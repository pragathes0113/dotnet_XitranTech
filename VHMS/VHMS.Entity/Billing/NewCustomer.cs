using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VHMS.Entity.Billing
{
    public class NewCustomer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public int HouseTypeID { get; set; }
        public string CurrentAddress { get; set; }
        public string ShiftingAddress { get; set; }

        public DateTime PackingDate { get; set; }
        public DateTime ReachingDate { get; set; }
        public string sPackingDate { get; set; }
        public string sReachingDate { get; set; }

        public string Kms { get; set; }
        public string TypeofMove { get; set; }

        public string RequiresMoreThanTwoPersons { get; set; }
        public decimal RequiresMoreThanTwoPersonsRate { get; set; }
        public string HasStaircase { get; set; }
        public decimal HasStaircaseRate { get; set; }
        public string HasServiceElevator { get; set; }
        public decimal HasServiceElevatorRate { get; set; }
        public string HasProperParking { get; set; }
        public decimal HasProperParkingRate { get; set; }
        public string AdditionalChargeForLongWalks { get; set; }
        public decimal AdditionalChargeForLongWalksRate { get; set; }

        public string WantsPackingHelp { get; set; }
        public decimal WantsPackingHelpRate { get; set; }
        public string PackingHandledByTeam { get; set; }
        public decimal PackingHandledByTeamRate { get; set; }
        public string NeedsPackingMaterials { get; set; }
        public decimal NeedsPackingMaterialsRate { get; set; }

        public string HasFragileItems { get; set; }
        public decimal HasFragileItemsRate { get; set; }
        public string HasHazardousItems { get; set; }
        public decimal HasHazardousItemsRate { get; set; }
        public string HasInventoryList { get; set; }
        public decimal HasInventoryListRate { get; set; }
        public string InventoryListNote { get; set; }
        public decimal InventoryListNoteRate { get; set; }

        public string HasPiano { get; set; }
        public decimal HasPianoRate { get; set; }
        public string AdditionalChargeForPiano { get; set; }
        public decimal AdditionalChargeForPianoRate { get; set; }

        public string HasVehicleToMove { get; set; }
        public decimal HasVehicleToMoveRate { get; set; }
        public string VehicleType { get; set; }
        public decimal VehicleTypeRate { get; set; }
        public string NeedsTowVanOrDriver { get; set; }
        public decimal NeedsTowVanOrDriverRate { get; set; }

        public string NeedsJunkRemoval { get; set; }
        public decimal NeedsJunkRemovalRate { get; set; }
        public string RequiresOvernightStop { get; set; }
        public decimal RequiresOvernightStopRate { get; set; }

        public string CallStatus { get; set; }

        public string WeekType { get; set; }
        public string Note { get; set; }

        public decimal GSTAmount { get; set; }
        public decimal NetAmount { get; set; }

        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public HouseType HouseType { get; set; } // Navigation Property
    }
}

