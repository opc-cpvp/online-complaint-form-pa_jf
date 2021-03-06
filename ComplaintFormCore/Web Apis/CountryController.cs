﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintFormCore.Web_Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            string language = "en";
            var lang = HttpContext.Request.Query.Where(k => k.Key == "lang").Select(v => v.Value).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(lang) == false)
            {
                language = lang;
            }

            if(language == "fr")
            {
                return GetCountryListFrench();
            }
            else
            {
                return GetCoutryList();
            }
        }

        // GET: api/Country
        [HttpGet]
        private static List<Country> GetCoutryList()
        {
            return new List<Country>
            {
                new Country {Value = "CA", Text = "Canada"},
                new Country {Value = "US", Text = "United States"},
                new Country {Value = "AL", Text = "Albania"},
                new Country {Value = "DZ", Text = "Algeria"},
                new Country {Value = "AS", Text = "American Samoa"},
                new Country {Value = "AD", Text = "Andorra"},
                new Country {Value = "AO", Text = "Angola"},
                new Country {Value = "AI", Text = "Anguilla"},
                new Country {Value = "AQ", Text = "Antarctica"},
                new Country {Value = "AG", Text = "Antigua and Barbuda"},
                new Country {Value = "AR", Text = "Argentina"},
                new Country {Value = "AM", Text = "Armenia"},
                new Country {Value = "AW", Text = "Aruba"},
                new Country {Value = "AU", Text = "Australia"},
                new Country {Value = "AT", Text = "Austria"},
                new Country {Value = "AZ", Text = "Azerbaidjan"},
                new Country {Value = "BS", Text = "Bahamas"},
                new Country {Value = "BH", Text = "Bahrain"},
                new Country {Value = "BD", Text = "Bangladesh"},
                new Country {Value = "BB", Text = "Barbados"},
                new Country {Value = "BY", Text = "Belarus"},
                new Country {Value = "BE", Text = "Belgium"},
                new Country {Value = "BZ", Text = "Belize"},
                new Country {Value = "BJ", Text = "Benin"},
                new Country {Value = "BM", Text = "Bermuda"},
                new Country {Value = "BO", Text = "Bolivia"},
                new Country {Value = "BA", Text = "Bosnia-Herzegovina"},
                new Country {Value = "BW", Text = "Botswana"},
                new Country {Value = "BV", Text = "Bouvet Island"},
                new Country {Value = "BR", Text = "Brazil"},
                new Country {Value = "IO", Text = "British Indian Ocean Territories"},
                new Country {Value = "BN", Text = "Brunei Darussalam"},
                new Country {Value = "BG", Text = "Bulgaria"},
                new Country {Value = "BF", Text = "Burkina Faso"},
                new Country {Value = "BI", Text = "Burundi"},
                new Country {Value = "BT", Text = "Buthan"},
                new Country {Value = "KH", Text = "Cambodia"},
                new Country {Value = "CM", Text = "Cameroon"},
                new Country {Value = "CV", Text = "Cape Verde"},
                new Country {Value = "KY", Text = "Cayman Islands"},
                new Country {Value = "CF", Text = "Central African Republic"},
                new Country {Value = "TD", Text = "Chad"},
                new Country {Value = "CL", Text = "Chile"},
                new Country {Value = "CN", Text = "China"},
                new Country {Value = "CX", Text = "Christmas Island"},
                new Country {Value = "CC", Text = "Cocos (Keeling) Islands"},
                new Country {Value = "CO", Text = "Colombia"},
                new Country {Value = "KM", Text = "Comoros"},
                new Country {Value = "CG", Text = "Congo"},
                new Country {Value = "CK", Text = "Cook Islands"},
                new Country {Value = "CR", Text = "Costa Rica"},
                new Country {Value = "HR", Text = "Croatia"},
                new Country {Value = "CU", Text = "Cuba"},
                new Country {Value = "CY", Text = "Cyprus"},
                new Country {Value = "CZ", Text = "Czech Republic"},
                new Country {Value = "CS", Text = "Czechoslovakia"},
                new Country {Value = "DK", Text = "Denmark"},
                new Country {Value = "DJ", Text = "Djibouti"},
                new Country {Value = "DM", Text = "Dominica"},
                new Country {Value = "DO", Text = "Dominican Republic"},
                new Country {Value = "TP", Text = "East Timor"},
                new Country {Value = "EC", Text = "Ecuador"},
                new Country {Value = "EG", Text = "Egypt"},
                new Country {Value = "SV", Text = "El Salvador"},
                new Country {Value = "GQ", Text = "Equatorial Guinea"},
                new Country {Value = "ER", Text = "Eritrea"},
                new Country {Value = "EE", Text = "Estonia"},
                new Country {Value = "ET", Text = "Ethiopia"},
                new Country {Value = "FK", Text = "Falkland Islands(Malvinas)"},
                new Country {Value = "FO", Text = "Faroe Islands"},
                new Country {Value = "FJ", Text = "Fiji"},
                new Country {Value = "FI", Text = "Finland"},
                new Country {Value = "FR", Text = "France"},
                new Country {Value = "FX", Text = "France (European Territory)"},
                new Country {Value = "TF", Text = "French Southern Territories"},
                new Country {Value = "GA", Text = "Gabon"},
                new Country {Value = "GM", Text = "Gambia"},
                new Country {Value = "GE", Text = "Georgia"},
                new Country {Value = "DE", Text = "Germany"},
                new Country {Value = "GH", Text = "Ghana"},
                new Country {Value = "GI", Text = "Gibraltar"},
                new Country {Value = "GB", Text = "Great Britain (UK"},
                new Country {Value = "GR", Text = "Greece"},
                new Country {Value = "GL", Text = "Greenland"},
                new Country {Value = "GD", Text = "Grenada"},
                new Country {Value = "GP", Text = "Guadeloupe (FR)"},
                new Country {Value = "GU", Text = "Guam (US)"},
                new Country {Value = "GT", Text = "Guatemala"},
                new Country {Value = "GN", Text = "Guinea"},
                new Country {Value = "GW", Text = "Guinea Bissau"},
                new Country {Value = "GY", Text = "Guyana"},
                new Country {Value = "GF", Text = "Guyana (FR)"},
                new Country {Value = "HT", Text = "Haiti"},
                new Country {Value = "HM", Text = "Heard and McDonald Islands"},
                new Country {Value = "HN", Text = "Honduras"},
                new Country {Value = "HK", Text = "Hong Kong"},
                new Country {Value = "HU", Text = "Hungary"},
                new Country {Value = "IS", Text = "Iceland"},
                new Country {Value = "IN", Text = "India"},
                new Country {Value = "ID", Text = "Indonesia"},
                new Country {Value = "IR", Text = "Iran"},
                new Country {Value = "IQ", Text = "Iraq"},
                new Country {Value = "IE", Text = "Ireland"},
                new Country {Value = "IL", Text = "Israel"},
                new Country {Value = "IT", Text = "Italy"},
                new Country {Value = "CI", Text = "Ivory Coast"},
                new Country {Value = "JM", Text = "Jamaica"},
                new Country {Value = "JP", Text = "Japan"},
                new Country {Value = "JO", Text = "Jordan"},
                new Country {Value = "KZ", Text = "Kazachstan"},
                new Country {Value = "KE", Text = "Kenya"},
                new Country {Value = "KG", Text = "Kirgistan"},
                new Country {Value = "KI", Text = "Kiribati"},
                new Country {Value = "KP", Text = "Korea (North)"},
                new Country {Value = "KR", Text = "Korea (South)"},
                new Country {Value = "KW", Text = "Kuwait"},
                new Country {Value = "LA", Text = "Laos"},
                new Country {Value = "LV", Text = "Latvia"},
                new Country {Value = "LB", Text = "Lebanon"},
                new Country {Value = "LS", Text = "Lesotho"},
                new Country {Value = "LR", Text = "Liberia"},
                new Country {Value = "LY", Text = "Libya"},
                new Country {Value = "LI", Text = "Liechtenstein"},
                new Country {Value = "LT", Text = "Lithuania"},
                new Country {Value = "LU", Text = "Luxembourg"},
                new Country {Value = "MO", Text = "Macau"},
                new Country {Value = "MK", Text = "Macedonia"},
                new Country {Value = "MG", Text = "Madagascar"},
                new Country {Value = "MW", Text = "Malawi"},
                new Country {Value = "MY", Text = "Malaysia"},
                new Country {Value = "MV", Text = "Maldives"},
                new Country {Value = "ML", Text = "Mali"},
                new Country {Value = "MT", Text = "Malta"},
                new Country {Value = "MH", Text = "Marshall Islands"},
                new Country {Value = "MQ", Text = "Martinique (FR)"},
                new Country {Value = "MR", Text = "Mauritania"},
                new Country {Value = "MU", Text = "Mauritius"},
                new Country {Value = "MX", Text = "Mexico"},
                new Country {Value = "FM", Text = "Micronesia"},
                new Country {Value = "MD", Text = "Moldavia"},
                new Country {Value = "MC", Text = "Monaco"},
                new Country {Value = "MN", Text = "Mongolia"},
                new Country {Value = "MS", Text = "Montserrat"},
                new Country {Value = "MA", Text = "Morocco"},
                new Country {Value = "MZ", Text = "Mozambique"},
                new Country {Value = "MM", Text = "Myanmar (Burma)"},
                new Country {Value = "NA", Text = "Namibia"},
                new Country {Value = "NR", Text = "Nauru"},
                new Country {Value = "NP", Text = "Nepal"},
                new Country {Value = "AN", Text = "Netherland Antilles"},
                new Country {Value = "NL", Text = "Netherlands"},
                new Country {Value = "NT", Text = "Neutral Zone"},
                new Country {Value = "NC", Text = "New Caledonia (FR)"},
                new Country {Value = "NZ", Text = "New Zealand"},
                new Country {Value = "NI", Text = "Nicaragua"},
                new Country {Value = "NE", Text = "Niger"},
                new Country {Value = "NG", Text = "Nigeria"},
                new Country {Value = "NU", Text = "Niue"},
                new Country {Value = "NF", Text = "Norfolk Island"},
                new Country {Value = "MP", Text = "Northern Mariana Islands"},
                new Country {Value = "NO", Text = "Norway"},
                new Country {Value = "OM", Text = "Oman"},
                new Country {Value = "PK", Text = "Pakistan"},
                new Country {Value = "PW", Text = "Palau"},
                new Country {Value = "PA", Text = "Panama"},
                new Country {Value = "PG", Text = "Papua New Guinea"},
                new Country {Value = "PY", Text = "Paraguay"},
                new Country {Value = "PE", Text = "Peru"},
                new Country {Value = "PH", Text = "Philippines"},
                new Country {Value = "PN", Text = "Pitcairn"},
                new Country {Value = "PL", Text = "Poland"},
                new Country {Value = "PF", Text = "Polynesia (FR)"},
                new Country {Value = "PT", Text = "Portugal"},
                new Country {Value = "PR", Text = "Puerto Rico (US)"},
                new Country {Value = "QA", Text = "Qatar"},
                new Country {Value = "RE", Text = "Reunion (FR)"},
                new Country {Value = "RO", Text = "Romania"},
                new Country {Value = "RU", Text = "Russian Federation"},
                new Country {Value = "RW", Text = "Rwanda"},
                new Country {Value = "SH", Text = "Saint Helena"},
                new Country {Value = "PM", Text = "Saint Pierre and Miquelon"},
                new Country {Value = "KN", Text = "Saint Kitts Nevis Anguilla"},
                new Country {Value = "LC", Text = "Saint Lucia"},
                new Country {Value = "VC", Text = "Saint Vincent and Grenadines"},
                new Country {Value = "WS", Text = "Samoa"},
                new Country {Value = "SM", Text = "San Marino"},
                new Country {Value = "ST", Text = "Sao Tome and Principe"},
                new Country {Value = "SA", Text = "Saudi Arabia"},
                new Country {Value = "SX", Text = "Sebia and Montenegro"},
                new Country {Value = "SN", Text = "Senegal"},
                new Country {Value = "SC", Text = "Seychelles"},
                new Country {Value = "SL", Text = "Sierra Leone"},
                new Country {Value = "SG", Text = "Singapore"},
                new Country {Value = "SK", Text = "Slovak Republic"},
                new Country {Value = "SI", Text = "Slovenia"},
                new Country {Value = "SB", Text = "Solomon Islands"},
                new Country {Value = "SO", Text = "Somalia"},
                new Country {Value = "ZA", Text = "South Africa"},
                new Country {Value = "GS", Text = "South Georgia"},
                new Country {Value = "SU", Text = "Soviet Union"},
                new Country {Value = "ES", Text = "Spain"},
                new Country {Value = "LK", Text = "Sri Lanka"},
                new Country {Value = "SD", Text = "Sudan"},
                new Country {Value = "SR", Text = "Suriname"},
                new Country {Value = "SJ", Text = "Svalbard and Jan Mayen Islands"},
                new Country {Value = "SZ", Text = "Swaziland"},
                new Country {Value = "SE", Text = "Sweden"},
                new Country {Value = "CH", Text = "Switzerland"},
                new Country {Value = "SY", Text = "Syria"},
                new Country {Value = "TJ", Text = "Tadjikistan"},
                new Country {Value = "TW", Text = "Taiwan"},
                new Country {Value = "TZ", Text = "Tanzania"},
                new Country {Value = "TH", Text = "Thailand"},
                new Country {Value = "TG", Text = "Togo"},
                new Country {Value = "TK", Text = "Tokelau"},
                new Country {Value = "TO", Text = "Tonga"},
                new Country {Value = "TT", Text = "Trinidad and Tobago"},
                new Country {Value = "TN", Text = "Tunisia"},
                new Country {Value = "TR", Text = "Turkey"},
                new Country {Value = "TM", Text = "Turkmenistan"},
                new Country {Value = "TC", Text = "Turks and Caicos Islands"},
                new Country {Value = "TV", Text = "Tuvalu"},
                new Country {Value = "UG", Text = "Uganda"},
                new Country {Value = "UA", Text = "Ukraine"},
                new Country {Value = "AE", Text = "United Arab Emirates"},
                new Country {Value = "UK", Text = "United Kingdom"},
                new Country {Value = "UY", Text = "Uruguay"},
                new Country {Value = "UM", Text = "US Minor outlying Islands"},
                new Country {Value = "UZ", Text = "Uzbekistan"},
                new Country {Value = "VU", Text = "Vanuatu"},
                new Country {Value = "VA", Text = "Vatican City StateModel"},
                new Country {Value = "VE", Text = "Venezuela"},
                new Country {Value = "VN", Text = "Vietnam"},
                new Country {Value = "VG", Text = "Virgin Islands (British)"},
                new Country {Value = "VI", Text = "Virgin Islands (US)"},
                new Country {Value = "WF", Text = "Wallis and Futuna Islands"},
                new Country {Value = "WB", Text = "West Bank and Gaza"},
                new Country {Value = "EH", Text = "Western Sahara"},
                new Country {Value = "YE", Text = "Yemen"},
                new Country {Value = "YU", Text = "Yugoslavia"},
                new Country {Value = "ZR", Text = "Zaire"},
                new Country {Value = "ZM", Text = "Zambia"},
                new Country {Value = "ZW", Text = "Zimbabwe"}
            };


        }

        private static List<Country> GetCountryListFrench()
        {
            return new List<Country>
            {
                new Country {Value = "CA", Text ="Canada"},
                new Country {Value = "US", Text ="États-Unis"},
                new Country {Value = "AL", Text ="Shqipëria"},
                new Country {Value = "DZ", Text ="Algérie"},
                new Country {Value = "AS", Text ="Amerika Sāmoa"},
                new Country {Value = "AD", Text ="Andorra"},
                new Country {Value = "AO", Text ="Angola"},
                new Country {Value = "AI", Text ="Anguila"},
                new Country {Value = "AQ", Text ="Antarctica"},
                new Country {Value = "AG", Text ="Antigua and Barbuda"},
                new Country {Value = "AR", Text ="Argentina"},
                new Country {Value = "AM", Text ="Հայաստան"},
                new Country {Value = "AW", Text ="Aruba"},
                new Country {Value = "AU", Text ="Australia"},
                new Country {Value = "AT", Text ="Österreich"},
                new Country {Value = "AZ", Text ="Azərbaycan"},
                new Country {Value = "BS", Text ="Bahamas"},
                new Country {Value = "BH", Text ="Bahreïn"},
                new Country {Value = "BD", Text ="Bangladesh"},
                new Country {Value = "BB", Text ="Barbados"},
                new Country {Value = "BY", Text ="Belorussiya"},
                new Country {Value = "BE", Text ="Belgique"},
                new Country {Value = "BZ", Text ="Belize"},
                new Country {Value = "BJ", Text ="Bénin"},
                new Country {Value = "BM", Text ="Bermuda"},
                new Country {Value = "BO", Text ="Bolivia"},
                new Country {Value = "BA", Text ="Bosna I Hercegovina"},
                new Country {Value = "BW", Text ="Botswana"},
                new Country {Value = "BV", Text ="Bouvet Island"},
                new Country {Value = "BR", Text ="Brasil"},
                new Country {Value = "IO", Text ="British Indian Ocean Territories"},
                new Country {Value = "BN", Text ="Brunei Darussalam"},
                new Country {Value = "BG", Text ="България"},
                new Country {Value = "BF", Text ="Burkina Faso"},
                new Country {Value = "BI", Text ="Burundi"},
                new Country {Value = "BT", Text ="Bhoutan"},
                new Country {Value = "KH", Text ="Cambodge"},
                new Country {Value = "CM", Text ="Cameroon"},
                new Country {Value = "CV", Text ="Cabo Verde"},
                new Country {Value = "KY", Text ="Cayman Islands"},
                new Country {Value = "CF", Text ="République Centrafricaine"},
                new Country {Value = "TD", Text ="Tchad"},
                new Country {Value = "CL", Text ="Chile"},
                new Country {Value = "CN", Text ="Zhōngguó"},
                new Country {Value = "CX", Text ="Christmas Island"},
                new Country {Value = "CC", Text ="Cocos (Keeling) Islands"},
                new Country {Value = "CO", Text ="Colombia"},
                new Country {Value = "KM", Text ="Comoros"},
                new Country {Value = "CG", Text ="Congo"},
                new Country {Value = "CK", Text ="Cook Islands"},
                new Country {Value = "CR", Text ="Costa Rica"},
                new Country {Value = "HR", Text ="Hrvatska"},
                new Country {Value = "CU", Text ="Cuba"},
                new Country {Value = "CY", Text ="Chypre"},
                new Country {Value = "CZ", Text ="Česká republika"},
                new Country {Value = "CS", Text ="Czechoslovakia"},
                new Country {Value = "DK", Text ="Danmark"},
                new Country {Value = "DJ", Text ="Djibouti"},
                new Country {Value = "DM", Text ="Dominica"},
                new Country {Value = "DO", Text ="República Dominicana"},
                new Country {Value = "TP", Text ="East Timor"},
                new Country {Value = "EC", Text ="Ecuador"},
                new Country {Value = "EG", Text ="Egypt"},
                new Country {Value = "SV", Text ="El Salvador"},
                new Country {Value = "GQ", Text ="Equatorial Guinea"},
                new Country {Value = "ER", Text ="Eritrea"},
                new Country {Value = "EE", Text ="Eesti"},
                new Country {Value = "ET", Text ="Ethiopia"},
                new Country {Value = "FK", Text ="Falkland Islands(Malvinas)"},
                new Country {Value = "FO", Text ="Faroe Islands"},
                new Country {Value = "FJ", Text ="Fiji"},
                new Country {Value = "FI", Text ="Suomi"},
                new Country {Value = "FR", Text ="France"},
                new Country {Value = "FX", Text ="France (European Territory)"},
                new Country {Value = "TF", Text ="French Southern Territories"},
                new Country {Value = "GA", Text ="Gabon"},
                new Country {Value = "GM", Text ="Gambia"},
                new Country {Value = "GE", Text ="Georgia"},
                new Country {Value = "DE", Text ="Deutschland"},
                new Country {Value = "GH", Text ="Ghana"},
                new Country {Value = "GI", Text ="Gibraltar"},
                new Country {Value = "GB", Text ="Great Britain (UK"},
                new Country {Value = "GR", Text ="Grèce"},
                new Country {Value = "GL", Text ="Greenland"},
                new Country {Value = "GD", Text ="Grenada"},
                new Country {Value = "GP", Text ="Guadeloupe (FR)"},
                new Country {Value = "GU", Text ="Guam (US)"},
                new Country {Value = "GT", Text ="Guatemala"},
                new Country {Value = "GN", Text ="Guinea"},
                new Country {Value = "GW", Text ="Guinea Bissau"},
                new Country {Value = "GY", Text ="Guyana"},
                new Country {Value = "GF", Text ="Guyana (FR)"},
                new Country {Value = "HT", Text ="Haiti"},
                new Country {Value = "HM", Text ="Heard and McDonald Islands"},
                new Country {Value = "HN", Text ="Honduras"},
                new Country {Value = "HK", Text ="Hong Kong"},
                new Country {Value = "HU", Text ="Magyarország"},
                new Country {Value = "IS", Text ="Island"},
                new Country {Value = "IN", Text ="India"},
                new Country {Value = "ID", Text ="Republik Indonesia"},
                new Country {Value = "IR", Text ="Iran"},
                new Country {Value = "IQ", Text ="Iraq"},
                new Country {Value = "IE", Text ="Éire"},
                new Country {Value = "IL", Text ="Israël"},
                new Country {Value = "IT", Text ="Italia"},
                new Country {Value = "CI", Text ="Ivory Coast"},
                new Country {Value = "JM", Text ="Jamaica"},
                new Country {Value = "JP", Text ="Japon"},
                new Country {Value = "JO", Text ="Jordan"},
                new Country {Value = "KZ", Text ="Kazachstan"},
                new Country {Value = "KE", Text ="Kenya"},
                new Country {Value = "KG", Text ="Kirgistan"},
                new Country {Value = "KI", Text ="Kiribati"},
                new Country {Value = "KP", Text ="Korea (North)"},
                new Country {Value = "KR", Text ="Corée"},
                new Country {Value = "KW", Text ="Kuwait"},
                new Country {Value = "LA", Text ="Laos"},
                new Country {Value = "LV", Text ="Latvija"},
                new Country {Value = "LB", Text ="Lebanon"},
                new Country {Value = "LS", Text ="Lesotho"},
                new Country {Value = "LR", Text ="Liberia"},
                new Country {Value = "LY", Text ="Libya"},
                new Country {Value = "LI", Text ="Liechtenstein"},
                new Country {Value = "LT", Text ="Lietuva"},
                new Country {Value = "LU", Text ="Luxembourg"},
                new Country {Value = "MO", Text ="Macau"},
                new Country {Value = "MK", Text ="Македонија"},
                new Country {Value = "MG", Text ="Madagascar"},
                new Country {Value = "MW", Text ="Malawi"},
                new Country {Value = "MY", Text ="Malaysia"},
                new Country {Value = "MV", Text ="Maldives"},
                new Country {Value = "ML", Text ="Mali"},
                new Country {Value = "MT", Text ="Malta"},
                new Country {Value = "MH", Text ="Marshall Islands"},
                new Country {Value = "MQ", Text ="Martinique (FR)"},
                new Country {Value = "MR", Text ="Mauritania"},
                new Country {Value = "MU", Text ="Mauritius"},
                new Country {Value = "MX", Text ="Mexico"},
                new Country {Value = "FM", Text ="Micronesia"},
                new Country {Value = "MD", Text ="Moldavia"},
                new Country {Value = "MC", Text ="Monaco"},
                new Country {Value = "MN", Text ="Mongolia"},
                new Country {Value = "MS", Text ="Montserrat"},
                new Country {Value = "MA", Text ="Morocco"},
                new Country {Value = "MZ", Text ="Mozambique"},
                new Country {Value = "MM", Text ="Myanmar (Burma)"},
                new Country {Value = "NA", Text ="Namibia"},
                new Country {Value = "NR", Text ="Nauru"},
                new Country {Value = "NP", Text ="Nepal"},
                new Country {Value = "AN", Text ="Netherland Antilles"},
                new Country {Value = "NL", Text ="Nederland"},
                new Country {Value = "NT", Text ="Neutral Zone"},
                new Country {Value = "NC", Text ="New Caledonia (FR)"},
                new Country {Value = "NZ", Text ="New Zealand"},
                new Country {Value = "NI", Text ="Nicaragua"},
                new Country {Value = "NE", Text ="Niger"},
                new Country {Value = "NG", Text ="Nigeria"},
                new Country {Value = "NU", Text ="Niue"},
                new Country {Value = "NF", Text ="Norfolk Island"},
                new Country {Value = "MP", Text ="Northern Mariana Islands"},
                new Country {Value = "NO", Text ="Norway"},
                new Country {Value = "OM", Text ="Oman"},
                new Country {Value = "PK", Text ="Pakistan"},
                new Country {Value = "PW", Text ="Palau"},
                new Country {Value = "PA", Text ="Panama"},
                new Country {Value = "PG", Text ="Papua New Guinea"},
                new Country {Value = "PY", Text ="Paraguay"},
                new Country {Value = "PE", Text ="Peru"},
                new Country {Value = "PH", Text ="Philippines"},
                new Country {Value = "PN", Text ="Pitcairn"},
                new Country {Value = "PL", Text ="Poland"},
                new Country {Value = "PF", Text ="Polynesia (FR)"},
                new Country {Value = "PT", Text ="Portugal"},
                new Country {Value = "PR", Text ="Puerto Rico (US)"},
                new Country {Value = "QA", Text ="Qatar"},
                new Country {Value = "RE", Text ="Reunion (FR)"},
                new Country {Value = "RO", Text ="Romania"},
                new Country {Value = "RU", Text ="Russian Federation"},
                new Country {Value = "RW", Text ="Rwanda"},
                new Country {Value = "SH", Text ="Saint  Helena"},
                new Country {Value = "PM", Text ="Saint  Pierre and Miquelon"},
                new Country {Value = "KN", Text ="Saint Kitts Nevis Anguilla"},
                new Country {Value = "LC", Text ="Saint Lucia"},
                new Country {Value = "VC", Text ="Saint Vincent and Grenadines"},
                new Country {Value = "WS", Text ="Samoa"},
                new Country {Value = "SM", Text ="San Marino"},
                new Country {Value = "ST", Text ="Sao Tome and Principe"},
                new Country {Value = "SA", Text ="Saudi Arabia"},
                new Country {Value = "SX", Text ="Sebia and Montenegro"},
                new Country {Value = "SN", Text ="Senegal"},
                new Country {Value = "SC", Text ="Seychelles"},
                new Country {Value = "SL", Text ="Sierra Leone"},
                new Country {Value = "SG", Text ="Singapore"},
                new Country {Value = "SK", Text ="Slovak Republic"},
                new Country {Value = "SI", Text ="Slovenia"},
                new Country {Value = "SB", Text ="Solomon Islands"},
                new Country {Value = "SO", Text ="Somalia"},
                new Country {Value = "ZA", Text ="South Africa"},
                new Country {Value = "GS", Text ="South Georgia"},
                new Country {Value = "SU", Text ="Soviet Union"},
                new Country {Value = "ES", Text ="España"},
                new Country {Value = "LK", Text ="Sri Lanka"},
                new Country {Value = "SD", Text ="Sudan"},
                new Country {Value = "SR", Text ="Suriname"},
                new Country {Value = "SJ", Text ="Svalbard and Jan Mayen Islands"},
                new Country {Value = "SZ", Text ="Swaziland"},
                new Country {Value = "SE", Text ="Sverige"},
                new Country {Value = "CH", Text ="Suisse"},
                new Country {Value = "SY", Text ="Syria"},
                new Country {Value = "TJ", Text ="Tadjikistan"},
                new Country {Value = "TW", Text ="Taiwan"},
                new Country {Value = "TZ", Text ="Tanzania"},
                new Country {Value = "TH", Text ="Thailand"},
                new Country {Value = "TG", Text ="Togo"},
                new Country {Value = "TK", Text ="Tokelau"},
                new Country {Value = "TO", Text ="Tonga"},
                new Country {Value = "TT", Text ="Trinidad and Tobago"},
                new Country {Value = "TN", Text ="Tunisia"},
                new Country {Value = "TR", Text ="Türkiye"},
                new Country {Value = "TM", Text ="Turkmenistan"},
                new Country {Value = "TC", Text ="Turks and Caicos Islands"},
                new Country {Value = "TV", Text ="Tuvalu"},
                new Country {Value = "UG", Text ="Uganda"},
                new Country {Value = "UA", Text ="Ukraine"},
                new Country {Value = "AE", Text ="United Arab Emirates"},
                new Country {Value = "UK", Text ="United Kingdom"},
                new Country {Value = "UY", Text ="Uruguay"},
                new Country {Value = "UM", Text ="US Minor outlying Islands"},
                new Country {Value = "UZ", Text ="Uzbekistan"},
                new Country {Value = "VU", Text ="Vanuatu"},
                new Country {Value = "VA", Text ="Vatican City State"},
                new Country {Value = "VE", Text ="Venezuela"},
                new Country {Value = "VN", Text ="Vietnam"},
                new Country {Value = "VG", Text ="Virgin Islands (British)"},
                new Country {Value = "VI", Text ="Virgin Islands (US)"},
                new Country {Value = "WF", Text ="Wallis and Futuna Islands"},
                new Country {Value = "WB", Text ="West Bank and Gaza"},
                new Country {Value = "EH", Text ="Western Sahara"},
                new Country {Value = "YE", Text ="Yemen"},
                new Country {Value = "YU", Text ="Yugoslavia"},
                new Country {Value = "ZR", Text ="Zaire"},
                new Country {Value = "ZM", Text ="Zambia"},
                new Country {Value = "ZW", Text ="Zimbabwe"}
            };
        }
    }
}
