namespace BlazorserverApp.Data
{
    public static class MedicalAidData
    {
        private static Dictionary<string, List<string>> _medicalAidList = new Dictionary<string, List<string>>()
        {
            ["Fedhealth"] = new List<string> { "FlexiFED 1", "FlexiFED 2", "maxima PLUS"},
            ["Discovery"] = new List<string> { "Classic", "Classic Delta", "Essential", "Essential Delta", "Coastal" },
            ["Gems"] = new List<string> { "Tanzanite One", "Beryl", "Ruby", "Emerald Value", "Emerald" },
            ["MedShield"] = new List<string> { "MediSwift", "PremiumPlus", "MediValue", "MediCurve"},
        };
        
        public static Dictionary<string, List<string>> MedicalAidList { get { return _medicalAidList; } }

        private static void AddMedicalAids()
        {

        }

    }
}
