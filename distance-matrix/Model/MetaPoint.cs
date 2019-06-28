public class MetaPoint
    {
        public string name;
        public string county_name;
        public string district_title;
        public string ruraldistrict_title;
        public string suburb_title;
        public string neighbourhood_title;

        public MetaPoint(string name, string county_name, string district_title, string ruraldistrict_title, string suburb_title, string neighbourhood_title)
        {
            this.name = name;
            this.county_name = county_name;
            this.district_title = district_title;
            this.ruraldistrict_title = ruraldistrict_title;
            this.suburb_title = suburb_title;
            this.neighbourhood_title = neighbourhood_title;
        }
    }