using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.API.Migrations
{
    public partial class CountriesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Capital", "Flag", "Name", "NativeName", "NumericCode", "Region", "Subregion" },
                values: new object[,]
                {
                    { new Guid("e1ff7cfc-0707-4afe-8803-f8f8269c00b4"), "AF", "AFG", "Kabul", "https://restcountries.eu/data/afg.svg", "Afghanistan", "افغانستان", "004", "Asia", "Southern Asia" },
                    { new Guid("261b1c6a-51cb-48dc-adaa-877dd3f23d54"), "NC", "NCL", "Nouméa", "https://restcountries.eu/data/ncl.svg", "New Caledonia", "Nouvelle-Calédonie", "540", "Oceania", "Melanesia" },
                    { new Guid("0c68ee39-cb1a-4b21-9dc9-aa534c495ba0"), "NZ", "NZL", "Wellington", "https://restcountries.eu/data/nzl.svg", "New Zealand", "New Zealand", "554", "Oceania", "Australia and New Zealand" },
                    { new Guid("bfe525f0-91b1-4a0a-a441-06f575895df2"), "NI", "NIC", "Managua", "https://restcountries.eu/data/nic.svg", "Nicaragua", "Nicaragua", "558", "Americas", "Central America" },
                    { new Guid("d4280d9a-9c4f-4914-b0c0-d39e11a9afd3"), "NE", "NER", "Niamey", "https://restcountries.eu/data/ner.svg", "Niger", "Niger", "562", "Africa", "Western Africa" },
                    { new Guid("d3268ec0-b4b1-47cd-ae23-e6dc3c242f89"), "NG", "NGA", "Abuja", "https://restcountries.eu/data/nga.svg", "Nigeria", "Nigeria", "566", "Africa", "Western Africa" },
                    { new Guid("f0eb2f9e-2a06-4bc1-8281-fb68f49e9a95"), "NU", "NIU", "Alofi", "https://restcountries.eu/data/niu.svg", "Niue", "Niuē", "570", "Oceania", "Polynesia" },
                    { new Guid("2e7e08a8-0b61-461f-9235-b89cae8bff37"), "NF", "NFK", "Kingston", "https://restcountries.eu/data/nfk.svg", "Norfolk Island", "Norfolk Island", "574", "Oceania", "Australia and New Zealand" },
                    { new Guid("efbd47ed-f8b1-4430-a73b-a80d15812cc2"), "KP", "PRK", "Pyongyang", "https://restcountries.eu/data/prk.svg", "Korea (Democratic People's Republic of)", "북한", "408", "Asia", "Eastern Asia" },
                    { new Guid("f734a338-cc95-40dd-8d74-2207c043e3d7"), "MP", "MNP", "Saipan", "https://restcountries.eu/data/mnp.svg", "Northern Mariana Islands", "Northern Mariana Islands", "580", "Oceania", "Micronesia" },
                    { new Guid("cd935cd6-dcec-476b-98dc-65983d2537c4"), "NO", "NOR", "Oslo", "https://restcountries.eu/data/nor.svg", "Norway", "Norge", "578", "Europe", "Northern Europe" },
                    { new Guid("596b0985-466f-463b-ab5c-ed26a6865f4c"), "OM", "OMN", "Muscat", "https://restcountries.eu/data/omn.svg", "Oman", "عمان", "512", "Asia", "Western Asia" },
                    { new Guid("be3aa119-7a05-4027-b6c3-63cc189daaf6"), "PK", "PAK", "Islamabad", "https://restcountries.eu/data/pak.svg", "Pakistan", "Pakistan", "586", "Asia", "Southern Asia" },
                    { new Guid("0e04abd6-ae59-4577-af61-77ca07ce2c76"), "PW", "PLW", "Ngerulmud", "https://restcountries.eu/data/plw.svg", "Palau", "Palau", "585", "Oceania", "Micronesia" },
                    { new Guid("f0eeb88f-1889-43f3-ad33-16cf3b9ebe53"), "PS", "PSE", "Ramallah", "https://restcountries.eu/data/pse.svg", "Palestine, State of", "فلسطين", "275", "Asia", "Western Asia" },
                    { new Guid("33a56285-4e0b-4d12-8f66-980be9d12d8e"), "PA", "PAN", "Panama City", "https://restcountries.eu/data/pan.svg", "Panama", "Panamá", "591", "Americas", "Central America" },
                    { new Guid("2f361d19-fa2b-42e6-a7fe-f2a9bf387af3"), "PG", "PNG", "Port Moresby", "https://restcountries.eu/data/png.svg", "Papua New Guinea", "Papua Niugini", "598", "Oceania", "Melanesia" },
                    { new Guid("1df1ce19-c699-4c15-b085-9487022d431e"), "PY", "PRY", "Asunción", "https://restcountries.eu/data/pry.svg", "Paraguay", "Paraguay", "600", "Americas", "South America" },
                    { new Guid("1d1376ac-3fdc-4227-a3e7-6888cd05dfc2"), "PE", "PER", "Lima", "https://restcountries.eu/data/per.svg", "Peru", "Perú", "604", "Americas", "South America" },
                    { new Guid("0c5990cc-7e36-48bb-b27f-eab10c1f63a4"), "PH", "PHL", "Manila", "https://restcountries.eu/data/phl.svg", "Philippines", "Pilipinas", "608", "Asia", "South-Eastern Asia" },
                    { new Guid("dfbb3f4d-9e69-4c55-9b2d-c55545c6e986"), "PN", "PCN", "Adamstown", "https://restcountries.eu/data/pcn.svg", "Pitcairn", "Pitcairn Islands", "612", "Oceania", "Polynesia" },
                    { new Guid("f256d7df-2e5e-4bf2-9608-8f09e0ef30f4"), "PL", "POL", "Warsaw", "https://restcountries.eu/data/pol.svg", "Poland", "Polska", "616", "Europe", "Eastern Europe" },
                    { new Guid("b9bae87b-f0a0-4546-af01-534ac68387c5"), "PT", "PRT", "Lisbon", "https://restcountries.eu/data/prt.svg", "Portugal", "Portugal", "620", "Europe", "Southern Europe" },
                    { new Guid("7e5b08c7-65bb-4390-80fd-632755acbe21"), "PR", "PRI", "San Juan", "https://restcountries.eu/data/pri.svg", "Puerto Rico", "Puerto Rico", "630", "Americas", "Caribbean" },
                    { new Guid("43b94ca5-88f7-4c3c-afa6-370c9b6a9a87"), "QA", "QAT", "Doha", "https://restcountries.eu/data/qat.svg", "Qatar", "قطر", "634", "Asia", "Western Asia" },
                    { new Guid("6a66c807-df30-429e-b3bb-185be7d02f02"), "XK", "KOS", "Pristina", "https://restcountries.eu/data/kos.svg", "Republic of Kosovo", "Republika e Kosovës", null, "Europe", "Eastern Europe" },
                    { new Guid("378c7fbe-796e-43b3-95cf-a72b96df7332"), "RE", "REU", "Saint-Denis", "https://restcountries.eu/data/reu.svg", "Réunion", "La Réunion", "638", "Africa", "Eastern Africa" },
                    { new Guid("acc15534-be2b-4f16-83c3-148b4ed2611b"), "RO", "ROU", "Bucharest", "https://restcountries.eu/data/rou.svg", "Romania", "România", "642", "Europe", "Eastern Europe" },
                    { new Guid("82eeddf1-37a0-4a45-832c-acbe6bbe87ac"), "NL", "NLD", "Amsterdam", "https://restcountries.eu/data/nld.svg", "Netherlands", "Nederland", "528", "Europe", "Western Europe" },
                    { new Guid("6345c65a-4080-4974-9810-8a764172f926"), "RU", "RUS", "Moscow", "https://restcountries.eu/data/rus.svg", "Russian Federation", "Россия", "643", "Europe", "Eastern Europe" },
                    { new Guid("96977c85-7ba5-406a-aa43-e73e992c5055"), "NP", "NPL", "Kathmandu", "https://restcountries.eu/data/npl.svg", "Nepal", "नेपाल", "524", "Asia", "Southern Asia" },
                    { new Guid("6158a627-ba43-437c-b622-9f8398a814e7"), "NA", "NAM", "Windhoek", "https://restcountries.eu/data/nam.svg", "Namibia", "Namibia", "516", "Africa", "Southern Africa" },
                    { new Guid("42f69eb8-85d6-4691-80ae-644d5f966d17"), "LY", "LBY", "Tripoli", "https://restcountries.eu/data/lby.svg", "Libya", "‏ليبيا", "434", "Africa", "Northern Africa" },
                    { new Guid("c70a0fe5-ad96-4581-b78c-263724633c37"), "LI", "LIE", "Vaduz", "https://restcountries.eu/data/lie.svg", "Liechtenstein", "Liechtenstein", "438", "Europe", "Western Europe" },
                    { new Guid("9bd10c7b-8b2a-4da1-8505-699e64bc5c42"), "LT", "LTU", "Vilnius", "https://restcountries.eu/data/ltu.svg", "Lithuania", "Lietuva", "440", "Europe", "Northern Europe" },
                    { new Guid("8ad75e5d-9977-4ebe-9faa-8655647e8c29"), "LU", "LUX", "Luxembourg", "https://restcountries.eu/data/lux.svg", "Luxembourg", "Luxembourg", "442", "Europe", "Western Europe" },
                    { new Guid("2069700a-08e4-489c-b192-8472796ea1dd"), "MO", "MAC", "", "https://restcountries.eu/data/mac.svg", "Macao", "澳門", "446", "Asia", "Eastern Asia" },
                    { new Guid("a361d3cd-9188-4f75-844a-9830ab94fb3f"), "MK", "MKD", "Skopje", "https://restcountries.eu/data/mkd.svg", "Macedonia (the former Yugoslav Republic of)", "Македонија", "807", "Europe", "Southern Europe" },
                    { new Guid("9a9f1307-9b7f-48d1-900e-d7dce0b6dc7e"), "MG", "MDG", "Antananarivo", "https://restcountries.eu/data/mdg.svg", "Madagascar", "Madagasikara", "450", "Africa", "Eastern Africa" },
                    { new Guid("45c45b47-f422-4773-86f1-13338e4c4d1f"), "MW", "MWI", "Lilongwe", "https://restcountries.eu/data/mwi.svg", "Malawi", "Malawi", "454", "Africa", "Eastern Africa" },
                    { new Guid("0a3dbaa8-1e66-4cc7-81f1-91086978adbd"), "MY", "MYS", "Kuala Lumpur", "https://restcountries.eu/data/mys.svg", "Malaysia", "Malaysia", "458", "Asia", "South-Eastern Asia" },
                    { new Guid("6301e4db-b9ba-4b6c-bd51-f1fde9104e73"), "MV", "MDV", "Malé", "https://restcountries.eu/data/mdv.svg", "Maldives", "Maldives", "462", "Asia", "Southern Asia" },
                    { new Guid("799efaaa-e677-4ea1-9932-fc5ba9a5dbbc"), "ML", "MLI", "Bamako", "https://restcountries.eu/data/mli.svg", "Mali", "Mali", "466", "Africa", "Western Africa" },
                    { new Guid("6f938f1c-352d-41bf-b528-b9a15bcd75e9"), "MT", "MLT", "Valletta", "https://restcountries.eu/data/mlt.svg", "Malta", "Malta", "470", "Europe", "Southern Europe" },
                    { new Guid("fc738cef-a4d4-4e01-abb9-56a6d0410a03"), "MH", "MHL", "Majuro", "https://restcountries.eu/data/mhl.svg", "Marshall Islands", "M̧ajeļ", "584", "Oceania", "Micronesia" },
                    { new Guid("b0cef9bd-da4e-41ab-80f8-3503fd7f349d"), "MQ", "MTQ", "Fort-de-France", "https://restcountries.eu/data/mtq.svg", "Martinique", "Martinique", "474", "Americas", "Caribbean" },
                    { new Guid("1f577062-a5ef-4380-b150-b634b7b5d93b"), "MR", "MRT", "Nouakchott", "https://restcountries.eu/data/mrt.svg", "Mauritania", "موريتانيا", "478", "Africa", "Western Africa" },
                    { new Guid("6eb08cd8-aca8-4aa8-808f-d129fe6c207a"), "MU", "MUS", "Port Louis", "https://restcountries.eu/data/mus.svg", "Mauritius", "Maurice", "480", "Africa", "Eastern Africa" },
                    { new Guid("75f1cbe3-54cb-4749-bbd4-a6882dbb8e95"), "YT", "MYT", "Mamoudzou", "https://restcountries.eu/data/myt.svg", "Mayotte", "Mayotte", "175", "Africa", "Eastern Africa" },
                    { new Guid("8cca2c94-2134-4189-ab03-086a7fd82961"), "MX", "MEX", "Mexico City", "https://restcountries.eu/data/mex.svg", "Mexico", "México", "484", "Americas", "Central America" },
                    { new Guid("9b7209d2-c09c-4034-ba64-83716a1b962a"), "FM", "FSM", "Palikir", "https://restcountries.eu/data/fsm.svg", "Micronesia (Federated States of)", "Micronesia", "583", "Oceania", "Micronesia" },
                    { new Guid("a27f0a23-de64-4159-977f-00e9a91a430f"), "MD", "MDA", "Chișinău", "https://restcountries.eu/data/mda.svg", "Moldova (Republic of)", "Moldova", "498", "Europe", "Eastern Europe" },
                    { new Guid("e3cb2fd0-190a-4d7f-bd5c-761d88d50f89"), "MC", "MCO", "Monaco", "https://restcountries.eu/data/mco.svg", "Monaco", "Monaco", "492", "Europe", "Western Europe" },
                    { new Guid("ab8c3196-e2d0-41d1-8ad9-8e23cb9cae82"), "MN", "MNG", "Ulan Bator", "https://restcountries.eu/data/mng.svg", "Mongolia", "Монгол улс", "496", "Asia", "Eastern Asia" },
                    { new Guid("ad2736d0-6d85-47c1-8879-c0bd5db7962f"), "ME", "MNE", "Podgorica", "https://restcountries.eu/data/mne.svg", "Montenegro", "Црна Гора", "499", "Europe", "Southern Europe" },
                    { new Guid("2a31d646-8858-4b12-8cd6-e49b81fe7371"), "MS", "MSR", "Plymouth", "https://restcountries.eu/data/msr.svg", "Montserrat", "Montserrat", "500", "Americas", "Caribbean" },
                    { new Guid("6137af7e-01d0-4a0c-90cf-f80c68f66383"), "MA", "MAR", "Rabat", "https://restcountries.eu/data/mar.svg", "Morocco", "المغرب", "504", "Africa", "Northern Africa" },
                    { new Guid("f40fdd03-3b0e-4bc4-838e-a61537e3fcf3"), "MZ", "MOZ", "Maputo", "https://restcountries.eu/data/moz.svg", "Mozambique", "Moçambique", "508", "Africa", "Eastern Africa" },
                    { new Guid("a268dab4-ef64-425a-a40e-20f2dbafe074"), "MM", "MMR", "Naypyidaw", "https://restcountries.eu/data/mmr.svg", "Myanmar", "Myanma", "104", "Asia", "South-Eastern Asia" },
                    { new Guid("662b86f1-081b-4ddc-817e-36eb2ca2be09"), "NR", "NRU", "Yaren", "https://restcountries.eu/data/nru.svg", "Nauru", "Nauru", "520", "Oceania", "Micronesia" },
                    { new Guid("0937c609-970e-4543-b033-cc8db6ed2102"), "RW", "RWA", "Kigali", "https://restcountries.eu/data/rwa.svg", "Rwanda", "Rwanda", "646", "Africa", "Eastern Africa" },
                    { new Guid("d922ae67-11b3-4fae-a79d-ddc0216b347d"), "BL", "BLM", "Gustavia", "https://restcountries.eu/data/blm.svg", "Saint Barthélemy", "Saint-Barthélemy", "652", "Americas", "Caribbean" },
                    { new Guid("9c1ac0e0-1728-48db-930a-672c381e6fbd"), "SH", "SHN", "Jamestown", "https://restcountries.eu/data/shn.svg", "Saint Helena, Ascension and Tristan da Cunha", "Saint Helena", "654", "Africa", "Western Africa" },
                    { new Guid("8dbd247f-ee17-43e4-98e3-153eb3c84d50"), "TW", "TWN", "Taipei", "https://restcountries.eu/data/twn.svg", "Taiwan", "臺灣", "158", "Asia", "Eastern Asia" },
                    { new Guid("812e2099-92c7-4e66-8c70-d7845065676a"), "TJ", "TJK", "Dushanbe", "https://restcountries.eu/data/tjk.svg", "Tajikistan", "Тоҷикистон", "762", "Asia", "Central Asia" },
                    { new Guid("194ddb43-4e98-48d0-8a12-d12c678cadff"), "TZ", "TZA", "Dodoma", "https://restcountries.eu/data/tza.svg", "Tanzania, United Republic of", "Tanzania", "834", "Africa", "Eastern Africa" },
                    { new Guid("d708953d-8585-4722-8ce3-b20dd17861b3"), "TH", "THA", "Bangkok", "https://restcountries.eu/data/tha.svg", "Thailand", "ประเทศไทย", "764", "Asia", "South-Eastern Asia" },
                    { new Guid("23794c29-09ca-4ab1-a614-9c6f8f7aaad8"), "TL", "TLS", "Dili", "https://restcountries.eu/data/tls.svg", "Timor-Leste", "Timor-Leste", "626", "Asia", "South-Eastern Asia" },
                    { new Guid("998f0d23-ba73-490f-baa5-752c3b850ce6"), "TG", "TGO", "Lomé", "https://restcountries.eu/data/tgo.svg", "Togo", "Togo", "768", "Africa", "Western Africa" },
                    { new Guid("3a22fd01-f759-4026-a869-78779c4bab40"), "TK", "TKL", "Fakaofo", "https://restcountries.eu/data/tkl.svg", "Tokelau", "Tokelau", "772", "Oceania", "Polynesia" },
                    { new Guid("269b3f90-e299-4edc-80cf-e0a3f8702594"), "TO", "TON", "Nuku'alofa", "https://restcountries.eu/data/ton.svg", "Tonga", "Tonga", "776", "Oceania", "Polynesia" },
                    { new Guid("5a71266f-68ee-4bd8-b15a-a074b5f40835"), "TT", "TTO", "Port of Spain", "https://restcountries.eu/data/tto.svg", "Trinidad and Tobago", "Trinidad and Tobago", "780", "Americas", "Caribbean" },
                    { new Guid("2be7db02-eb67-49eb-9ca3-b1999c297e5f"), "TN", "TUN", "Tunis", "https://restcountries.eu/data/tun.svg", "Tunisia", "تونس", "788", "Africa", "Northern Africa" },
                    { new Guid("d2c52f4c-c9dc-4868-afe0-cdb7f4bfbe51"), "TR", "TUR", "Ankara", "https://restcountries.eu/data/tur.svg", "Turkey", "Türkiye", "792", "Asia", "Western Asia" },
                    { new Guid("3ce77728-a64e-471c-a5e5-e0063a0f204b"), "TM", "TKM", "Ashgabat", "https://restcountries.eu/data/tkm.svg", "Turkmenistan", "Türkmenistan", "795", "Asia", "Central Asia" },
                    { new Guid("5bf88b53-3eda-4ee0-bb17-aa32c5adb914"), "TC", "TCA", "Cockburn Town", "https://restcountries.eu/data/tca.svg", "Turks and Caicos Islands", "Turks and Caicos Islands", "796", "Americas", "Caribbean" },
                    { new Guid("abbd4c43-24ee-48f0-885f-65b4d8e6676f"), "TV", "TUV", "Funafuti", "https://restcountries.eu/data/tuv.svg", "Tuvalu", "Tuvalu", "798", "Oceania", "Polynesia" },
                    { new Guid("34faab92-2def-4910-8579-4ae5a5661e47"), "UG", "UGA", "Kampala", "https://restcountries.eu/data/uga.svg", "Uganda", "Uganda", "800", "Africa", "Eastern Africa" },
                    { new Guid("da6b6015-71b3-48a0-bb5a-54522b4df254"), "UA", "UKR", "Kiev", "https://restcountries.eu/data/ukr.svg", "Ukraine", "Україна", "804", "Europe", "Eastern Europe" },
                    { new Guid("7696272c-c5a5-422b-8d17-2e25ff05c2ae"), "AE", "ARE", "Abu Dhabi", "https://restcountries.eu/data/are.svg", "United Arab Emirates", "دولة الإمارات العربية المتحدة", "784", "Asia", "Western Asia" },
                    { new Guid("c2348090-0a82-4dc7-97fd-771f44323aef"), "GB", "GBR", "London", "https://restcountries.eu/data/gbr.svg", "United Kingdom of Great Britain and Northern Ireland", "United Kingdom", "826", "Europe", "Northern Europe" },
                    { new Guid("c2b9a6ce-0265-44c2-9a60-50edd425e968"), "US", "USA", "Washington, D.C.", "https://restcountries.eu/data/usa.svg", "United States of America", "United States", "840", "Americas", "Northern America" },
                    { new Guid("d9f2c0ef-53a4-4a67-8026-d7ba0f9e20af"), "UY", "URY", "Montevideo", "https://restcountries.eu/data/ury.svg", "Uruguay", "Uruguay", "858", "Americas", "South America" },
                    { new Guid("dcdb75d5-d057-43c6-998f-592eaf09907d"), "UZ", "UZB", "Tashkent", "https://restcountries.eu/data/uzb.svg", "Uzbekistan", "O‘zbekiston", "860", "Asia", "Central Asia" },
                    { new Guid("4d688aff-9482-4157-949c-0adbff277083"), "VU", "VUT", "Port Vila", "https://restcountries.eu/data/vut.svg", "Vanuatu", "Vanuatu", "548", "Oceania", "Melanesia" },
                    { new Guid("b78e09f0-44d4-428a-9534-ab819148ce48"), "VE", "VEN", "Caracas", "https://restcountries.eu/data/ven.svg", "Venezuela (Bolivarian Republic of)", "Venezuela", "862", "Americas", "South America" },
                    { new Guid("cb1500e7-750b-4b7a-9c77-bcad610966b8"), "VN", "VNM", "Hanoi", "https://restcountries.eu/data/vnm.svg", "Viet Nam", "Việt Nam", "704", "Asia", "South-Eastern Asia" },
                    { new Guid("a5195450-054f-4357-a983-affd2827d14d"), "WF", "WLF", "Mata-Utu", "https://restcountries.eu/data/wlf.svg", "Wallis and Futuna", "Wallis et Futuna", "876", "Oceania", "Polynesia" },
                    { new Guid("572aec11-46c1-4666-9cba-db8df5daae26"), "EH", "ESH", "El Aaiún", "https://restcountries.eu/data/esh.svg", "Western Sahara", "الصحراء الغربية", "732", "Africa", "Northern Africa" },
                    { new Guid("51f7ab3a-3b3c-4a5e-a6e3-12d3f6ddfaee"), "YE", "YEM", "Sana'a", "https://restcountries.eu/data/yem.svg", "Yemen", "اليَمَن", "887", "Asia", "Western Asia" },
                    { new Guid("fb708ba4-4179-4c03-8e69-2dc8d9ee2887"), "SY", "SYR", "Damascus", "https://restcountries.eu/data/syr.svg", "Syrian Arab Republic", "سوريا", "760", "Asia", "Western Asia" },
                    { new Guid("a8b6a4df-8fef-4a17-b770-33c22b74d1d7"), "CH", "CHE", "Bern", "https://restcountries.eu/data/che.svg", "Switzerland", "Schweiz", "756", "Europe", "Western Europe" },
                    { new Guid("dd0f6ae1-6f62-4357-b8f2-533471617bdf"), "SE", "SWE", "Stockholm", "https://restcountries.eu/data/swe.svg", "Sweden", "Sverige", "752", "Europe", "Northern Europe" },
                    { new Guid("809eb15d-15d5-43ff-a4fa-ebdad280c4ab"), "SZ", "SWZ", "Lobamba", "https://restcountries.eu/data/swz.svg", "Swaziland", "Swaziland", "748", "Africa", "Southern Africa" },
                    { new Guid("9f1bd552-3022-4371-ab1c-50d78698de4a"), "KN", "KNA", "Basseterre", "https://restcountries.eu/data/kna.svg", "Saint Kitts and Nevis", "Saint Kitts and Nevis", "659", "Americas", "Caribbean" },
                    { new Guid("98868a63-d2a3-41c9-aaa6-6a35c799c692"), "LC", "LCA", "Castries", "https://restcountries.eu/data/lca.svg", "Saint Lucia", "Saint Lucia", "662", "Americas", "Caribbean" },
                    { new Guid("1b098170-2a55-4bd0-bf53-1410fd28d3ca"), "MF", "MAF", "Marigot", "https://restcountries.eu/data/maf.svg", "Saint Martin (French part)", "Saint-Martin", "663", "Americas", "Caribbean" },
                    { new Guid("b09968f9-af64-49a2-b731-84976867e7dc"), "PM", "SPM", "Saint-Pierre", "https://restcountries.eu/data/spm.svg", "Saint Pierre and Miquelon", "Saint-Pierre-et-Miquelon", "666", "Americas", "Northern America" },
                    { new Guid("1732cbf2-d4a3-4fc4-90b6-fe53f46544de"), "VC", "VCT", "Kingstown", "https://restcountries.eu/data/vct.svg", "Saint Vincent and the Grenadines", "Saint Vincent and the Grenadines", "670", "Americas", "Caribbean" },
                    { new Guid("87ef4e44-7145-4e76-a210-197c60adf6d5"), "WS", "WSM", "Apia", "https://restcountries.eu/data/wsm.svg", "Samoa", "Samoa", "882", "Oceania", "Polynesia" },
                    { new Guid("55ee3de8-6921-4fe4-a07a-d25a4d9938bf"), "SM", "SMR", "City of San Marino", "https://restcountries.eu/data/smr.svg", "San Marino", "San Marino", "674", "Europe", "Southern Europe" },
                    { new Guid("32f29e4a-ac91-42ff-9089-dd94445f0823"), "ST", "STP", "São Tomé", "https://restcountries.eu/data/stp.svg", "Sao Tome and Principe", "São Tomé e Príncipe", "678", "Africa", "Middle Africa" },
                    { new Guid("e9bc7071-66dd-48c4-a94a-cca877851698"), "SA", "SAU", "Riyadh", "https://restcountries.eu/data/sau.svg", "Saudi Arabia", "العربية السعودية", "682", "Asia", "Western Asia" },
                    { new Guid("76ba549b-0fe7-4694-99d5-6366f92cbaa6"), "SN", "SEN", "Dakar", "https://restcountries.eu/data/sen.svg", "Senegal", "Sénégal", "686", "Africa", "Western Africa" },
                    { new Guid("babc62d0-cafa-4a3e-a693-8921368eabf9"), "RS", "SRB", "Belgrade", "https://restcountries.eu/data/srb.svg", "Serbia", "Србија", "688", "Europe", "Southern Europe" },
                    { new Guid("c3c9c5d7-8643-4ee9-898d-500a73db5f25"), "SC", "SYC", "Victoria", "https://restcountries.eu/data/syc.svg", "Seychelles", "Seychelles", "690", "Africa", "Eastern Africa" },
                    { new Guid("23f142b9-4adf-4558-8376-d115113113f6"), "SL", "SLE", "Freetown", "https://restcountries.eu/data/sle.svg", "Sierra Leone", "Sierra Leone", "694", "Africa", "Western Africa" },
                    { new Guid("8f8e4f3a-2063-41d3-8d33-e9b1052316dd"), "LR", "LBR", "Monrovia", "https://restcountries.eu/data/lbr.svg", "Liberia", "Liberia", "430", "Africa", "Western Africa" },
                    { new Guid("81b97db7-80f9-4664-b550-998bb555ce90"), "SG", "SGP", "Singapore", "https://restcountries.eu/data/sgp.svg", "Singapore", "Singapore", "702", "Asia", "South-Eastern Asia" },
                    { new Guid("e662f2a3-474e-468f-bef3-4e3cb010e1f7"), "SK", "SVK", "Bratislava", "https://restcountries.eu/data/svk.svg", "Slovakia", "Slovensko", "703", "Europe", "Eastern Europe" },
                    { new Guid("f4b34ec3-7f2d-48e0-af76-70082ed24ad4"), "SI", "SVN", "Ljubljana", "https://restcountries.eu/data/svn.svg", "Slovenia", "Slovenija", "705", "Europe", "Southern Europe" },
                    { new Guid("aee53095-af3e-45c9-b7c7-bde4f6da4caf"), "SB", "SLB", "Honiara", "https://restcountries.eu/data/slb.svg", "Solomon Islands", "Solomon Islands", "090", "Oceania", "Melanesia" },
                    { new Guid("ede348cd-5f0b-4644-b2b4-7872a3c995d0"), "SO", "SOM", "Mogadishu", "https://restcountries.eu/data/som.svg", "Somalia", "Soomaaliya", "706", "Africa", "Eastern Africa" },
                    { new Guid("232da08e-b50f-4977-9fa0-f51d9cdbafe6"), "ZA", "ZAF", "Pretoria", "https://restcountries.eu/data/zaf.svg", "South Africa", "South Africa", "710", "Africa", "Southern Africa" },
                    { new Guid("5ce62dd5-6aac-4d87-8cb8-03a7a4363892"), "GS", "SGS", "King Edward Point", "https://restcountries.eu/data/sgs.svg", "South Georgia and the South Sandwich Islands", "South Georgia", "239", "Americas", "South America" },
                    { new Guid("3e75eeaa-3ce6-4238-8c70-a7eb7fa26104"), "KR", "KOR", "Seoul", "https://restcountries.eu/data/kor.svg", "Korea (Republic of)", "대한민국", "410", "Asia", "Eastern Asia" },
                    { new Guid("73449259-528f-4ae0-b451-08c0b4e8c645"), "SS", "SSD", "Juba", "https://restcountries.eu/data/ssd.svg", "South Sudan", "South Sudan", "728", "Africa", "Middle Africa" },
                    { new Guid("12d2dfc5-155f-4fdf-9fdf-482feea3fe3b"), "ES", "ESP", "Madrid", "https://restcountries.eu/data/esp.svg", "Spain", "España", "724", "Europe", "Southern Europe" },
                    { new Guid("308ba0f4-ba59-4d87-85a5-e3eaa60d3cd3"), "LK", "LKA", "Colombo", "https://restcountries.eu/data/lka.svg", "Sri Lanka", "śrī laṃkāva", "144", "Asia", "Southern Asia" },
                    { new Guid("3bfb8810-63c7-42cf-b36b-f9cbd4cf8f82"), "SD", "SDN", "Khartoum", "https://restcountries.eu/data/sdn.svg", "Sudan", "السودان", "729", "Africa", "Northern Africa" },
                    { new Guid("78bc2f5f-552b-464f-8a7b-0b640f21496a"), "SR", "SUR", "Paramaribo", "https://restcountries.eu/data/sur.svg", "Suriname", "Suriname", "740", "Americas", "South America" },
                    { new Guid("6d43a0e8-df08-4304-ac2b-eaeb3c37c7a7"), "SJ", "SJM", "Longyearbyen", "https://restcountries.eu/data/sjm.svg", "Svalbard and Jan Mayen", "Svalbard og Jan Mayen", "744", "Europe", "Northern Europe" },
                    { new Guid("315769ce-ca7c-4352-9a0e-80ce76beaa83"), "SX", "SXM", "Philipsburg", "https://restcountries.eu/data/sxm.svg", "Sint Maarten (Dutch part)", "Sint Maarten", "534", "Americas", "Caribbean" },
                    { new Guid("f800ac1f-ea53-4d12-b25b-a3cbbff8f6b0"), "LS", "LSO", "Maseru", "https://restcountries.eu/data/lso.svg", "Lesotho", "Lesotho", "426", "Africa", "Southern Africa" },
                    { new Guid("fc6460e0-84cf-467f-aeb1-3d546bfd7613"), "LB", "LBN", "Beirut", "https://restcountries.eu/data/lbn.svg", "Lebanon", "لبنان", "422", "Asia", "Western Asia" },
                    { new Guid("670539f3-585f-4e30-a13e-9bd99ff6ef1b"), "LV", "LVA", "Riga", "https://restcountries.eu/data/lva.svg", "Latvia", "Latvija", "428", "Europe", "Northern Europe" },
                    { new Guid("8008ffdd-e002-4936-8235-b87c7f807621"), "UM", "UMI", "", "https://restcountries.eu/data/umi.svg", "United States Minor Outlying Islands", "United States Minor Outlying Islands", "581", "Americas", "Northern America" },
                    { new Guid("a2d0a55b-8114-42e0-a789-add1b8e09f7d"), "VG", "VGB", "Road Town", "https://restcountries.eu/data/vgb.svg", "Virgin Islands (British)", "British Virgin Islands", "092", "Americas", "Caribbean" },
                    { new Guid("96964d8a-a599-4b6f-9524-bd4e7115cb01"), "VI", "VIR", "Charlotte Amalie", "https://restcountries.eu/data/vir.svg", "Virgin Islands (U.S.)", "Virgin Islands of the United States", "850", "Americas", "Caribbean" },
                    { new Guid("274bf5d1-8c98-4e98-9ace-277a6cfaee14"), "BN", "BRN", "Bandar Seri Begawan", "https://restcountries.eu/data/brn.svg", "Brunei Darussalam", "Negara Brunei Darussalam", "096", "Asia", "South-Eastern Asia" },
                    { new Guid("cc547fd4-cd82-4a5e-9559-f6d58e19651b"), "BG", "BGR", "Sofia", "https://restcountries.eu/data/bgr.svg", "Bulgaria", "България", "100", "Europe", "Eastern Europe" },
                    { new Guid("01d540a9-33e3-48ad-b275-4c33e8caf7e2"), "BF", "BFA", "Ouagadougou", "https://restcountries.eu/data/bfa.svg", "Burkina Faso", "Burkina Faso", "854", "Africa", "Western Africa" },
                    { new Guid("f31bc5dd-68c3-4b5b-b8e9-00472e09c05f"), "BI", "BDI", "Bujumbura", "https://restcountries.eu/data/bdi.svg", "Burundi", "Burundi", "108", "Africa", "Eastern Africa" },
                    { new Guid("a78ccb70-5a5f-4ce1-a0af-95f1c354e42c"), "KH", "KHM", "Phnom Penh", "https://restcountries.eu/data/khm.svg", "Cambodia", "Kâmpŭchéa", "116", "Asia", "South-Eastern Asia" },
                    { new Guid("846a9aba-8e31-4c2f-8f92-5bae500c5184"), "CM", "CMR", "Yaoundé", "https://restcountries.eu/data/cmr.svg", "Cameroon", "Cameroon", "120", "Africa", "Middle Africa" },
                    { new Guid("b4bdb6ab-f87d-4ec6-a309-460a8eb69b6f"), "CA", "CAN", "Ottawa", "https://restcountries.eu/data/can.svg", "Canada", "Canada", "124", "Americas", "Northern America" },
                    { new Guid("805cd28c-83ca-447d-a29d-587f0cb3847d"), "CV", "CPV", "Praia", "https://restcountries.eu/data/cpv.svg", "Cabo Verde", "Cabo Verde", "132", "Africa", "Western Africa" },
                    { new Guid("11ac58f3-5860-4072-8785-a069ea479dfd"), "KY", "CYM", "George Town", "https://restcountries.eu/data/cym.svg", "Cayman Islands", "Cayman Islands", "136", "Americas", "Caribbean" },
                    { new Guid("17328f9d-634f-4ac1-8e40-b1cc89a86f5d"), "CF", "CAF", "Bangui", "https://restcountries.eu/data/caf.svg", "Central African Republic", "Ködörösêse tî Bêafrîka", "140", "Africa", "Middle Africa" },
                    { new Guid("214db839-ae08-4383-b2f4-d533a5f54eb7"), "TD", "TCD", "N'Djamena", "https://restcountries.eu/data/tcd.svg", "Chad", "Tchad", "148", "Africa", "Middle Africa" },
                    { new Guid("6c0aa0db-a0cb-477a-9355-8f200389bd2b"), "CL", "CHL", "Santiago", "https://restcountries.eu/data/chl.svg", "Chile", "Chile", "152", "Americas", "South America" },
                    { new Guid("0d58b611-a200-4f13-af15-e6a9fe9505a0"), "CN", "CHN", "Beijing", "https://restcountries.eu/data/chn.svg", "China", "中国", "156", "Asia", "Eastern Asia" },
                    { new Guid("6f5962b4-4aa9-4990-b017-e053fd5da063"), "CX", "CXR", "Flying Fish Cove", "https://restcountries.eu/data/cxr.svg", "Christmas Island", "Christmas Island", "162", "Oceania", "Australia and New Zealand" },
                    { new Guid("2ef8a6d1-8ab6-4b91-810a-b8767039a174"), "CC", "CCK", "West Island", "https://restcountries.eu/data/cck.svg", "Cocos (Keeling) Islands", "Cocos (Keeling) Islands", "166", "Oceania", "Australia and New Zealand" },
                    { new Guid("afcae147-f67c-4542-b96c-3f85d646e677"), "CO", "COL", "Bogotá", "https://restcountries.eu/data/col.svg", "Colombia", "Colombia", "170", "Americas", "South America" },
                    { new Guid("49133169-6b4b-4ee8-af86-9ab94546e230"), "KM", "COM", "Moroni", "https://restcountries.eu/data/com.svg", "Comoros", "Komori", "174", "Africa", "Eastern Africa" },
                    { new Guid("ad526a30-748e-46c8-93b5-50543cfbdeba"), "CG", "COG", "Brazzaville", "https://restcountries.eu/data/cog.svg", "Congo", "République du Congo", "178", "Africa", "Middle Africa" },
                    { new Guid("c9e4ab7f-990a-4dc9-8a9a-f8d804958ff4"), "CD", "COD", "Kinshasa", "https://restcountries.eu/data/cod.svg", "Congo (Democratic Republic of the)", "République démocratique du Congo", "180", "Africa", "Middle Africa" },
                    { new Guid("4015cc1c-c933-4a4b-a046-23ad348f5b3b"), "CK", "COK", "Avarua", "https://restcountries.eu/data/cok.svg", "Cook Islands", "Cook Islands", "184", "Oceania", "Polynesia" },
                    { new Guid("a9b6eac4-43d1-4711-9b38-636455739b1e"), "CR", "CRI", "San José", "https://restcountries.eu/data/cri.svg", "Costa Rica", "Costa Rica", "188", "Americas", "Central America" },
                    { new Guid("132088b4-6265-4348-b4bc-0400e6bae42a"), "HR", "HRV", "Zagreb", "https://restcountries.eu/data/hrv.svg", "Croatia", "Hrvatska", "191", "Europe", "Southern Europe" },
                    { new Guid("ed927eb3-fedc-4a15-8345-d34ac145ca6a"), "CU", "CUB", "Havana", "https://restcountries.eu/data/cub.svg", "Cuba", "Cuba", "192", "Americas", "Caribbean" },
                    { new Guid("48938750-d3aa-44df-9c71-df109c9f7dbf"), "CW", "CUW", "Willemstad", "https://restcountries.eu/data/cuw.svg", "Curaçao", "Curaçao", "531", "Americas", "Caribbean" },
                    { new Guid("a290bf93-e241-4368-8a5f-54e45109bf93"), "IO", "IOT", "Diego Garcia", "https://restcountries.eu/data/iot.svg", "British Indian Ocean Territory", "British Indian Ocean Territory", "086", "Africa", "Eastern Africa" },
                    { new Guid("9ba1aff6-367f-4cd7-97df-4ea9f342f892"), "BR", "BRA", "Brasília", "https://restcountries.eu/data/bra.svg", "Brazil", "Brasil", "076", "Americas", "South America" },
                    { new Guid("6b071d25-3553-4b1c-a3f4-3962010ac25f"), "BV", "BVT", "", "https://restcountries.eu/data/bvt.svg", "Bouvet Island", "Bouvetøya", "074", "", "" },
                    { new Guid("afb0a7f9-5a2f-4910-b7c3-32e6b3e4a9a4"), "BW", "BWA", "Gaborone", "https://restcountries.eu/data/bwa.svg", "Botswana", "Botswana", "072", "Africa", "Southern Africa" },
                    { new Guid("a15cd9d6-433d-4f6d-9765-83d2fc300a43"), "AX", "ALA", "Mariehamn", "https://restcountries.eu/data/ala.svg", "Åland Islands", "Åland", "248", "Europe", "Northern Europe" },
                    { new Guid("81500654-7131-4ccd-a529-a6fc951c8a44"), "AL", "ALB", "Tirana", "https://restcountries.eu/data/alb.svg", "Albania", "Shqipëria", "008", "Europe", "Southern Europe" },
                    { new Guid("aacafac3-fffe-4c5f-a611-b4ac758a070c"), "DZ", "DZA", "Algiers", "https://restcountries.eu/data/dza.svg", "Algeria", "الجزائر", "012", "Africa", "Northern Africa" },
                    { new Guid("4505325e-a5b8-4998-bfef-fd369ecdf225"), "AS", "ASM", "Pago Pago", "https://restcountries.eu/data/asm.svg", "American Samoa", "American Samoa", "016", "Oceania", "Polynesia" },
                    { new Guid("ac9fdaf1-f159-49eb-9ef1-7704dcd7035a"), "AD", "AND", "Andorra la Vella", "https://restcountries.eu/data/and.svg", "Andorra", "Andorra", "020", "Europe", "Southern Europe" },
                    { new Guid("7db8d084-1055-4602-be3e-aaf04d4b442a"), "AO", "AGO", "Luanda", "https://restcountries.eu/data/ago.svg", "Angola", "Angola", "024", "Africa", "Middle Africa" },
                    { new Guid("2c595956-83f1-41f9-ba9b-e70fe7cb1a4c"), "AI", "AIA", "The Valley", "https://restcountries.eu/data/aia.svg", "Anguilla", "Anguilla", "660", "Americas", "Caribbean" },
                    { new Guid("fac6bb07-f33c-4b2d-85e8-cc20c9893d7f"), "AQ", "ATA", "", "https://restcountries.eu/data/ata.svg", "Antarctica", "Antarctica", "010", "Polar", "" },
                    { new Guid("e91bb661-9db2-44df-90c1-462fe6f4edeb"), "AG", "ATG", "Saint John's", "https://restcountries.eu/data/atg.svg", "Antigua and Barbuda", "Antigua and Barbuda", "028", "Americas", "Caribbean" },
                    { new Guid("e7b68d71-4ee9-4f13-8141-da800eeb5d77"), "AR", "ARG", "Buenos Aires", "https://restcountries.eu/data/arg.svg", "Argentina", "Argentina", "032", "Americas", "South America" },
                    { new Guid("9104bd7e-8271-4fe1-bb2c-2c6b4d53ce7e"), "AM", "ARM", "Yerevan", "https://restcountries.eu/data/arm.svg", "Armenia", "Հայաստան", "051", "Asia", "Western Asia" },
                    { new Guid("70e53a82-5b2a-4bb2-964e-3531faa8b64a"), "AW", "ABW", "Oranjestad", "https://restcountries.eu/data/abw.svg", "Aruba", "Aruba", "533", "Americas", "Caribbean" },
                    { new Guid("71c05ac1-d81b-44b0-a45d-0c86205417d7"), "AU", "AUS", "Canberra", "https://restcountries.eu/data/aus.svg", "Australia", "Australia", "036", "Oceania", "Australia and New Zealand" },
                    { new Guid("fc8053b8-29d6-4284-ba29-504e7c3ba032"), "CY", "CYP", "Nicosia", "https://restcountries.eu/data/cyp.svg", "Cyprus", "Κύπρος", "196", "Europe", "Southern Europe" },
                    { new Guid("7cf0a2f9-bf64-4902-a9d1-9924fdbe31c7"), "AT", "AUT", "Vienna", "https://restcountries.eu/data/aut.svg", "Austria", "Österreich", "040", "Europe", "Western Europe" },
                    { new Guid("63901dc7-1c31-4d6d-8926-1e863341184b"), "BS", "BHS", "Nassau", "https://restcountries.eu/data/bhs.svg", "Bahamas", "Bahamas", "044", "Americas", "Caribbean" },
                    { new Guid("baa49333-b522-48b3-834c-88209dfbb5ea"), "BH", "BHR", "Manama", "https://restcountries.eu/data/bhr.svg", "Bahrain", "‏البحرين", "048", "Asia", "Western Asia" },
                    { new Guid("5c83933a-145b-4b3d-adc8-fd7d26a1bc1d"), "BD", "BGD", "Dhaka", "https://restcountries.eu/data/bgd.svg", "Bangladesh", "Bangladesh", "050", "Asia", "Southern Asia" },
                    { new Guid("7c636f92-f0a3-4227-aaec-362a5fa94635"), "BB", "BRB", "Bridgetown", "https://restcountries.eu/data/brb.svg", "Barbados", "Barbados", "052", "Americas", "Caribbean" },
                    { new Guid("94dbfa6e-af78-40e8-a0f7-16223ab755a8"), "BY", "BLR", "Minsk", "https://restcountries.eu/data/blr.svg", "Belarus", "Белару́сь", "112", "Europe", "Eastern Europe" },
                    { new Guid("f28fe7f9-52da-46db-85b0-c343cc7b5835"), "BE", "BEL", "Brussels", "https://restcountries.eu/data/bel.svg", "Belgium", "België", "056", "Europe", "Western Europe" },
                    { new Guid("86c97b17-95a1-494a-9285-9a6cc5a298f5"), "BZ", "BLZ", "Belmopan", "https://restcountries.eu/data/blz.svg", "Belize", "Belize", "084", "Americas", "Central America" },
                    { new Guid("10bbd032-59c1-411f-bb45-a652822cc77d"), "BJ", "BEN", "Porto-Novo", "https://restcountries.eu/data/ben.svg", "Benin", "Bénin", "204", "Africa", "Western Africa" },
                    { new Guid("7ba8bee1-c39e-4c8d-8d3c-ad067bbbc64e"), "BM", "BMU", "Hamilton", "https://restcountries.eu/data/bmu.svg", "Bermuda", "Bermuda", "060", "Americas", "Northern America" },
                    { new Guid("d25d242d-b93c-4460-b640-47b658c340c8"), "BT", "BTN", "Thimphu", "https://restcountries.eu/data/btn.svg", "Bhutan", "ʼbrug-yul", "064", "Asia", "Southern Asia" },
                    { new Guid("74885c5f-8c8f-4044-9214-86ecde1685c5"), "BO", "BOL", "Sucre", "https://restcountries.eu/data/bol.svg", "Bolivia (Plurinational State of)", "Bolivia", "068", "Americas", "South America" },
                    { new Guid("204b318b-18f3-44cb-96d5-6a67951bef85"), "BQ", "BES", "Kralendijk", "https://restcountries.eu/data/bes.svg", "Bonaire, Sint Eustatius and Saba", "Bonaire", "535", "Americas", "Caribbean" },
                    { new Guid("ed70ce7c-383f-4436-b1b0-312033fa7e54"), "BA", "BIH", "Sarajevo", "https://restcountries.eu/data/bih.svg", "Bosnia and Herzegovina", "Bosna i Hercegovina", "070", "Europe", "Southern Europe" },
                    { new Guid("7701eac7-4c23-45ce-9787-bf405a62174e"), "AZ", "AZE", "Baku", "https://restcountries.eu/data/aze.svg", "Azerbaijan", "Azərbaycan", "031", "Asia", "Western Asia" },
                    { new Guid("52c43e50-6654-43d4-8878-014b6a755449"), "ZM", "ZMB", "Lusaka", "https://restcountries.eu/data/zmb.svg", "Zambia", "Zambia", "894", "Africa", "Eastern Africa" },
                    { new Guid("2959a07c-3023-426c-a003-fae71290058d"), "CZ", "CZE", "Prague", "https://restcountries.eu/data/cze.svg", "Czech Republic", "Česká republika", "203", "Europe", "Eastern Europe" },
                    { new Guid("ba03ebf8-7503-4547-a2ae-3e6ad58c6b0f"), "DJ", "DJI", "Djibouti", "https://restcountries.eu/data/dji.svg", "Djibouti", "Djibouti", "262", "Africa", "Eastern Africa" },
                    { new Guid("1555df29-05ae-4eac-a4a4-61e153082a93"), "GY", "GUY", "Georgetown", "https://restcountries.eu/data/guy.svg", "Guyana", "Guyana", "328", "Americas", "South America" },
                    { new Guid("a63a993c-c85d-4dc3-bc7f-cfdf4b51cf8f"), "HT", "HTI", "Port-au-Prince", "https://restcountries.eu/data/hti.svg", "Haiti", "Haïti", "332", "Americas", "Caribbean" },
                    { new Guid("8aee1b7c-f6d7-43c4-9f94-2b26a37c5049"), "HM", "HMD", "", "https://restcountries.eu/data/hmd.svg", "Heard Island and McDonald Islands", "Heard Island and McDonald Islands", "334", "", "" },
                    { new Guid("547192b5-8b0f-4d8d-a4da-fb90fc26fbc1"), "VA", "VAT", "Rome", "https://restcountries.eu/data/vat.svg", "Holy See", "Sancta Sedes", "336", "Europe", "Southern Europe" },
                    { new Guid("6dc5c659-a684-4471-bdf5-01ac5c45f658"), "HN", "HND", "Tegucigalpa", "https://restcountries.eu/data/hnd.svg", "Honduras", "Honduras", "340", "Americas", "Central America" },
                    { new Guid("a8ccd692-5c94-4f34-abdd-edd08640a83c"), "HK", "HKG", "City of Victoria", "https://restcountries.eu/data/hkg.svg", "Hong Kong", "香港", "344", "Asia", "Eastern Asia" },
                    { new Guid("7a31900b-db55-425f-96d1-969c32ffd870"), "HU", "HUN", "Budapest", "https://restcountries.eu/data/hun.svg", "Hungary", "Magyarország", "348", "Europe", "Eastern Europe" },
                    { new Guid("12408481-7595-46d8-9286-b16befdc45b5"), "IS", "ISL", "Reykjavík", "https://restcountries.eu/data/isl.svg", "Iceland", "Ísland", "352", "Europe", "Northern Europe" },
                    { new Guid("d4dbf8fe-a277-4e4f-95d5-e999aeadb920"), "IN", "IND", "New Delhi", "https://restcountries.eu/data/ind.svg", "India", "भारत", "356", "Asia", "Southern Asia" },
                    { new Guid("e3f7eca2-ec19-4b82-a234-6cec419238a7"), "ID", "IDN", "Jakarta", "https://restcountries.eu/data/idn.svg", "Indonesia", "Indonesia", "360", "Asia", "South-Eastern Asia" },
                    { new Guid("8ad389fe-79a9-4dbc-94cf-1a9dcf11562f"), "CI", "CIV", "Yamoussoukro", "https://restcountries.eu/data/civ.svg", "Côte d'Ivoire", "Côte d'Ivoire", "384", "Africa", "Western Africa" },
                    { new Guid("f51c5432-6931-4cf7-928d-831a1760e1de"), "IR", "IRN", "Tehran", "https://restcountries.eu/data/irn.svg", "Iran (Islamic Republic of)", "ایران", "364", "Asia", "Southern Asia" },
                    { new Guid("f02dc7c4-d9da-42dc-9c2f-6092f4d82e26"), "IQ", "IRQ", "Baghdad", "https://restcountries.eu/data/irq.svg", "Iraq", "العراق", "368", "Asia", "Western Asia" },
                    { new Guid("c1410fdc-85a4-47ba-a898-4802786ca14f"), "IE", "IRL", "Dublin", "https://restcountries.eu/data/irl.svg", "Ireland", "Éire", "372", "Europe", "Northern Europe" },
                    { new Guid("2c1cfe2d-5e32-46cd-8aea-396151eaa4ed"), "IM", "IMN", "Douglas", "https://restcountries.eu/data/imn.svg", "Isle of Man", "Isle of Man", "833", "Europe", "Northern Europe" },
                    { new Guid("44f0bb54-efa4-4ba4-89a6-076bb7376d88"), "IL", "ISR", "Jerusalem", "https://restcountries.eu/data/isr.svg", "Israel", "יִשְׂרָאֵל", "376", "Asia", "Western Asia" },
                    { new Guid("d1c613fb-2418-4269-b4ba-bf90a98942f5"), "IT", "ITA", "Rome", "https://restcountries.eu/data/ita.svg", "Italy", "Italia", "380", "Europe", "Southern Europe" },
                    { new Guid("69ab989d-95f3-4108-8d26-e093c88b7e57"), "JM", "JAM", "Kingston", "https://restcountries.eu/data/jam.svg", "Jamaica", "Jamaica", "388", "Americas", "Caribbean" },
                    { new Guid("fdeeefaf-7ef0-4562-9275-670305138640"), "JP", "JPN", "Tokyo", "https://restcountries.eu/data/jpn.svg", "Japan", "日本", "392", "Asia", "Eastern Asia" },
                    { new Guid("c85764be-46cd-4d14-b420-894959ead251"), "JE", "JEY", "Saint Helier", "https://restcountries.eu/data/jey.svg", "Jersey", "Jersey", "832", "Europe", "Northern Europe" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Capital", "Flag", "Name", "NativeName", "NumericCode", "Region", "Subregion" },
                values: new object[,]
                {
                    { new Guid("bcccc3cc-dac2-49f7-a722-43890aaec688"), "JO", "JOR", "Amman", "https://restcountries.eu/data/jor.svg", "Jordan", "الأردن", "400", "Asia", "Western Asia" },
                    { new Guid("ccebe29f-4458-4912-863e-1a80ccc6a687"), "KZ", "KAZ", "Astana", "https://restcountries.eu/data/kaz.svg", "Kazakhstan", "Қазақстан", "398", "Asia", "Central Asia" },
                    { new Guid("7480707e-ef83-409f-9d67-89422c0ce404"), "KE", "KEN", "Nairobi", "https://restcountries.eu/data/ken.svg", "Kenya", "Kenya", "404", "Africa", "Eastern Africa" },
                    { new Guid("c3eec373-5b30-42a0-82bc-fa819aa3ed6e"), "KI", "KIR", "South Tarawa", "https://restcountries.eu/data/kir.svg", "Kiribati", "Kiribati", "296", "Oceania", "Micronesia" },
                    { new Guid("b2a45cbe-510f-4f73-a886-6d046a5f7c5c"), "KW", "KWT", "Kuwait City", "https://restcountries.eu/data/kwt.svg", "Kuwait", "الكويت", "414", "Asia", "Western Asia" },
                    { new Guid("c170ab84-4fd9-4442-8b16-5921c24d4d3f"), "KG", "KGZ", "Bishkek", "https://restcountries.eu/data/kgz.svg", "Kyrgyzstan", "Кыргызстан", "417", "Asia", "Central Asia" },
                    { new Guid("b88895a2-b0c4-47ba-b4eb-58aae8ceba16"), "LA", "LAO", "Vientiane", "https://restcountries.eu/data/lao.svg", "Lao People's Democratic Republic", "ສປປລາວ", "418", "Asia", "South-Eastern Asia" },
                    { new Guid("0815af08-2613-4d7b-bfa9-5772426efcd5"), "GW", "GNB", "Bissau", "https://restcountries.eu/data/gnb.svg", "Guinea-Bissau", "Guiné-Bissau", "624", "Africa", "Western Africa" },
                    { new Guid("3a9605f6-3a55-4775-a58f-03fbf8bb8acb"), "GN", "GIN", "Conakry", "https://restcountries.eu/data/gin.svg", "Guinea", "Guinée", "324", "Africa", "Western Africa" },
                    { new Guid("ee7dc11c-c8a7-4f5f-896b-7f9dc5178c26"), "GG", "GGY", "St. Peter Port", "https://restcountries.eu/data/ggy.svg", "Guernsey", "Guernsey", "831", "Europe", "Northern Europe" },
                    { new Guid("49fee14e-1cda-462f-8243-1f08737b2ab5"), "GT", "GTM", "Guatemala City", "https://restcountries.eu/data/gtm.svg", "Guatemala", "Guatemala", "320", "Americas", "Central America" },
                    { new Guid("5b204280-6cb8-421d-b4ab-0168e45bfae5"), "DM", "DMA", "Roseau", "https://restcountries.eu/data/dma.svg", "Dominica", "Dominica", "212", "Americas", "Caribbean" },
                    { new Guid("59edf786-0489-4f2c-9fff-893902ba8117"), "DO", "DOM", "Santo Domingo", "https://restcountries.eu/data/dom.svg", "Dominican Republic", "República Dominicana", "214", "Americas", "Caribbean" },
                    { new Guid("eb243258-ce36-465a-8530-8ba4f6ecaecc"), "EC", "ECU", "Quito", "https://restcountries.eu/data/ecu.svg", "Ecuador", "Ecuador", "218", "Americas", "South America" },
                    { new Guid("ae57b7db-b7e1-4a4d-ab5c-451ab6ab351d"), "EG", "EGY", "Cairo", "https://restcountries.eu/data/egy.svg", "Egypt", "مصر‎", "818", "Africa", "Northern Africa" },
                    { new Guid("267262f8-cd1b-43b6-82fd-4d24718d774b"), "SV", "SLV", "San Salvador", "https://restcountries.eu/data/slv.svg", "El Salvador", "El Salvador", "222", "Americas", "Central America" },
                    { new Guid("90716c83-5cc8-4594-9d82-cd22611b9875"), "GQ", "GNQ", "Malabo", "https://restcountries.eu/data/gnq.svg", "Equatorial Guinea", "Guinea Ecuatorial", "226", "Africa", "Middle Africa" },
                    { new Guid("d1424722-ee02-4627-9f66-ef2f1652a06c"), "ER", "ERI", "Asmara", "https://restcountries.eu/data/eri.svg", "Eritrea", "ኤርትራ", "232", "Africa", "Eastern Africa" },
                    { new Guid("197f1635-8597-45c6-be45-fe0b30b451a4"), "EE", "EST", "Tallinn", "https://restcountries.eu/data/est.svg", "Estonia", "Eesti", "233", "Europe", "Northern Europe" },
                    { new Guid("a1d66e62-a140-4ff6-a81b-f4482816f04b"), "ET", "ETH", "Addis Ababa", "https://restcountries.eu/data/eth.svg", "Ethiopia", "ኢትዮጵያ", "231", "Africa", "Eastern Africa" },
                    { new Guid("c93e7d87-89a0-4cb0-a1e8-954c1986ba72"), "FK", "FLK", "Stanley", "https://restcountries.eu/data/flk.svg", "Falkland Islands (Malvinas)", "Falkland Islands", "238", "Americas", "South America" },
                    { new Guid("d17708ef-fd40-4f04-a9f8-72128293f52a"), "FO", "FRO", "Tórshavn", "https://restcountries.eu/data/fro.svg", "Faroe Islands", "Føroyar", "234", "Europe", "Northern Europe" },
                    { new Guid("ceccd2a9-b056-4258-a3d3-f105fb06b170"), "FJ", "FJI", "Suva", "https://restcountries.eu/data/fji.svg", "Fiji", "Fiji", "242", "Oceania", "Melanesia" },
                    { new Guid("33b560e6-84ec-4f13-8d93-45545e8ba69b"), "FI", "FIN", "Helsinki", "https://restcountries.eu/data/fin.svg", "Finland", "Suomi", "246", "Europe", "Northern Europe" },
                    { new Guid("63ee54b4-9572-4be1-8c09-fa2dc20a7cad"), "DK", "DNK", "Copenhagen", "https://restcountries.eu/data/dnk.svg", "Denmark", "Danmark", "208", "Europe", "Northern Europe" },
                    { new Guid("823a5d76-9d94-44fb-9842-ffbbedc6b83e"), "FR", "FRA", "Paris", "https://restcountries.eu/data/fra.svg", "France", "France", "250", "Europe", "Western Europe" },
                    { new Guid("5e1afe29-4629-4844-a608-d767527d0d15"), "PF", "PYF", "Papeetē", "https://restcountries.eu/data/pyf.svg", "French Polynesia", "Polynésie française", "258", "Oceania", "Polynesia" },
                    { new Guid("2681a278-97be-457f-8560-e2b81e76c072"), "TF", "ATF", "Port-aux-Français", "https://restcountries.eu/data/atf.svg", "French Southern Territories", "Territoire des Terres australes et antarctiques françaises", "260", "Africa", "Southern Africa" },
                    { new Guid("6423cd06-de9c-45ff-8f74-141498f3e896"), "GA", "GAB", "Libreville", "https://restcountries.eu/data/gab.svg", "Gabon", "Gabon", "266", "Africa", "Middle Africa" },
                    { new Guid("f3ee5989-2e7e-49b3-a830-15d2d4ed9bf0"), "GM", "GMB", "Banjul", "https://restcountries.eu/data/gmb.svg", "Gambia", "Gambia", "270", "Africa", "Western Africa" },
                    { new Guid("1331b37d-f987-4853-b90d-b415192d117b"), "GE", "GEO", "Tbilisi", "https://restcountries.eu/data/geo.svg", "Georgia", "საქართველო", "268", "Asia", "Western Asia" },
                    { new Guid("a15dc81d-89ec-440b-b36d-1c3209bd949e"), "DE", "DEU", "Berlin", "https://restcountries.eu/data/deu.svg", "Germany", "Deutschland", "276", "Europe", "Western Europe" },
                    { new Guid("a6bc86e8-71c3-40b9-9636-eec15460fc2b"), "GH", "GHA", "Accra", "https://restcountries.eu/data/gha.svg", "Ghana", "Ghana", "288", "Africa", "Western Africa" },
                    { new Guid("22d23736-e1eb-4a55-98df-fdd83a8c17b9"), "GI", "GIB", "Gibraltar", "https://restcountries.eu/data/gib.svg", "Gibraltar", "Gibraltar", "292", "Europe", "Southern Europe" },
                    { new Guid("726ad58e-2982-4b12-80f5-53f9b383aba4"), "GR", "GRC", "Athens", "https://restcountries.eu/data/grc.svg", "Greece", "Ελλάδα", "300", "Europe", "Southern Europe" },
                    { new Guid("05708952-ea8f-4d3e-ba74-53e1ec04d807"), "GL", "GRL", "Nuuk", "https://restcountries.eu/data/grl.svg", "Greenland", "Kalaallit Nunaat", "304", "Americas", "Northern America" },
                    { new Guid("acf883cc-9b5c-4865-b01d-e4d958def5a9"), "GD", "GRD", "St. George's", "https://restcountries.eu/data/grd.svg", "Grenada", "Grenada", "308", "Americas", "Caribbean" },
                    { new Guid("7528f5e1-3ce8-47fc-819e-72ddbb9aac89"), "GP", "GLP", "Basse-Terre", "https://restcountries.eu/data/glp.svg", "Guadeloupe", "Guadeloupe", "312", "Americas", "Caribbean" },
                    { new Guid("f874609d-83fe-4271-8985-3315b548de53"), "GU", "GUM", "Hagåtña", "https://restcountries.eu/data/gum.svg", "Guam", "Guam", "316", "Oceania", "Micronesia" },
                    { new Guid("395c467f-3cc8-4a36-86c0-322fe3576d09"), "GF", "GUF", "Cayenne", "https://restcountries.eu/data/guf.svg", "French Guiana", "Guyane française", "254", "Americas", "South America" },
                    { new Guid("e97e76f2-6a58-46c1-96f0-42c21afd8a62"), "ZW", "ZWE", "Harare", "https://restcountries.eu/data/zwe.svg", "Zimbabwe", "Zimbabwe", "716", "Africa", "Eastern Africa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("01d540a9-33e3-48ad-b275-4c33e8caf7e2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("05708952-ea8f-4d3e-ba74-53e1ec04d807"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0815af08-2613-4d7b-bfa9-5772426efcd5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0937c609-970e-4543-b033-cc8db6ed2102"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0a3dbaa8-1e66-4cc7-81f1-91086978adbd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0c5990cc-7e36-48bb-b27f-eab10c1f63a4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0c68ee39-cb1a-4b21-9dc9-aa534c495ba0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0d58b611-a200-4f13-af15-e6a9fe9505a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e04abd6-ae59-4577-af61-77ca07ce2c76"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("10bbd032-59c1-411f-bb45-a652822cc77d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("11ac58f3-5860-4072-8785-a069ea479dfd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("12408481-7595-46d8-9286-b16befdc45b5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("12d2dfc5-155f-4fdf-9fdf-482feea3fe3b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("132088b4-6265-4348-b4bc-0400e6bae42a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1331b37d-f987-4853-b90d-b415192d117b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1555df29-05ae-4eac-a4a4-61e153082a93"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("17328f9d-634f-4ac1-8e40-b1cc89a86f5d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1732cbf2-d4a3-4fc4-90b6-fe53f46544de"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("194ddb43-4e98-48d0-8a12-d12c678cadff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("197f1635-8597-45c6-be45-fe0b30b451a4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1b098170-2a55-4bd0-bf53-1410fd28d3ca"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1d1376ac-3fdc-4227-a3e7-6888cd05dfc2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1df1ce19-c699-4c15-b085-9487022d431e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1f577062-a5ef-4380-b150-b634b7b5d93b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("204b318b-18f3-44cb-96d5-6a67951bef85"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2069700a-08e4-489c-b192-8472796ea1dd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("214db839-ae08-4383-b2f4-d533a5f54eb7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("22d23736-e1eb-4a55-98df-fdd83a8c17b9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("232da08e-b50f-4977-9fa0-f51d9cdbafe6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("23794c29-09ca-4ab1-a614-9c6f8f7aaad8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("23f142b9-4adf-4558-8376-d115113113f6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("261b1c6a-51cb-48dc-adaa-877dd3f23d54"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("267262f8-cd1b-43b6-82fd-4d24718d774b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2681a278-97be-457f-8560-e2b81e76c072"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("269b3f90-e299-4edc-80cf-e0a3f8702594"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("274bf5d1-8c98-4e98-9ace-277a6cfaee14"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2959a07c-3023-426c-a003-fae71290058d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2a31d646-8858-4b12-8cd6-e49b81fe7371"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2be7db02-eb67-49eb-9ca3-b1999c297e5f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c1cfe2d-5e32-46cd-8aea-396151eaa4ed"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c595956-83f1-41f9-ba9b-e70fe7cb1a4c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2e7e08a8-0b61-461f-9235-b89cae8bff37"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2ef8a6d1-8ab6-4b91-810a-b8767039a174"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2f361d19-fa2b-42e6-a7fe-f2a9bf387af3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("308ba0f4-ba59-4d87-85a5-e3eaa60d3cd3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("315769ce-ca7c-4352-9a0e-80ce76beaa83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("32f29e4a-ac91-42ff-9089-dd94445f0823"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("33a56285-4e0b-4d12-8f66-980be9d12d8e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("33b560e6-84ec-4f13-8d93-45545e8ba69b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("34faab92-2def-4910-8579-4ae5a5661e47"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("378c7fbe-796e-43b3-95cf-a72b96df7332"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("395c467f-3cc8-4a36-86c0-322fe3576d09"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a22fd01-f759-4026-a869-78779c4bab40"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a9605f6-3a55-4775-a58f-03fbf8bb8acb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3bfb8810-63c7-42cf-b36b-f9cbd4cf8f82"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ce77728-a64e-471c-a5e5-e0063a0f204b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3e75eeaa-3ce6-4238-8c70-a7eb7fa26104"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4015cc1c-c933-4a4b-a046-23ad348f5b3b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42f69eb8-85d6-4691-80ae-644d5f966d17"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("43b94ca5-88f7-4c3c-afa6-370c9b6a9a87"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("44f0bb54-efa4-4ba4-89a6-076bb7376d88"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4505325e-a5b8-4998-bfef-fd369ecdf225"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("45c45b47-f422-4773-86f1-13338e4c4d1f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("48938750-d3aa-44df-9c71-df109c9f7dbf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("49133169-6b4b-4ee8-af86-9ab94546e230"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("49fee14e-1cda-462f-8243-1f08737b2ab5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d688aff-9482-4157-949c-0adbff277083"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51f7ab3a-3b3c-4a5e-a6e3-12d3f6ddfaee"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("52c43e50-6654-43d4-8878-014b6a755449"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("547192b5-8b0f-4d8d-a4da-fb90fc26fbc1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("55ee3de8-6921-4fe4-a07a-d25a4d9938bf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("572aec11-46c1-4666-9cba-db8df5daae26"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("596b0985-466f-463b-ab5c-ed26a6865f4c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("59edf786-0489-4f2c-9fff-893902ba8117"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5a71266f-68ee-4bd8-b15a-a074b5f40835"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5b204280-6cb8-421d-b4ab-0168e45bfae5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5bf88b53-3eda-4ee0-bb17-aa32c5adb914"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c83933a-145b-4b3d-adc8-fd7d26a1bc1d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5ce62dd5-6aac-4d87-8cb8-03a7a4363892"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5e1afe29-4629-4844-a608-d767527d0d15"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6137af7e-01d0-4a0c-90cf-f80c68f66383"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6158a627-ba43-437c-b622-9f8398a814e7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6301e4db-b9ba-4b6c-bd51-f1fde9104e73"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6345c65a-4080-4974-9810-8a764172f926"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63901dc7-1c31-4d6d-8926-1e863341184b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63ee54b4-9572-4be1-8c09-fa2dc20a7cad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6423cd06-de9c-45ff-8f74-141498f3e896"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("662b86f1-081b-4ddc-817e-36eb2ca2be09"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("670539f3-585f-4e30-a13e-9bd99ff6ef1b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69ab989d-95f3-4108-8d26-e093c88b7e57"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6a66c807-df30-429e-b3bb-185be7d02f02"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6b071d25-3553-4b1c-a3f4-3962010ac25f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6c0aa0db-a0cb-477a-9355-8f200389bd2b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6d43a0e8-df08-4304-ac2b-eaeb3c37c7a7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6dc5c659-a684-4471-bdf5-01ac5c45f658"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6eb08cd8-aca8-4aa8-808f-d129fe6c207a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f5962b4-4aa9-4990-b017-e053fd5da063"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f938f1c-352d-41bf-b528-b9a15bcd75e9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70e53a82-5b2a-4bb2-964e-3531faa8b64a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("71c05ac1-d81b-44b0-a45d-0c86205417d7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("726ad58e-2982-4b12-80f5-53f9b383aba4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("73449259-528f-4ae0-b451-08c0b4e8c645"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7480707e-ef83-409f-9d67-89422c0ce404"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("74885c5f-8c8f-4044-9214-86ecde1685c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7528f5e1-3ce8-47fc-819e-72ddbb9aac89"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("75f1cbe3-54cb-4749-bbd4-a6882dbb8e95"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7696272c-c5a5-422b-8d17-2e25ff05c2ae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("76ba549b-0fe7-4694-99d5-6366f92cbaa6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7701eac7-4c23-45ce-9787-bf405a62174e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78bc2f5f-552b-464f-8a7b-0b640f21496a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("799efaaa-e677-4ea1-9932-fc5ba9a5dbbc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7a31900b-db55-425f-96d1-969c32ffd870"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ba8bee1-c39e-4c8d-8d3c-ad067bbbc64e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7c636f92-f0a3-4227-aaec-362a5fa94635"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7cf0a2f9-bf64-4902-a9d1-9924fdbe31c7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7db8d084-1055-4602-be3e-aaf04d4b442a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e5b08c7-65bb-4390-80fd-632755acbe21"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8008ffdd-e002-4936-8235-b87c7f807621"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("805cd28c-83ca-447d-a29d-587f0cb3847d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("809eb15d-15d5-43ff-a4fa-ebdad280c4ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("812e2099-92c7-4e66-8c70-d7845065676a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("81500654-7131-4ccd-a529-a6fc951c8a44"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("81b97db7-80f9-4664-b550-998bb555ce90"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("823a5d76-9d94-44fb-9842-ffbbedc6b83e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("82eeddf1-37a0-4a45-832c-acbe6bbe87ac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("846a9aba-8e31-4c2f-8f92-5bae500c5184"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("86c97b17-95a1-494a-9285-9a6cc5a298f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("87ef4e44-7145-4e76-a210-197c60adf6d5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8ad389fe-79a9-4dbc-94cf-1a9dcf11562f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8ad75e5d-9977-4ebe-9faa-8655647e8c29"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8aee1b7c-f6d7-43c4-9f94-2b26a37c5049"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8cca2c94-2134-4189-ab03-086a7fd82961"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8dbd247f-ee17-43e4-98e3-153eb3c84d50"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8f8e4f3a-2063-41d3-8d33-e9b1052316dd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("90716c83-5cc8-4594-9d82-cd22611b9875"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9104bd7e-8271-4fe1-bb2c-2c6b4d53ce7e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("94dbfa6e-af78-40e8-a0f7-16223ab755a8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("96964d8a-a599-4b6f-9524-bd4e7115cb01"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("96977c85-7ba5-406a-aa43-e73e992c5055"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("98868a63-d2a3-41c9-aaa6-6a35c799c692"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("998f0d23-ba73-490f-baa5-752c3b850ce6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9a9f1307-9b7f-48d1-900e-d7dce0b6dc7e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9b7209d2-c09c-4034-ba64-83716a1b962a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9ba1aff6-367f-4cd7-97df-4ea9f342f892"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9bd10c7b-8b2a-4da1-8505-699e64bc5c42"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c1ac0e0-1728-48db-930a-672c381e6fbd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f1bd552-3022-4371-ab1c-50d78698de4a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a15cd9d6-433d-4f6d-9765-83d2fc300a43"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a15dc81d-89ec-440b-b36d-1c3209bd949e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a1d66e62-a140-4ff6-a81b-f4482816f04b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a268dab4-ef64-425a-a40e-20f2dbafe074"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a27f0a23-de64-4159-977f-00e9a91a430f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a290bf93-e241-4368-8a5f-54e45109bf93"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a2d0a55b-8114-42e0-a789-add1b8e09f7d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a361d3cd-9188-4f75-844a-9830ab94fb3f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a5195450-054f-4357-a983-affd2827d14d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a63a993c-c85d-4dc3-bc7f-cfdf4b51cf8f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a6bc86e8-71c3-40b9-9636-eec15460fc2b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a78ccb70-5a5f-4ce1-a0af-95f1c354e42c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a8b6a4df-8fef-4a17-b770-33c22b74d1d7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a8ccd692-5c94-4f34-abdd-edd08640a83c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a9b6eac4-43d1-4711-9b38-636455739b1e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aacafac3-fffe-4c5f-a611-b4ac758a070c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab8c3196-e2d0-41d1-8ad9-8e23cb9cae82"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("abbd4c43-24ee-48f0-885f-65b4d8e6676f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac9fdaf1-f159-49eb-9ef1-7704dcd7035a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("acc15534-be2b-4f16-83c3-148b4ed2611b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("acf883cc-9b5c-4865-b01d-e4d958def5a9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ad2736d0-6d85-47c1-8879-c0bd5db7962f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ad526a30-748e-46c8-93b5-50543cfbdeba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ae57b7db-b7e1-4a4d-ab5c-451ab6ab351d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aee53095-af3e-45c9-b7c7-bde4f6da4caf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("afb0a7f9-5a2f-4910-b7c3-32e6b3e4a9a4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("afcae147-f67c-4542-b96c-3f85d646e677"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b09968f9-af64-49a2-b731-84976867e7dc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b0cef9bd-da4e-41ab-80f8-3503fd7f349d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b2a45cbe-510f-4f73-a886-6d046a5f7c5c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b4bdb6ab-f87d-4ec6-a309-460a8eb69b6f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b78e09f0-44d4-428a-9534-ab819148ce48"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b88895a2-b0c4-47ba-b4eb-58aae8ceba16"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b9bae87b-f0a0-4546-af01-534ac68387c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ba03ebf8-7503-4547-a2ae-3e6ad58c6b0f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("baa49333-b522-48b3-834c-88209dfbb5ea"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("babc62d0-cafa-4a3e-a693-8921368eabf9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bcccc3cc-dac2-49f7-a722-43890aaec688"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("be3aa119-7a05-4027-b6c3-63cc189daaf6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bfe525f0-91b1-4a0a-a441-06f575895df2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c1410fdc-85a4-47ba-a898-4802786ca14f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c170ab84-4fd9-4442-8b16-5921c24d4d3f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c2348090-0a82-4dc7-97fd-771f44323aef"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c2b9a6ce-0265-44c2-9a60-50edd425e968"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c3c9c5d7-8643-4ee9-898d-500a73db5f25"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c3eec373-5b30-42a0-82bc-fa819aa3ed6e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c70a0fe5-ad96-4581-b78c-263724633c37"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c85764be-46cd-4d14-b420-894959ead251"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c93e7d87-89a0-4cb0-a1e8-954c1986ba72"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c9e4ab7f-990a-4dc9-8a9a-f8d804958ff4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cb1500e7-750b-4b7a-9c77-bcad610966b8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cc547fd4-cd82-4a5e-9559-f6d58e19651b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ccebe29f-4458-4912-863e-1a80ccc6a687"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cd935cd6-dcec-476b-98dc-65983d2537c4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ceccd2a9-b056-4258-a3d3-f105fb06b170"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d1424722-ee02-4627-9f66-ef2f1652a06c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d17708ef-fd40-4f04-a9f8-72128293f52a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d1c613fb-2418-4269-b4ba-bf90a98942f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d25d242d-b93c-4460-b640-47b658c340c8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d2c52f4c-c9dc-4868-afe0-cdb7f4bfbe51"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d3268ec0-b4b1-47cd-ae23-e6dc3c242f89"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d4280d9a-9c4f-4914-b0c0-d39e11a9afd3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d4dbf8fe-a277-4e4f-95d5-e999aeadb920"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d708953d-8585-4722-8ce3-b20dd17861b3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d922ae67-11b3-4fae-a79d-ddc0216b347d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d9f2c0ef-53a4-4a67-8026-d7ba0f9e20af"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("da6b6015-71b3-48a0-bb5a-54522b4df254"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dcdb75d5-d057-43c6-998f-592eaf09907d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dd0f6ae1-6f62-4357-b8f2-533471617bdf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dfbb3f4d-9e69-4c55-9b2d-c55545c6e986"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e1ff7cfc-0707-4afe-8803-f8f8269c00b4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e3cb2fd0-190a-4d7f-bd5c-761d88d50f89"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e3f7eca2-ec19-4b82-a234-6cec419238a7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e662f2a3-474e-468f-bef3-4e3cb010e1f7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7b68d71-4ee9-4f13-8141-da800eeb5d77"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e91bb661-9db2-44df-90c1-462fe6f4edeb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e97e76f2-6a58-46c1-96f0-42c21afd8a62"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e9bc7071-66dd-48c4-a94a-cca877851698"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eb243258-ce36-465a-8530-8ba4f6ecaecc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed70ce7c-383f-4436-b1b0-312033fa7e54"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed927eb3-fedc-4a15-8345-d34ac145ca6a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ede348cd-5f0b-4644-b2b4-7872a3c995d0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ee7dc11c-c8a7-4f5f-896b-7f9dc5178c26"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("efbd47ed-f8b1-4430-a73b-a80d15812cc2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f02dc7c4-d9da-42dc-9c2f-6092f4d82e26"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0eb2f9e-2a06-4bc1-8281-fb68f49e9a95"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0eeb88f-1889-43f3-ad33-16cf3b9ebe53"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f256d7df-2e5e-4bf2-9608-8f09e0ef30f4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f28fe7f9-52da-46db-85b0-c343cc7b5835"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f31bc5dd-68c3-4b5b-b8e9-00472e09c05f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f3ee5989-2e7e-49b3-a830-15d2d4ed9bf0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f40fdd03-3b0e-4bc4-838e-a61537e3fcf3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f4b34ec3-7f2d-48e0-af76-70082ed24ad4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f51c5432-6931-4cf7-928d-831a1760e1de"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f734a338-cc95-40dd-8d74-2207c043e3d7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f800ac1f-ea53-4d12-b25b-a3cbbff8f6b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f874609d-83fe-4271-8985-3315b548de53"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fac6bb07-f33c-4b2d-85e8-cc20c9893d7f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fb708ba4-4179-4c03-8e69-2dc8d9ee2887"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fc6460e0-84cf-467f-aeb1-3d546bfd7613"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fc738cef-a4d4-4e01-abb9-56a6d0410a03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fc8053b8-29d6-4284-ba29-504e7c3ba032"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fdeeefaf-7ef0-4562-9275-670305138640"));
        }
    }
}
