using System.Data;

namespace FormulaOneDllProject {
    internal class GranPrix {
        private string _id;
        private string _name;
        private string _circuitId;
        private Circuit _raceCircuit;

        public GranPrix(string id, string name, string circuitId) {
            _id = id;
            _name = name;
            _circuitId = circuitId;
        }

        public GranPrix(DataRow r) {
            _id = r["gpID"].ToString().Trim();
            _name = r["gpName"].ToString().Trim();
            _circuitId = r["circuitID"].ToString().Trim();
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string CircuitId { get => _circuitId; set => _circuitId = value; }
        internal Circuit RaceCircuit { get => _raceCircuit; set => _raceCircuit = value; }
    }
}
