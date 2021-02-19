using System;
using System.Collections.Generic;
using System.Data;

namespace FormulaOneDll {
    public class Race {
        private string _id;
        private string _name;
        private string _circuitId;
        private DateTime _dateStart;
        private Circuit _circuit;
        private List<Result> _results;

        public Race(string id, string name, string circuitId, DateTime dateStart) {
            _id = id;
            _name = name;
            _circuitId = circuitId;
            DateStart = dateStart;
        }

        public Race(DataRow r) {
            _id = r["id"].ToString().Trim();
            _name = r["name"].ToString().Trim();
            _circuitId = r["circuit_id"].ToString().Trim();
            _dateStart = Convert.ToDateTime(r["date_start"].ToString().Trim());
        }

        public void SetResults(Result[] r) {
            _results = new List<Result>();
            _results.AddRange(r);
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string CircuitId { get => _circuitId; set => _circuitId = value; }
        public Circuit Circuit { get => _circuit; set => _circuit = value; }
        public List<Result> Results { get => _results; }
        public DateTime DateStart { get => _dateStart; set => _dateStart = value; }
    }
}
