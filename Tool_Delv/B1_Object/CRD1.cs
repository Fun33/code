using System;
using System.Collections.Generic;
using System.Text;

namespace AP_C 
{
    class CRD1:B1iSN 
    {
        public string CardCode = "CardCode";
        public string LineNum = "LineNum";
        public string Adress = "AddressName";
        public string Street = "Street";
        public string Block = "Block";
        public string ZipCode = "ZipCode";
        public string City = "City";
        public string County = "County";
        public string Country = "Country";
        public string State = "State";
        public string LicTradNum = "FederalTaxID";
        public string TaxCode = "TaxCode";
        public string Building = "BuildingFloorRoom";
        public string AdresType = "AddressType";
        public string Address2 = "AddressName2";
        public string Address3 = "AddressName3";
        public string AddrType = "TypeOfAddress";
        public string StreetNo = "StreetNo";


        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "CardCode", CardCode);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "Adress", Adress);
            tmp = Trans(tmp, "Street", Street);
            tmp = Trans(tmp, "Block", Block);
            tmp = Trans(tmp, "ZipCode", ZipCode);
            tmp = Trans(tmp, "City", City);
            tmp = Trans(tmp, "County", County);
            tmp = Trans(tmp, "Country", Country);
            tmp = Trans(tmp, "State", State);
            tmp = Trans(tmp, "LicTradNum", LicTradNum);
            tmp = Trans(tmp, "TaxCode", TaxCode);
            tmp = Trans(tmp, "Building", Building);
            tmp = Trans(tmp, "AdresType", AdresType);
            tmp = Trans(tmp, "Address2", Address2);
            tmp = Trans(tmp, "Address3", Address3);
            tmp = Trans(tmp, "AddrType", AddrType);
            tmp = Trans(tmp, "StreetNo", StreetNo);


        }
    }
}
