namespace FirstBlazorApp
{
    public class AgencyOverview
    {
        public int fiscal_year { get; set; }
        public string toptier_code { get; set; }
        public string name { get; set; }
        public string? abbreviation { get; set; }
        public int agency_id { get; set; }
        public string? icon_filename { get; set;}

        public string? mission { get; set; }

        public string? website { get; set; }

        public string? congressional_justification_url { get; set; }
        public string? about_agency_data { get; set; }

        public int subtier_agency_count { get; set; }

        public List<DefCodes>? def_codes { get; set; }

        public string[]? messages { get; set; }
    }

    public class DefCodes
    {
        public string code { get; set; }

        public string public_law { get; set; }
        public string? disaster { get; set; }
        public string? title { get; set; }

        public string? urls { get; set; }

    }

}
