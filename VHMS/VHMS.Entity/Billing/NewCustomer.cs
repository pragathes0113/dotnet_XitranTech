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
        public int HouseTypeID { get; set; }
        public string CurrentAddress { get; set; }
        public string ShiftingAddress { get; set; }

        public DateTime PackingDate { get; set; }
        public DateTime ReachingDate { get; set; }
        public string sPackingDate { get; set; }
        public string sReachingDate { get; set; }

        public string Kms { get; set; }
        public string TypeofMove { get; set; }

        public bool RequiresMoreThanTwoPersons { get; set; }
        public decimal RequiresMoreThanTwoPersonsRate { get; set; }
        public bool HasStaircase { get; set; }
        public decimal HasStaircaseRate { get; set; }
        public bool HasServiceElevator { get; set; }
        public decimal HasServiceElevatorRate { get; set; }
        public bool HasProperParking { get; set; }
        public decimal HasProperParkingRate { get; set; }
        public bool AdditionalChargeForLongWalks { get; set; }
        public decimal AdditionalChargeForLongWalksRate { get; set; }

        public bool WantsPackingHelp { get; set; }
        public decimal WantsPackingHelpRate { get; set; }
        public bool PackingHandledByTeam { get; set; }
        public decimal PackingHandledByTeamRate { get; set; }
        public bool NeedsPackingMaterials { get; set; }
        public decimal NeedsPackingMaterialsRate { get; set; }

        public bool HasFragileItems { get; set; }
        public decimal HasFragileItemsRate { get; set; }
        public bool HasHazardousItems { get; set; }
        public decimal HasHazardousItemsRate { get; set; }
        public bool HasInventoryList { get; set; }
        public decimal HasInventoryListRate { get; set; }
        public bool InventoryListNote { get; set; }
        public decimal InventoryListNoteRate { get; set; }

        public bool HasPiano { get; set; }
        public decimal HasPianoRate { get; set; }
        public bool AdditionalChargeForPiano { get; set; }
        public decimal AdditionalChargeForPianoRate { get; set; }

        public bool HasVehicleToMove { get; set; }
        public decimal HasVehicleToMoveRate { get; set; }
        public bool VehicleType { get; set; }
        public decimal VehicleTypeRate { get; set; }
        public bool NeedsTowVanOrDriver { get; set; }
        public decimal NeedsTowVanOrDriverRate { get; set; }

        public bool NeedsJunkRemoval { get; set; }
        public decimal NeedsJunkRemovalRate { get; set; }
        public bool RequiresOvernightStop { get; set; }
        public decimal RequiresOvernightStopRate { get; set; }

        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public HouseType HouseType { get; set; } // Navigation Property
    }
}

