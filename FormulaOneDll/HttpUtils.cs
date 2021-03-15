using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FormulaOneDll {
    public class HttpUtils {
        public enum ResultFields {
            Team,
            Driver,
            Race
        }

        public IEnumerable<DriverCardDto> GetDriverCards() {
            HttpWebRequest apiRequest = WebRequest.Create("https://localhost:44329/api/driver") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<DriverCardDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public DriverDto GetDriverDetails(int driverNumber) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/driver/{driverNumber}") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<DriverDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<DriverSearchNameDto> GetDriverByName(string driverSearch) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/driver/name/{driverSearch}") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<DriverSearchNameDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /* TEAM *******************************************************************************************************/

        public IEnumerable<TeamCardDto> GetTeamCards() {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/team") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<TeamCardDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public TeamDto GetTeamDetails(int id) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/team/{id}") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<TeamDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<TeamDto> GetTeamByName(string teamName) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/team/name/{teamName}") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<TeamDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<RaceCardDto> GetRaceCards() {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/race") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<RaceCardDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public RaceCardDto GetRaceDetails(int raceId) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/race/{raceId}") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<RaceCardDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public CircuitDto GetCircuit(int circuitId) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/circuit/{circuitId}") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<CircuitDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public IEnumerable<CircuitDto> GetCircuits() {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/circuit") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<CircuitDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<string> GetCircuits(ResultFields field) {
            string f = "";
            switch (field) {
                case ResultFields.Team:
                    f = "team";
                    break;
                case ResultFields.Driver:
                    f = "driver";
                    break;
                case ResultFields.Race:
                    f = "race";
                    break;
                default:
                    break;
            }
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/{f}") as HttpWebRequest;
            string apiResponse = "";
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
