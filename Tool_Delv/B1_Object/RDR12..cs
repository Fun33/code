using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C 
{
    class RDR12 : B1iSN 
    {
        public string DocEntry = "DocEntry";
        public string DocNum = "DocNum";  
        public string StreetNoS = "ShipToStreetNo";    
        public string AddrTypeS = "ShipToAddressType"; 
        public string StreetNoB = "BillToStreetNo";   
        public string AddrTypeB = "BillToAddressType";

         
        public string LineNum = "LineNum";
        public string TaxId0 = "TaxId0";
        public string TaxId1 = "TaxId1";
        public string TaxId2 = "TaxId2";
        public string TaxId3 = "TaxId3";
        public string TaxId4 = "TaxId4";
        public string TaxId5 = "TaxId5";
        public string TaxId6 = "TaxId6";
        public string TaxId7 = "TaxId7";
        public string TaxId8 = "TaxId8";
        public string TaxId9 = "TaxId9";
        public string State = "State";
        public string County = "County";
        public string Incoterms = "Incoterms";
        public string Vehicle = "Vehicle";
        public string VidState = "VehicleState";
        public string NfRef = "NFRef";
        public string Carrier = "Carrier";
        public string QoP = "PackQuantity";
        public string PackDesc = "PackDescription";
        public string Brand = "Brand";
        public string NoSU = "ShipUnitNo";
        public string NetWeight = "NetWeight";
        public string GrsWeight = "GrossWeight";
        public string StreetS = "StreetS";
        public string BlockS = "BlockS";
        public string BuildingS = "BuildingS";
        public string CityS = "CityS";
        public string ZipCodeS = "ZipCodeS";
        public string CountyS = "CountyS";
        public string StateS = "StateS";
        public string CountryS = "CountryS";
        public string StreetB = "StreetB";
        public string BlockB = "BlockB";
        public string BuildingB = "BuildingB";
        public string CityB = "CityB";
        public string ZipCodeB = "ZipCodeB";
        public string CountyB = "CountyB";
        public string StateB = "StateB";
        public string CountryB = "CountryB";
        public string ImpORExp = "ImportOrExport";

        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocEntry", DocEntry);
      tmp = Trans(tmp, "DocNum",DocNum);
tmp = Trans(tmp, "LineNum",LineNum);
tmp = Trans(tmp, "TaxId0",TaxId0);
tmp = Trans(tmp, "TaxId1",TaxId1);
tmp = Trans(tmp, "TaxId2",TaxId2);
tmp = Trans(tmp, "TaxId3",TaxId3);
tmp = Trans(tmp, "TaxId4",TaxId4);
tmp = Trans(tmp, "TaxId5",TaxId5);
tmp = Trans(tmp, "TaxId6",TaxId6);
tmp = Trans(tmp, "TaxId7",TaxId7);
tmp = Trans(tmp, "TaxId8",TaxId8);
tmp = Trans(tmp, "TaxId9",TaxId9);
tmp = Trans(tmp, "State",State);
tmp = Trans(tmp, "County",County);
tmp = Trans(tmp, "Incoterms",Incoterms);
tmp = Trans(tmp, "Vehicle",Vehicle);
tmp = Trans(tmp, "VidState",VidState);
tmp = Trans(tmp, "NfRef",NfRef);
tmp = Trans(tmp, "Carrier",Carrier);
tmp = Trans(tmp, "QoP",QoP);
tmp = Trans(tmp, "PackDesc",PackDesc);
tmp = Trans(tmp, "Brand",Brand);
tmp = Trans(tmp, "NoSU",NoSU);
tmp = Trans(tmp, "NetWeight",NetWeight);
tmp = Trans(tmp, "GrsWeight",GrsWeight);
tmp = Trans(tmp, "StreetS",StreetS);
tmp = Trans(tmp, "BlockS",BlockS);
tmp = Trans(tmp, "BuildingS",BuildingS);
tmp = Trans(tmp, "CityS",CityS);
tmp = Trans(tmp, "ZipCodeS",ZipCodeS);
tmp = Trans(tmp, "CountyS",CountyS);
tmp = Trans(tmp, "StateS",StateS);
tmp = Trans(tmp, "CountryS",CountryS);
tmp = Trans(tmp, "StreetB",StreetB);
tmp = Trans(tmp, "BlockB",BlockB);
tmp = Trans(tmp, "BuildingB",BuildingB);
tmp = Trans(tmp, "CityB",CityB);
tmp = Trans(tmp, "ZipCodeB",ZipCodeB);
tmp = Trans(tmp, "CountyB",CountyB);
tmp = Trans(tmp, "StateB",StateB);
tmp = Trans(tmp, "CountryB",CountryB);
tmp = Trans(tmp, "ImpORExp",ImpORExp);

tmp = Trans(tmp, "DocNum", DocNum);
tmp = Trans(tmp, "LineNum", LineNum);
tmp = Trans(tmp, "StreetS", StreetS);
tmp = Trans(tmp, "StreetNoS", StreetNoS);
tmp = Trans(tmp, "BlockS", BlockS);
tmp = Trans(tmp, "BuildingS", BuildingS);
tmp = Trans(tmp, "CityS", CityS);
tmp = Trans(tmp, "ZipCodeS", ZipCodeS);
tmp = Trans(tmp, "CountyS", CountyS);
tmp = Trans(tmp, "StateS", StateS);
tmp = Trans(tmp, "CountryS", CountryS);
tmp = Trans(tmp, "AddrTypeS", AddrTypeS);
tmp = Trans(tmp, "StreetB", StreetB);
tmp = Trans(tmp, "StreetNoB", StreetNoB);
tmp = Trans(tmp, "BlockB", BlockB);
tmp = Trans(tmp, "BuildingB", BuildingB);
tmp = Trans(tmp, "CityB", CityB);
tmp = Trans(tmp, "ZipCodeB", ZipCodeB);
tmp = Trans(tmp, "CountyB", CountyB);
tmp = Trans(tmp, "StateB", StateB);
tmp = Trans(tmp, "CountryB", CountryB);
tmp = Trans(tmp, "AddrTypeB", AddrTypeB);
        }
    }
}
