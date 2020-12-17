using System.Collections.Generic;
using System.Data;

namespace FormulaOneDllProject {
    public class Race {
        private string _id;
        private string _name;
        private string _circuitId;
        private Circuit _circuit;
        private List<Result> _results;

        public Race(string id, string name, string circuitId) {
            _id = id;
            _name = name;
            _circuitId = circuitId;
        }

        public Race(DataRow r) {
            _id = r["id"].ToString().Trim();
            _name = r["name"].ToString().Trim();
            _circuitId = r["circuit_id"].ToString().Trim();
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
    }
}
