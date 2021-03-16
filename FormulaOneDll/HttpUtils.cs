using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FormulaOneDll {
    public class HttpUtils {
        public enum ResultFields {
            Team,
            Driver,
            Race
        }

        public IEnumerable<DriverCardDto> GetDriverCards() {
            HttpWebRequest apiRequest = WebRequest.Create("https://localhost:44329/api/driver") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<CircuitDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<string> GetResultList(ResultFields field) {
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
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<ResultRaceAllDto> GetRaceResults() {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/race/all/result") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultRaceAllDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ResultRaceDto GetRaceResults(int raceId) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/race/{raceId}/result") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultRaceDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ResultRaceGridDto GetRaceGrid(int raceId) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/race/{raceId}/grid") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultRaceGridDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ResultRaceFastestDto GetRaceFastestLaps(int raceId) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/race/{raceId}/fastest") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultRaceFastestDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<ResultDriverAllDto> GetDriverResults() {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/driver/all") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDriverAllDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ResultDriverDto GetDriverResults(int driverNumber) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/driver/{driverNumber}") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDriverDto>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<ResultTeamAllDto> GetTeamResults() {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/team/all") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultTeamAllDto[]>(apiResponse);
                    }
                }
            }
            catch (WebException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ResultTeamDto GetTeamResults(int teamId) {
            HttpWebRequest apiRequest = WebRequest.Create($"https://localhost:44329/api/result/team/{teamId}") as HttpWebRequest;
            try {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse) {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                        string apiResponse = reader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultTeamDto>(apiResponse);
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
